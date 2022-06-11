namespace GraLibrary
{
    public class Przeciwnik
    {
        public Statystyki statystyki;
        public int poziom;

        public Przeciwnik(int punktyZdrowia, int atakFizyczny, int obrona, int poziom)
        {
            statystyki = new Statystyki(punktyZdrowia, atakFizyczny, obrona, 0);
            this.poziom = poziom;
        }
    }
}