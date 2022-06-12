using GraLibrary;
using GraLibrary.Zdarzenia;

namespace GraUI
{
    public class Gra
    {
        private string profesja;
        private Postać postać;
        private Miejsce obecneMiejsce;
        private Dictionary<Miejsce, List<Miejsce>> mapa;

        public Gra()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //wybór kodowania UTF8
            ZaładujMapę();
            ZaładujDruida();
        }

        public void RozpocznijGrę()
        {
            WybierzProfesję();
            ZaładujHandlarza();
            GraLoop(); // Właściwa pętla z grą
        }

        private void GraLoop()
        {
            System.Console.Clear();

            obecneMiejsce.WykonajZdarzenie(postać); //wykonanie zdarzenia na obecnej mapie

            if(postać.zdrowie <= 0) //zakończenie gry jeśli postać zginęła
            {
                System.Console.WriteLine("Jesteś MARTWY.");
                System.Console.WriteLine("To koniec twojej przygody.");
                System.Console.WriteLine("Spoczywaj w zaświatach.");
                System.Console.WriteLine($"Zakończyłeś grę z { postać.poziom } poziomem postaci.");
                return;
            }

            postać.WbiciePoziomu(); //aktualizacja poziomu postaci

            System.Console.WriteLine($"{ profesja }: { postać.poziom } Level { postać.doświadczenie }/100 EXP  Złoto: { postać.złoto }");
            System.Console.WriteLine();
            System.Console.WriteLine($"Znajdujesz się obecnie w { obecneMiejsce.Nazwa }");

            if(obecneMiejsce.Nazwa == "Rynek Główny")
            {
                SpotkanieHandlarza();
                postać.PrzeliczStatystyki();
            }

            WybórKolejnejAkcji();
        }

