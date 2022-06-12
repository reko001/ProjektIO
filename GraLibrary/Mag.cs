namespace GraLibrary
{
    public class Mag : Postać
    {
        private Mag()
        {
            statystykiBazowe = new StatystykiMaga(300, 50, 80, 0, 100, 0);
            statystyki = new StatystykiMaga(300, 50, 80, 0, 100, 0);
            zdrowie = 300;
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.MAG;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 8;
            mikstury = new List<Mikstura>();
        }

        public static Mag Instancja
        {
            get
            {
                if(instancja == null)
                {
                    instancja = new Mag();
                }
                return (Mag)instancja;
            }
        }

        public override void WbiciePoziomu()
        {
            while(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystykiBazowe.punktyZdrowia += 60;
                statystykiBazowe.atakFizyczny += 10;
                statystykiBazowe.obrona += 30;
                ((StatystykiMaga)statystykiBazowe).atakMagiczny += 40;
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
            System.Console.WriteLine($"Atak Magiczny: { ((StatystykiMaga)statystyki).atakMagiczny }");
            System.Console.WriteLine($"Mądrość: { ((StatystykiMaga)statystyki).mądrość }");
            System.Console.WriteLine($"Złoto: { złoto }");
        }


        public override void Walka(Przeciwnik przeciwnik)
        {
            while (zdrowie > 0 && przeciwnik.statystyki.punktyZdrowia > 0)
            {
                Random random = new Random();
                int dodatkowePunkty = random.Next(0, statystyki.szczęście);
                int dodatkowePunktyPrzeciwnik = random.Next(0, przeciwnik.statystyki.szczęście);
                
                int zadaneObrażenia = (int)(statystyki.atakFizyczny + ((StatystykiMaga) statystyki).atakMagiczny * 3) *
                                        (1 + ( ((StatystykiMaga) statystyki).mądrość + dodatkowePunkty )/ 100);
                int rzeczywisteZadaneObrażenia = zadaneObrażenia - przeciwnik.statystyki.obrona * 
                                        (1+ dodatkowePunktyPrzeciwnik/100);
                zadaneObrażenia = Math.Max(zadaneObrażenia / 2, rzeczywisteZadaneObrażenia);

                przeciwnik.statystyki.punktyZdrowia -= zadaneObrażenia;
                Console.WriteLine($"Zadałeś { zadaneObrażenia } obrażeń. Pozostałe zdrowie przeciwnika: { przeciwnik.statystyki.punktyZdrowia }");
                if (przeciwnik.statystyki.punktyZdrowia <= 0) break;

                int otrzymaneObrażenia = (int)(przeciwnik.statystyki.atakFizyczny * 2.5) *
                                         (1 + (dodatkowePunktyPrzeciwnik / 100));
                int rzeczywisteOtrzymaneObrażenia = otrzymaneObrażenia - statystyki.obrona * (1+ dodatkowePunkty/100);
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
            ((StatystykiMaga)statystyki).atakMagiczny = ((StatystykiMaga)statystykiBazowe).atakMagiczny;
            ((StatystykiMaga)statystyki).mądrość = ((StatystykiMaga)statystykiBazowe).mądrość;

            if(najlepszaBroń != null)
            {
                statystyki.punktyZdrowia += najlepszaBroń.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaBroń.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaBroń.statystyki.obrona;
                statystyki.szczęście += najlepszaBroń.statystyki.szczęście;
                ((StatystykiMaga)statystyki).atakMagiczny += ((StatystykiMaga)najlepszaBroń.statystyki).atakMagiczny;
                ((StatystykiMaga)statystyki).mądrość += ((StatystykiMaga)najlepszaBroń.statystyki).mądrość;
            }

            if(najlepszeButy != null)
            {
                statystyki.punktyZdrowia += najlepszeButy.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeButy.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeButy.statystyki.obrona;
                statystyki.szczęście += najlepszeButy.statystyki.szczęście;
                ((StatystykiMaga)statystyki).atakMagiczny += ((StatystykiMaga)najlepszeButy.statystyki).atakMagiczny;
                ((StatystykiMaga)statystyki).mądrość += ((StatystykiMaga)najlepszeButy.statystyki).mądrość;
            }

            if(najlepszeSpodnie != null)
            {
                statystyki.punktyZdrowia += najlepszeSpodnie.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszeSpodnie.statystyki.atakFizyczny;
                statystyki.obrona += najlepszeSpodnie.statystyki.obrona;
                statystyki.szczęście += najlepszeSpodnie.statystyki.szczęście;
                ((StatystykiMaga)statystyki).atakMagiczny += ((StatystykiMaga)najlepszeSpodnie.statystyki).atakMagiczny;
                ((StatystykiMaga)statystyki).mądrość += ((StatystykiMaga)najlepszeSpodnie.statystyki).mądrość;
            }

            if(najlepszaZbroja != null)
            {  
                statystyki.punktyZdrowia += najlepszaZbroja.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszaZbroja.statystyki.atakFizyczny;
                statystyki.obrona += najlepszaZbroja.statystyki.obrona;
                statystyki.szczęście += najlepszaZbroja.statystyki.szczęście;
                ((StatystykiMaga)statystyki).atakMagiczny += ((StatystykiMaga)najlepszaZbroja.statystyki).atakMagiczny;
                ((StatystykiMaga)statystyki).mądrość += ((StatystykiMaga)najlepszaZbroja.statystyki).mądrość;
            }

            if(najlepszyHełm != null)
            {
                statystyki.punktyZdrowia += najlepszyHełm.statystyki.punktyZdrowia;
                statystyki.atakFizyczny += najlepszyHełm.statystyki.atakFizyczny;
                statystyki.obrona += najlepszyHełm.statystyki.obrona;
                statystyki.szczęście += najlepszyHełm.statystyki.szczęście;
                ((StatystykiMaga)statystyki).atakMagiczny += ((StatystykiMaga)najlepszyHełm.statystyki).atakMagiczny;
                ((StatystykiMaga)statystyki).mądrość += ((StatystykiMaga)najlepszyHełm.statystyki).mądrość;
            }

            zdrowie = Math.Min(zdrowie, statystyki.punktyZdrowia);
        }
    }

}