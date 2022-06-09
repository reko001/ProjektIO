namespace GraLibrary
{
    public class Mag : Postać
    {
        private Mag()
        {
            statystyki = new StatystykiWojownika(300, 50, 80, 0, 100, 0);
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.MAG;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 8;
        }

        public override Mag Instancja
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
            if(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystyki.punktyZdrowia += 60;
                statystyki.atakFizyczny += 10;
                statystyki.obrona += 30;
                ((StatystykiMaga)statystyki).atakMagiczny += 40;
            }
        }
    }
}