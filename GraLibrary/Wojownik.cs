namespace GraLibrary
{
    public class Wojownik : Postać
    {
        private Wojownik()
        {
            statystykiBazowe = new StatystykiWojownika(500, 100, 200, 0, 10, 0);
            statystyki = new StatystykiWojownika(500, 100, 200, 0, 10, 0);
            zdrowie = 500;
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.WOJOWNIK;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 10;
            mikstury = new List<Mikstura>();
        }

        public static Wojownik Instancja
        {
            get
            {
                if(instancja == null)
                {
                    instancja = new Wojownik();
                }
                return (Wojownik)instancja;
            }
        }

        public override void WbiciePoziomu()
        {
            while(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystykiBazowe.punktyZdrowia += 100;
                statystykiBazowe.atakFizyczny += 20;
                statystykiBazowe.obrona += 50;
                ((StatystykiWojownika)statystykiBazowe).wytrzymałość += 5;
                System.Console.WriteLine("Udało ci się zdobyć kolejny poziom!");
            }
            PrzeliczStatystyki();
            zdrowie = statystyki.punktyZdrowia;
        }

        public override void PokażStatystyki()
        {
            System.Console.WriteLine("Twoje Statystyki:");
            System.Console.WriteLine($"Zdrowie: { zdrowie }/{ statystyki.punktyZdrowia }");
            System.Console.WriteLine($"Atak Fizyczny: { statystyki.atakFizyczny }");
            System.Console.WriteLine($"Obrona: { statystyki.obrona }");
            System.Console.WriteLine($"Szczęście: { statystyki.szczęście }");
            System.Console.WriteLine($"Wytrzymałość: { ((StatystykiWojownika)statystyki).wytrzymałość }");
            System.Console.WriteLine($"Szansa na cios krytyczny: { ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny }");
            System.Console.WriteLine($"Złoto: { złoto }");
        }
        
        public override void Walka(Przeciwnik przeciwnik)
        {
            while (zdrowie > 0 && przeciwnik.statystyki.punktyZdrowia > 0)
            {
                Random random = new Random();
                int dodatkowePunkty = random.Next(0, statystyki.szczęście);
                int dodatkowePunktyPrzeciwnik = random.Next(0, przeciwnik.statystyki.szczęście);
                int wylosowanaLiczba = random.Next(1, 100);

                int zadaneObrażenia = (int)(statystyki.atakFizyczny * 2) *
                                      (1 + (dodatkowePunkty / 100));
                if (((StatystykiWojownika) statystyki).szansaNaCiosKrytyczny >= wylosowanaLiczba)
                {
                    zadaneObrażenia *= 2;
                }
                int rzeczywisteZadaneObrażenia = zadaneObrażenia - przeciwnik.statystyki.obrona * 
                                         (1+ dodatkowePunktyPrzeciwnik/100);
                zadaneObrażenia = Math.Max(zadaneObrażenia / 2, rzeczywisteZadaneObrażenia);


                przeciwnik.statystyki.punktyZdrowia -= zadaneObrażenia;
                Console.WriteLine($"Zadałeś { zadaneObrażenia } obrażeń. Pozostałe zdrowie przeciwnika: { przeciwnik.statystyki.punktyZdrowia }");
                if (przeciwnik.statystyki.punktyZdrowia <= 0) break;

                int otrzymaneObrażenia = (int)(przeciwnik.statystyki.atakFizyczny * 2.5) *
                                         (1 + (dodatkowePunkty / 100));
                int rzeczywisteOtrzymaneObrażenia = otrzymaneObrażenia - statystyki.obrona * 
                                         (1 + (((StatystykiWojownika)statystyki).wytrzymałość + dodatkowePunkty)/100);
                otrzymaneObrażenia = Math.Max(otrzymaneObrażenia / 2, rzeczywisteOtrzymaneObrażenia);
                zdrowie -= otrzymaneObrażenia;
                Console.WriteLine($"Otrzymałeś { otrzymaneObrażenia } obrażeń. Pozostałe zdrowie: { zdrowie }");
            }
        }

        public override void PrzeliczStatystyki()
        {
            int najwyższyPoziom;
            //broń
            Broń najlepszaBroń = null;
            najwyższyPoziom = 0;
            foreach(Przedmiot przedmiot in plecak)
            {
                if(przedmiot.GetType() == typeof(Broń))
                {   
                    if(przedmiot.wymaganyPoziom <= poziom && przedmiot.wymaganyPoziom > najwyższyPoziom)
                    {
                        najlepszaBroń = (Broń)przedmiot;
                        najwyższyPoziom = przedmiot.wymaganyPoziom;
                    }
                }
            }

            //Buty
            Buty najlepszeButy = null;
            najwyższyPoziom = 0;
            foreach(Przedmiot przedmiot in plecak)
            {
                if(przedmiot.GetType() == typeof(Buty))
                {   
                    if(przedmiot.wymaganyPoziom <= poziom && przedmiot.wymaganyPoziom > najwyższyPoziom)
                    {
                        najlepszeButy = (Buty)przedmiot;
                        najwyższyPoziom = przedmiot.wymaganyPoziom;
                    }
                }
            }

            //Spodnie
            Spodnie najlepszeSpodnie = null;
            najwyższyPoziom = 0;
            foreach(Przedmiot przedmiot in plecak)
            {
                if(przedmiot.GetType() == typeof(Spodnie))
                {   
                    if(przedmiot.wymaganyPoziom <= poziom && przedmiot.wymaganyPoziom > najwyższyPoziom)
                    {
                        najlepszeSpodnie = (Spodnie)przedmiot;
                        najwyższyPoziom = przedmiot.wymaganyPoziom;
                    }
                }
            }

            //Zbroja
            Zbroja najlepszaZbroja = null;
            najwyższyPoziom = 0;
            foreach(Przedmiot przedmiot in plecak)
            {
                if(przedmiot.GetType() == typeof(Zbroja))
                {   
                    if(przedmiot.wymaganyPoziom <= poziom && przedmiot.wymaganyPoziom > najwyższyPoziom)
                    {
                        najlepszaZbroja = (Zbroja)przedmiot;
                        najwyższyPoziom = przedmiot.wymaganyPoziom;
                    }
                }
            }

            //Hełm
            Hełm najlepszyHełm = null;
            najwyższyPoziom = 0;
            foreach(Przedmiot przedmiot in plecak)
            {
                if(przedmiot.GetType() == typeof(Hełm))
                {   
                    if(przedmiot.wymaganyPoziom <= poziom && przedmiot.wymaganyPoziom > najwyższyPoziom)
                    {
                        najlepszyHełm = (Hełm)przedmiot;
                        najwyższyPoziom = przedmiot.wymaganyPoziom;
                    }
                }
            }


            //aktualizacja statystyk - wlicza się tylko najlepszy przedmiot
            statystyki.punktyZdrowia = statystykiBazowe.punktyZdrowia;
            statystyki.atakFizyczny = statystykiBazowe.atakFizyczny;
            statystyki.obrona = statystykiBazowe.obrona;
            statystyki.szczęście = statystykiBazowe.szczęście;
            ((StatystykiWojownika)statystyki).wytrzymałość = ((StatystykiWojownika)statystykiBazowe).wytrzymałość;
            ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny = ((StatystykiWojownika)statystykiBazowe).szansaNaCiosKrytyczny;

            if(najlepszaBroń != null)
            {
                statystyki.punktyZdrowia += najlepszaBroń.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaBroń.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaBroń.statystyki.obrona;
                statystyki.szczęście += najlepszaBroń.statystyki.szczęście;
                ((StatystykiWojownika)statystyki).wytrzymałość += ((StatystykiWojownika)najlepszaBroń.statystyki).wytrzymałość;
                ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny += ((StatystykiWojownika)najlepszaBroń.statystyki).szansaNaCiosKrytyczny;
            }

            if(najlepszeButy != null)
            {
                statystyki.punktyZdrowia += najlepszeButy.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeButy.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeButy.statystyki.obrona;
                statystyki.szczęście += najlepszeButy.statystyki.szczęście;
                ((StatystykiWojownika)statystyki).wytrzymałość += ((StatystykiWojownika)najlepszeButy.statystyki).wytrzymałość;
                ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny += ((StatystykiWojownika)najlepszeButy.statystyki).szansaNaCiosKrytyczny;
            }

            if(najlepszeSpodnie != null)
            {
                statystyki.punktyZdrowia += najlepszeSpodnie.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeSpodnie.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeSpodnie.statystyki.obrona;
                statystyki.szczęście = najlepszeSpodnie.statystyki.szczęście;
                ((StatystykiWojownika)statystyki).wytrzymałość += ((StatystykiWojownika)najlepszeSpodnie.statystyki).wytrzymałość;
                ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny += ((StatystykiWojownika)najlepszeSpodnie.statystyki).szansaNaCiosKrytyczny;
            }

            if(najlepszaZbroja != null)
            {  
                statystyki.punktyZdrowia += najlepszaZbroja.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaZbroja.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaZbroja.statystyki.obrona;
                statystyki.szczęście += najlepszaZbroja.statystyki.szczęście;
                ((StatystykiWojownika)statystyki).wytrzymałość += ((StatystykiWojownika)najlepszaZbroja.statystyki).wytrzymałość;
                ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny += ((StatystykiWojownika)najlepszaZbroja.statystyki).szansaNaCiosKrytyczny;
            }

            if(najlepszyHełm != null)
            {
                statystyki.punktyZdrowia += najlepszyHełm.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszyHełm.statystyki.atakFizyczny;
                statystyki.obrona += najlepszyHełm.statystyki.obrona;
                statystyki.szczęście += najlepszyHełm.statystyki.szczęście;
                ((StatystykiWojownika)statystyki).wytrzymałość += ((StatystykiWojownika)najlepszyHełm.statystyki).wytrzymałość;
                ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny += ((StatystykiWojownika)najlepszyHełm.statystyki).szansaNaCiosKrytyczny;
            }

            zdrowie = Math.Min(zdrowie, statystyki.punktyZdrowia);

        }
        
    }
}