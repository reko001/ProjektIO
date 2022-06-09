namespace GraLibrary
{
    public class StatystykiMaga : Statystyki
    {
        public int atakMagiczny;
        public int mądrość;

        public StatystykiMaga(int pz, int af, int o, int s, int am, int m) : base(pz, af, o, s)
        {
            atakMagiczny = am;
            mądrość = m;
        }
    }
}