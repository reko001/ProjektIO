namespace GraLibrary
{
    public class Statystyki //podstawowe statystki
    {
        public int punktyZdrowia;
        public int atakFizyczny;
        public int obrona;
        public int szczęście;

        public Statystyki(int pz, int af, int o, int s)
        {
            punktyZdrowia = pz;
            atakFizyczny = af;
            obrona = o;
            szczęście = s;
        }
    }
}