        private void ZaładujMapę()
        {
            mapa = new Dictionary<Miejsce, List<Miejsce>>();
            
            /*
                Stworzenie miejsc
            */
            Miejsce rynekGłówny = new Miejsce("Rynek Główny");
            Miejsce rozległePola = new Miejsce("Rozległe Pola");
            Miejsce ciemnyLas = new Miejsce("Ciemny Las");
            Miejsce magazynyŻywności = new Miejsce("Magazyny Żywności");
            Miejsce staryCmentarz = new Miejsce("Stary Cmentarz");
            Miejsce park = new Miejsce("Park");
            Miejsce poczta = new Miejsce("Poczta");
            Miejsce opuszczoneRuiny = new Miejsce("Opuszczone Ruiny");
            Miejsce wybrzeżeMorza = new Miejsce("Wybrzeże Morza");
            Miejsce portMorski = new Miejsce("Port Morski");
            Miejsce tawerna = new Miejsce("Tawerna");
            Miejsce spokojnaDzielnica = new Miejsce("Spokojna Dzielnica");
            Miejsce tajemniczyZamek = new Miejsce("Tajemniczy Zamek");
            Miejsce lochy = new Miejsce("Lochy");

            /*
                Stworzenie mapy
            */

            mapa.Add(rynekGłówny, new List<Miejsce>{rozległePola, magazynyŻywności, poczta, portMorski, spokojnaDzielnica});
            mapa.Add(rozległePola, new List<Miejsce>{rynekGłówny, tajemniczyZamek, ciemnyLas, magazynyŻywności, spokojnaDzielnica});
            mapa.Add(ciemnyLas, new List<Miejsce>{rozległePola, magazynyŻywności, staryCmentarz});
            mapa.Add(magazynyŻywności, new List<Miejsce>{rynekGłówny, rozległePola, ciemnyLas, staryCmentarz, park, poczta});
            mapa.Add(staryCmentarz, new List<Miejsce>{ciemnyLas, magazynyŻywności, park, opuszczoneRuiny});
            mapa.Add(park, new List<Miejsce>{poczta, magazynyŻywności, staryCmentarz, portMorski ,opuszczoneRuiny});
            mapa.Add(poczta, new List<Miejsce>{rynekGłówny, magazynyŻywności, park, portMorski});
            mapa.Add(opuszczoneRuiny, new List<Miejsce>{staryCmentarz, park, portMorski, wybrzeżeMorza});
            mapa.Add(wybrzeżeMorza, new List<Miejsce>{opuszczoneRuiny, portMorski, tawerna});
            mapa.Add(portMorski, new List<Miejsce>{rynekGłówny, poczta, park, opuszczoneRuiny, wybrzeżeMorza, tawerna, spokojnaDzielnica});
            mapa.Add(tawerna, new List<Miejsce>{wybrzeżeMorza, portMorski, spokojnaDzielnica});
            mapa.Add(spokojnaDzielnica, new List<Miejsce>{tawerna, portMorski, rynekGłówny, rozległePola, tajemniczyZamek});
            mapa.Add(tajemniczyZamek, new List<Miejsce>{spokojnaDzielnica, rozległePola, lochy});
            mapa.Add(lochy, new List<Miejsce>{tajemniczyZamek});

            /*
                ustawienie obecnego miejsca na rynek główny
            */
            obecneMiejsce = rynekGłówny;

            /*
                dodanie zdarzeń do miejsc
            */

            //Rynek Główny
            rynekGłówny.DodajZdarzenie(new ZdarzenieStudnia());
            rynekGłówny.DodajZdarzenie(new ZdarzenieTrzyKarty());

            //Rozległe Pola
            rozległePola.DodajZdarzenie(new ZdarzeniePola());

            //Ciemny Las
            ciemnyLas.DodajZdarzenie(new ZdarzenieDruid());
            ciemnyLas.DodajZdarzenie(new ZdarzenieWilk());
            ciemnyLas.DodajZdarzenie(new ZdarzenieNiedźwiedź());

            //Magazyny Żywności
            magazynyŻywności.DodajZdarzenie(new ZdarzenieKradzieżTowarów());
            magazynyŻywności.DodajZdarzenie(new ZdarzenieStrażnik());

            //Stary Cmentarz
            staryCmentarz.DodajZdarzenie(new ZdarzenieGrobowiec());
            staryCmentarz.DodajZdarzenie(new ZdarzenieKsiądz());
            staryCmentarz.DodajZdarzenie(new ZdarzeniePodejrzanyCzłowiek());

            //Park
            park.DodajZdarzenie(new ZdarzenieŁawka());
            park.DodajZdarzenie(new ZdarzenieSpacer());
            park.DodajZdarzenie(new ZdarzenieOkradzeniePark());

            //Poczta
            poczta.DodajZdarzenie(new ZdarzenieKoperta());  

            //Opuszczone Ruiny
            opuszczoneRuiny.DodajZdarzenie(new ZdarzenieSkrytka());
            opuszczoneRuiny.DodajZdarzenie(new ZdarzenieStarzec());
            opuszczoneRuiny.DodajZdarzenie(new ZdarzeniePodejrzanyCzłowiek());

            //Wybrzeże Morza
            wybrzeżeMorza.DodajZdarzenie(new ZdarzenieTajemniczyCzłowiek());
            wybrzeżeMorza.DodajZdarzenie(new ZdarzenieOdpoczynek());
            wybrzeżeMorza.DodajZdarzenie(new ZdarzeniePodejrzanyCzłowiek());

            //Port Morski
            //////rybak
            //////rozładunek

            //Tawerna
            tawerna.DodajZdarzenie(new ZdarzeniePiwo());
            tawerna.DodajZdarzenie(new ZdarzenieBójka());
            tawerna.DodajZdarzenie(new ZdarzenieOkradzenieTawerna());

            //Spokojna Dzielnica
            spokojnaDzielnica.DodajZdarzenie(new ZdarzenieTragarz());
            spokojnaDzielnica.DodajZdarzenie(new ZdarzenieWędrowiec());

            //Tajemniczy Zamek
            tajemniczyZamek.DodajZdarzenie(new ZdarzenieZjawa());
            tajemniczyZamek.DodajZdarzenie(new ZdarzenieSkrzynia());
            tajemniczyZamek.DodajZdarzenie(new ZdarzenieKomnata());

            //Lochy
            lochy.DodajZdarzenie(new ZdarzenieLegendarnyPotwór());


        }
    
