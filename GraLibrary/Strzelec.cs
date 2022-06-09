namespace GraLibrary
{
    public class Strzelec : Postać
    {
        private Strzelec()
        {
            statystyki = new StatystykiStrzelca(400, 50, 1000, 0, -50, 0);
            złoto = 1000;
            poziom = 1;
            doświadczenie = 0;
            profesja = Profesja.STRZELEC;
            plecak = new List<Przedmiot>();
            pojemnośćPlecaka = 8;
        }

        public override Strzelec Instancja
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
            if(doświadczenie >= 100)
            {
                poziom++;
                doświadczenie -= 100;
                statystyki.punktyZdrowia += 70;
                statystyki.atakFizyczny += 10;
                statystyki.obrona += 60;
                ((StatystykiStrzelca)statystyki).celność += 20;
            }
        }
    }
}