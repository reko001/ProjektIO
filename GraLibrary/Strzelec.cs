namespace GraLibrary
{
    public class Strzelec : Postać
    {
        private Strzelec()
        {
            statystykiBazowe = new StatystykiStrzelca(400, 50, 1000, 0, -50, 0);
            statystyki = new StatystykiStrzelca(400, 50, 1000, 0, -50, 0);
            zdrowie = 400;
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.STRZELEC;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 8;
            mikstury = new List<Mikstura>();
        }

        public static Strzelec Instancja
        {
            get
            {
                if(instancja == null)
                {
                    instancja = new Strzelec();
                }
                return (Strzelec)instancja;
            }
        }

        public override void WbiciePoziomu()
        {
            while(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystykiBazowe.punktyZdrowia += 70;
                statystykiBazowe.atakFizyczny += 10;
                statystykiBazowe.obrona += 60;
                ((StatystykiStrzelca)statystykiBazowe).celność += 20;
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
            System.Console.WriteLine($"Celność: { ((StatystykiStrzelca)statystyki).celność }");
            System.Console.WriteLine($"Zwinność: { ((StatystykiStrzelca)statystyki).zwinność }");
            System.Console.WriteLine($"Złoto: { złoto }");
        }
        
        public override void Walka(Przeciwnik przeciwnik)
        {
            while (zdrowie > 0 && przeciwnik.statystyki.punktyZdrowia > 0)
            {
                Random random = new Random();
                int dodatkowePunkty = random.Next(0, statystyki.szczęście);
                int dodatkowePunktyPrzeciwnik = random.Next(0, przeciwnik.statystyki.szczęście);
                
                int zadaneObrażenia = (int)(statystyki.atakFizyczny*2) *(1 + (((StatystykiStrzelca)statystyki).celność +
                                         ((StatystykiStrzelca)statystyki).zwinność + dodatkowePunkty) / 100);
                int rzeczywisteZadaneObrażenia = zadaneObrażenia - przeciwnik.statystyki.obrona *
                                         (1 +  dodatkowePunktyPrzeciwnik/100);
                zadaneObrażenia = Math.Max(zadaneObrażenia / 2, rzeczywisteZadaneObrażenia);

                przeciwnik.statystyki.punktyZdrowia -= zadaneObrażenia;
                Console.WriteLine($"Zadałeś { zadaneObrażenia } obrażeń. Pozostałe zdrowie przeciwnika: { przeciwnik.statystyki.punktyZdrowia }");
                if (przeciwnik.statystyki.punktyZdrowia <= 0) break;

                int otrzymaneObrażenia = (int)(przeciwnik.statystyki.atakFizyczny * 2.5) *
                                         (1 + (dodatkowePunktyPrzeciwnik / 100));
                int rzeczywisteOtrzymaneObrażenia = otrzymaneObrażenia - statystyki.obrona *
                                         (1 + (((StatystykiStrzelca)statystyki).zwinność + dodatkowePunkty)/100);
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
            ((StatystykiStrzelca)statystyki).celność = ((StatystykiStrzelca)statystykiBazowe).celność;
            ((StatystykiStrzelca)statystyki).zwinność = ((StatystykiStrzelca)statystykiBazowe).zwinność;

            if(najlepszaBroń != null)
            {
                statystyki.punktyZdrowia += najlepszaBroń.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaBroń.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaBroń.statystyki.obrona;
                statystyki.szczęście += najlepszaBroń.statystyki.szczęście;
                ((StatystykiStrzelca)statystyki).celność += ((StatystykiStrzelca)najlepszaBroń.statystyki).celność;
                ((StatystykiStrzelca)statystyki).zwinność += ((StatystykiStrzelca)najlepszaBroń.statystyki).zwinność;
            }

            if(najlepszeButy != null)
            {
                statystyki.punktyZdrowia += najlepszeButy.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeButy.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeButy.statystyki.obrona;
                statystyki.szczęście += najlepszeButy.statystyki.szczęście;
                ((StatystykiStrzelca)statystyki).celność += ((StatystykiStrzelca)najlepszeButy.statystyki).celność;
                ((StatystykiStrzelca)statystyki).zwinność += ((StatystykiStrzelca)najlepszeButy.statystyki).zwinność;
            }

            if(najlepszeSpodnie != null)
            {
                statystyki.punktyZdrowia += najlepszeSpodnie.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeSpodnie.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeSpodnie.statystyki.obrona;
                statystyki.szczęście += najlepszeSpodnie.statystyki.szczęście;
                ((StatystykiStrzelca)statystyki).celność += ((StatystykiStrzelca)najlepszeSpodnie.statystyki).celność;
                ((StatystykiStrzelca)statystyki).zwinność += ((StatystykiStrzelca)najlepszeSpodnie.statystyki).zwinność;
            }

            if(najlepszaZbroja != null)
            {  
                statystyki.punktyZdrowia += najlepszaZbroja.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaZbroja.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaZbroja.statystyki.obrona;
                statystyki.szczęście += najlepszaZbroja.statystyki.szczęście;
                ((StatystykiStrzelca)statystyki).celność += ((StatystykiStrzelca)najlepszaZbroja.statystyki).celność;
                ((StatystykiStrzelca)statystyki).zwinność += ((StatystykiStrzelca)najlepszaZbroja.statystyki).zwinność;
            }

            if(najlepszyHełm != null)
            {
                statystyki.punktyZdrowia += najlepszyHełm.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszyHełm.statystyki.atakFizyczny;
                statystyki.obrona += najlepszyHełm.statystyki.obrona;
                statystyki.szczęście += najlepszyHełm.statystyki.szczęście;
                ((StatystykiStrzelca)statystyki).celność += ((StatystykiStrzelca)najlepszyHełm.statystyki).celność;
                ((StatystykiStrzelca)statystyki).zwinność += ((StatystykiStrzelca)najlepszyHełm.statystyki).zwinność;
            }

            zdrowie = Math.Min(zdrowie, statystyki.punktyZdrowia);
        }
    }
}