        private void WybierzProfesję()
        {
            System.Console.Clear();
            System.Console.WriteLine("Witaj przyjacielu");
            System.Console.WriteLine("Aby rozpocząć grę musisz wybrać swoją profesję");
            System.Console.WriteLine("Masz do wyboru: wojownika, maga i strzelca");
            System.Console.WriteLine("Aby wybrać wojownika wpisz W");
            System.Console.WriteLine("Aby wybrać maga wpisz M");
            System.Console.WriteLine("Aby wybrać strzelca wpisz S");

            bool poprawnyWybór = false;

            while(!poprawnyWybór)
            {
                poprawnyWybór = true;

                string? wybranaProfesja = System.Console.ReadLine();
                wybranaProfesja = wybranaProfesja?.Trim();

                if(wybranaProfesja == "W")
                {
                    profesja = "Wojownik";
                    postać = Wojownik.Instancja;
                    System.Console.Clear();
                    System.Console.WriteLine("Wybrałeś Wojownika!");
                }
                else if(wybranaProfesja == "M")
                {
                    profesja = "Mag";
                    postać = Mag.Instancja;
                    System.Console.Clear();
                    System.Console.WriteLine("Wybrałeś Maga!");
                }
                else if(wybranaProfesja == "S")
                {
                    profesja = "Strzelec";
                    postać = Strzelec.Instancja;
                    System.Console.Clear();
                    System.Console.WriteLine("Wybrałeś Strzelca!");
                }
                else
                {
                    System.Console.WriteLine("Wybierz poprawną profesję");
                    poprawnyWybór = false;
                }
            }

        }
   
        
        private void WybórNowegoMiejsca()
        {
            foreach(Miejsce miejsce in mapa[obecneMiejsce])
            {
                System.Console.Write($"[{ miejsce.Nazwa }] ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine($"Wybierz, które miejsce chcesz następnie odwiedzić (1-{ mapa[obecneMiejsce].Count })");

            bool poprawnyWybór = false;
            while(!poprawnyWybór)
            {
                poprawnyWybór = true;
                string? noweMiejsce = System.Console.ReadLine();
                noweMiejsce?.Trim();

                int wybór;
                try
                {
                    wybór = Convert.ToInt32(noweMiejsce);
                }
                catch
                {
                    System.Console.WriteLine("Wybierz poprawne miejsce");
                    poprawnyWybór = false;
                    continue;
                }

                if(wybór < 1 || wybór > mapa[obecneMiejsce].Count)
                {
                    System.Console.WriteLine("Wybierz poprawne miejsce");
                    poprawnyWybór = false;
                    continue;
                }

                obecneMiejsce = mapa[obecneMiejsce][wybór - 1];
                GraLoop();
            }
        }
    
        private void WybórKolejnejAkcji()
        {
            while(true)
            {
                System.Console.WriteLine("Wybierz:");
                System.Console.WriteLine("M - jeśli chcesz przejść do nowego miejsca");
                System.Console.WriteLine("E - jeśli chcesz zobaczyć swój ekwipunek");
                System.Console.WriteLine("S - jeśli chcesz zobaczyć swoje statystyki");
                System.Console.WriteLine("P - jeśli chcesz napić się mikstury");

                string? akcja = System.Console.ReadLine();
                akcja = akcja?.Trim();

                if(akcja == "M") //zmiana miejsca
                {
                    WybórNowegoMiejsca();
                    return;
                }
                else if(akcja == "E") //pokazanie ekwipunku
                {
                    System.Console.Clear();
                    postać.PokażEkwipunek();
                    System.Console.WriteLine($"Masz { postać.plecak?.Count }/{ postać.pojemnośćPlecaka } przedmiotów w ekwipunku");

                    if(postać.plecak?.Count == 0)
                    {
                        continue;
                    }

                    System.Console.WriteLine($"Wybierz przedmiot ({ 1 }-{ postać.plecak?.Count }) by zobaczyć jego statystyki lub coś innego by wyjść");

                    try
                    {
                        int wybór = Convert.ToInt32(System.Console.ReadLine().Trim());
                        if(wybór >= 1 && wybór <= postać.plecak?.Count)
                        {
                            postać.plecak?[wybór - 1].PokażStatystyki();
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                else if(akcja == "S") //pokazanie statystyk
                {
                    System.Console.Clear();
                    postać.PokażStatystyki();
                }
                else if(akcja == "P") //pokazanie mikstur
                {
                    System.Console.Clear();
                    if(postać.mikstury.Count == 0)
                    {
                        System.Console.WriteLine("Nie masz mikstur");
                        continue;
                    }

                    System.Console.WriteLine($"Masz { postać.mikstury.Count } mikstur:");
                    postać.PokażMikstury();
                    System.Console.WriteLine($"Wybierz miksturę ({ postać.mikstury.Count }), którą chcesz użyć lub coś innego by wyjść");
                    try
                    {
                        int wybór = Convert.ToInt32(System.Console.ReadLine().Trim());
                        if(wybór >= 1 && wybór <= postać.mikstury.Count)
                        {
                            postać.WypijMiksturę(wybór - 1);
                            postać.mikstury.RemoveAt(wybór - 1);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Wybierz poprawną akcję");
                }
            }
            }

        private void ZaładujDruida()
        {
            Druid.DodajMiksturę(100, 50, "Mała Mikstura");
            Druid.DodajMiksturę(250, 100, "Średnia Mikstura");
            Druid.DodajMiksturę(600, 200, "Duża Mikstura");
        }

        private void ZaładujHandlarza()
        {
            if(profesja == "Wojownik")
            {
                ZaładujHandlarzaWojownik();
            }
            else if(profesja == "Mag")
            {
                ZaładujHandlarzaMag();
            }
            else if(profesja == "Strzelec")
            {
                ZaładujHandlarzaStrzelec();
            }
        }

        private void ZaładujHandlarzaWojownik()
        {
            UzbrojenieWojownikaFabryka fabryka = new UzbrojenieWojownikaFabryka();

            //dodanie broni
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Klasyczny Miecz", new StatystykiWojownika(0, 300, 0, -2, 0, 0), 500, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Potężny Miecz", new StatystykiWojownika(0, 500, 0, -5, 0, 10), 1000, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Miecz Wojownika", new StatystykiWojownika(0, 1000, 0, -10, 0, 25), 2500, 20));

            //dodanie butów
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Skórzane Buty Początkującego", new StatystykiWojownika(40, 0, 30, 0, 8, 0), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Solidne Buty", new StatystykiWojownika(70, 0, 80, 0, 15, 0), 700, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Buty Wojownika", new StatystykiWojownika(150, 0, 120, 0, 25, 0), 1500, 10));

            //dodanie spodni
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Skórzane Spodnie Początkującego", new StatystykiWojownika(80, 0, 25, 0, 5, 0), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Solidne Spodnie", new StatystykiWojownika(200, 0, 50, 0, 15, 0), 800, 7));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Wojownika", new StatystykiWojownika(500, 0, 75, 0, 40, 0), 1800, 15));

            //dodanie zbroji
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Skórzana Zbroja Początkującego", new StatystykiWojownika(250, 0, 50, 0, 25, 0), 600, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Solidna Zbroja", new StatystykiWojownika(700, 0, 100, 0, 50, 0), 1500, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Zbroja Wojownika", new StatystykiWojownika(1500, 0, 200, 0, 100, 0), 3000, 20));

            //dodanie hełmów
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Skórzany Hełm Początkującego", new StatystykiWojownika(100, 0, 20, 0, 5, 0), 200, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Soldiny Hełm", new StatystykiWojownika(300, 0, 30, 0, 10, 0), 500, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Skórzany Hełm Początkującego", new StatystykiWojownika(800, 0, 150, 0, 20, 0), 1200, 10));  
        }

        private void ZaładujHandlarzaMag()
        {
            UzbrojenieMagaFabryka fabryka = new UzbrojenieMagaFabryka();

            //dodanie broni
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Klasyczna Różdżka", new StatystykiMaga(0, 0, 0, -5, 500, 10), 500, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Różdżka Mądrości", new StatystykiMaga(0, 0, 0, -10, 800, 25), 1000, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Różdżka Doświadczonego Maga", new StatystykiMaga(0, 0, 0, -10, 2000, 25), 2500, 20));

            //dodanie butów
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Szmaciane Buty Początkującego", new StatystykiMaga(24, 0, 18, 0, 0, 8), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Buty Mądrości", new StatystykiMaga(42, 0, 48, 0, 0, 15), 700, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Buty Doświadczonego Maga", new StatystykiMaga(90, 0, 72, 0, 0, 25), 1500, 10));

            //dodanie spodni
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Szmaciane Spodnie Początkującego", new StatystykiMaga(80, 0, 25, 0, 0, 5), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Mądrości", new StatystykiMaga(120, 0, 30, 0, 0, 15), 800, 7));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Doświadczonego Maga", new StatystykiMaga(300, 0, 45, 0, 0, 40), 1800, 15));

            //dodanie zbroji
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Skórzany Płaszcz Początkującego", new StatystykiMaga(90, 0, 30, 0, 0, 15), 600, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Płaszcz Mądrości", new StatystykiMaga(420, 0, 60, 0, 0, 25), 1500, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Płaszcz Doświadczonego Maga", new StatystykiMaga(900, 0, 200, 0, 0, 50), 3000, 20));

            //dodanie hełmów
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Skórzany Kaptur Początkującego", new StatystykiMaga(60, 0, 20, 0, 0, 5), 200, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Kaptur Mądrości", new StatystykiMaga(180, 0, 30, 0, 0, 30), 500, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Kaptur Doświadczonego Maga", new StatystykiMaga(480, 0, 50, 0, 0, 15), 1200, 10));  
        }

        private void ZaładujHandlarzaStrzelec()
        {
            UzbrojenieStrzelcaFabryka fabryka = new UzbrojenieStrzelcaFabryka();

            //dodanie broni
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Klasyczny Łuk", new StatystykiStrzelca(400, 0, 0, -1, 10, 20), 500, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Bardzo Celny Łuk", new StatystykiStrzelca(700, 0, 0, -3, 30, 30), 1000, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzBroń("Łyk Doświadczonego Strzelca", new StatystykiStrzelca(1500, 0, 0, -5, 50, 50), 2500, 20));

            //dodanie butów
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Szmaciane Buty Strzelca", new StatystykiStrzelca(40, 0, 25, 0, 0, 8), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Buty Strzelca", new StatystykiStrzelca(50, 0, 55, 0, 0, 15), 700, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzButy("Buty Doświadczonego Strzelca", new StatystykiStrzelca(120, 0, 80, 0, 0, 35), 1500, 10));

            //dodanie spodni
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Początkującego Strzelca", new StatystykiStrzelca(120, 0, 30, 0, 0, 2), 300, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Strzelca", new StatystykiStrzelca(160, 0, 35, 0, 0, 5), 800, 7));
            Handlarz.DodajPrzedmiot(fabryka.StwórzSpodnie("Spodnie Doświadczonego Strzelca", new StatystykiStrzelca(350, 0, 55, 0, 0, 10), 1800, 15));

