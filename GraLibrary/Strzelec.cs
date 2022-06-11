namespace GraLibrary
{
    public class Strzelec : Postać
    {
        private Strzelec()
        {
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
                statystyki.punktyZdrowia += 70;
                zdrowie = statystyki.punktyZdrowia;
                statystyki.atakFizyczny += 10;
                statystyki.obrona += 60;
                ((StatystykiStrzelca)statystyki).celność += 20;
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
            System.Console.WriteLine($"Celność: { ((StatystykiStrzelca)statystyki).celność }");
            System.Console.WriteLine($"Zwinność: { ((StatystykiStrzelca)statystyki).zwinność }");
            
        }
    }
}