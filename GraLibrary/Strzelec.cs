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
        
        public override void Walka(Przeciwnik przeciwnik)
        {
            while (zdrowie > 0 && przeciwnik.statystyki.punktyZdrowia > 0)
            {
                Random random = new Random();
                int dodatkowePunkty = random.Next(0, statystyki.szczęście);
                int dodatkowePunktyPrzeciwnik = random.Next(0, przeciwnik.statystyki.szczęście);
                
                int zadaneObrażenia = (int)(statystyki.atakFizyczny*2) * (1 + (((StatystykiStrzelca)statystyki).celność + ((StatystykiStrzelca)statystyki).zwinność + dodatkowePunkty) / 100);
                zadaneObrażenia -= przeciwnik.statystyki.obrona * (1 +  dodatkowePunktyPrzeciwnik/100);
                zadaneObrażenia = Math.Max(zadaneObrażenia, 0);

                przeciwnik.statystyki.punktyZdrowia -= zadaneObrażenia;
                Console.WriteLine($"Zadałeś { zadaneObrażenia } obrażeń. Pozostałe zdrowie przeciwnika: { przeciwnik.statystyki.punktyZdrowia }");
                if (przeciwnik.statystyki.punktyZdrowia <= 0) break;

                int otrzymaneObrażenia = (int)(przeciwnik.statystyki.atakFizyczny * 2.5) *
                                         (1 + (dodatkowePunktyPrzeciwnik / 100));
                otrzymaneObrażenia -= statystyki.obrona * (1 + (((StatystykiStrzelca)statystyki).zwinność + dodatkowePunkty)/100);
                otrzymaneObrażenia -= Math.Max(otrzymaneObrażenia, 0);
                zdrowie -= otrzymaneObrażenia;
                Console.WriteLine($"Otrzymałeś { otrzymaneObrażenia } obrażeń. Pozostałe zdrowie: { zdrowie }");
            }
        }
    }
}