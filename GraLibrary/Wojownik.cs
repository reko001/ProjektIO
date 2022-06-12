namespace GraLibrary
{
    public class Wojownik : Postać
    {
        private Wojownik()
        {
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
                statystyki.punktyZdrowia += 100;
                zdrowie = statystyki.punktyZdrowia;
                statystyki.atakFizyczny += 20;
                statystyki.obrona += 50;
                ((StatystykiWojownika)statystyki).wytrzymałość += 5;
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
            System.Console.WriteLine($"Wytrzymałość: { ((StatystykiWojownika)statystyki).wytrzymałość }");
            System.Console.WriteLine($"Szansa na cios krytyczny: { ((StatystykiWojownika)statystyki).szansaNaCiosKrytyczny }");
            
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
        
    }
}