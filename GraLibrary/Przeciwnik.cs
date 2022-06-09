namespace GraLibrary
{
    public class Przeciwnik
    {
        public Statystyki statystyki;
        public int poziom;

        public Przeciwnik(int pz, int af, int o, int p)
        {
            statystyki = new Statystyki(pz, af, o, 0);
            poziom = p;
        }
    }
}