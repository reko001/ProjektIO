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

        public static  Mag Instancja
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
    }
}