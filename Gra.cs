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

            System.Console.WriteLine($"{profesja}: { postać.poziom } Level { postać.doświadczenie }/100 EXP  Złoto: { postać.złoto }");
            System.Console.WriteLine();
            System.Console.WriteLine($"Znajdujesz się obecnie w { obecneMiejsce.Nazwa }");

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

    }
}