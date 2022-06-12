namespace GraLibrary
{
    public class Mag : Postać
    {
        private Mag()
        {
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
                statystyki.punktyZdrowia += 60;
                zdrowie = statystyki.punktyZdrowia;
                statystyki.atakFizyczny += 10;
                statystyki.obrona += 30;
                ((StatystykiMaga)statystyki).atakMagiczny += 40;
                System.Console.WriteLine("Udało ci się zdobyć kolejny poziom!");
            }
        }

        public override void PokażStatystyki()
        {
            System.Console.WriteLine("Twoje Statystyki:");
            System.Console.WriteLine($"Zdrowie: { zdrowie }/{ statystyki.punktyZdrowia }");
            System.Console.WriteLine($"Atak Fizyczny: { statystyki.atakFizyczny }");
            System.Console.WriteLine($"Obrona: { statystyki.obrona }");
            System.Console.WriteLine($"Szczęście: { statystyki.szczęście }");
            System.Console.WriteLine($"Atak Magiczny: { ((StatystykiMaga)statystyki).atakMagiczny }");
            System.Console.WriteLine($"Atak Fizyczny: { ((StatystykiMaga)statystyki).mądrość }");
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
    }
}