            //dodanie zbroji
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Kolczuga Początkującego", new StatystykiStrzelca(250, 0, 35, 0, 0, 5), 600, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Solidna Kolczuga", new StatystykiStrzelca(500, 0, 80, 0, 0, 10), 1500, 10));
            Handlarz.DodajPrzedmiot(fabryka.StwórzZbroję("Kolczuga Doświadczonego Strzelca", new StatystykiStrzelca(1000, 0, 120, 0, 0, 15), 3000, 20));

            //dodanie hełmów
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Lekki Hełm Początkującego", new StatystykiStrzelca(70, 0, 25, 0, 0, 2), 200, 1));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Solidny Lekki Hełm", new StatystykiStrzelca(220, 0, 40, 0, 0, 6), 500, 5));
            Handlarz.DodajPrzedmiot(fabryka.StwórzHełm("Hełm Doświadczonego Strzelca", new StatystykiStrzelca(550, 0, 60, 0, 0, 8), 1200, 10));  
        }

        private void SpotkanieHandlarza()
        {
            System.Console.WriteLine("Na Rynku Głównym kręci się handlarz, który sprzedaje uzbrojenie.");
            System.Console.WriteLine("Czy chcesz do niego wstąpić?(TAK/NIE.)");

            string wybór = System.Console.ReadLine().Trim();

            while(wybór == "TAK" || wybór == "T")
            {
                System.Console.WriteLine("Podchodzisz do handlarza.");
                System.Console.WriteLine("Wybierz K by coś kupić, S by coś sprzedać lub coś innego by wyjść.");
                string akcja = System.Console.ReadLine().Trim();
                if(akcja == "K")
                {
                    Handlarz.PokażTowary();
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Wybierz, który przedmiot(1-{ Handlarz.liczbaPrzedmiotów }) chcesz kupić lub coś innego by wyjść.");

                    try
                    {
                        int wybranyPrzedmiot = Convert.ToInt32(System.Console.ReadLine().Trim());
                        if(wybranyPrzedmiot >= 1 && wybranyPrzedmiot <= Handlarz.liczbaPrzedmiotów)
                        {
                            if(postać.złoto >= Handlarz.przedmioty[wybranyPrzedmiot - 1].koszt)
                            {
                                if(postać.plecak.Count < postać.pojemnośćPlecaka)
                                {
                                    postać.złoto -= Handlarz.przedmioty[wybranyPrzedmiot - 1].koszt;
                                    postać.DodajPrzedmiot(Handlarz.przedmioty[wybranyPrzedmiot - 1]);
                                }
                                else
                                {
                                    System.Console.WriteLine("Nie masz wystarczająco dużo miejsca w plecaku, by kupić ten przedmiot.");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("Nie masz wystarczająco dużo złota, by kupić ten przedmiot.");
                            }
                        }
                    }
                    finally
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Czy chcesz jeszcze coś kupić lub sprzedać?(TAK/NIE).");
                        wybór = System.Console.ReadLine().Trim();
                    }
                }
                else if(akcja == "S")
                {
                    if(postać.plecak.Count <= 0)
                    {
                        System.Console.WriteLine("Nie masz żadnych przedmiotów w ekwipunku.");
                        break;
                    }
                    postać.PokażEkwipunek();
                    System.Console.WriteLine($"Wybierz przedmiot(1 - { postać.plecak.Count }), który chcesz sprzedać lub coś innego by wyjść.");
                    
                    try
                    {
                        int wybranyPrzedmiot = Convert.ToInt32(System.Console.ReadLine().Trim());
                        if(wybranyPrzedmiot >= 1 && wybranyPrzedmiot <= postać.plecak.Count)
                        {
                            postać.złoto += postać.plecak[wybranyPrzedmiot - 1].koszt;
                            postać.plecak.RemoveAt(wybranyPrzedmiot - 1);
                        }
                    }
                    finally
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Czy chcesz jeszcze coś kupić lub sprzedać?(TAK/NIE).");
                        wybór = System.Console.ReadLine().Trim();
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
