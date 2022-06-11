namespace GraLibrary
{
    public class StatystykiStrzelca : Statystyki
    {
        public int celność;
        public int zwinność;

        public StatystykiStrzelca(int pz, int af, int o, int s, int c, int z) : base(pz, af, o, s)
        {
            celność = c;
            zwinność = z;
        }

        public new void WyświetlStatystyki()
        {
            base.WyświetlStatystyki();
            System.Console.WriteLine($"Celność: { celność }");
            System.Console.WriteLine($"Zwinność: { zwinność }");
        }
    }
}