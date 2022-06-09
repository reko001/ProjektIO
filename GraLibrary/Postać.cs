namespace GraLibrary
{
    public abstract class Postać
    {
        protected static Postać? instancja;

        public Statystyki? statystyki;
        public int złoto;
        public int poziom;
        public int doświadczenie;
        public Profesja profesja;
        public List<Przedmiot>? plecak;

        public int pojemnośćPlecaka;

        public abstract Postać Instancja { get; }

        public void Walka(Przeciwnik przeciwnik)
        {

        }

        public abstract void WbiciePoziomu();
    }
}