namespace GraLibrary
{
    public class Wojownik : Postać
    {
        private Wojownik()
        {
            statystyki = new StatystykiWojownika(500, 100, 200, 0, 10, 0);
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.WOJOWNIK;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 10;
        }

        public override Wojownik Instancja
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
            if(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystyki.punktyZdrowia += 100;
                statystyki.atakFizyczny += 20;
                statystyki.obrona += 50;
                ((StatystykiWojownika)statystyki).wytrzymałość += 5;
            }
        }
    }
}