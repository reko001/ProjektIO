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
    }
}