namespace GraLibrary
{
    public class StatystykiStrzelca : Statystyki
    {
        public int celność;
        public int zwinność;

        public StatystykiStrzelca(int punktyZdrowia, int atakFizyczny, int obrona, int szczęście, int celność, int zwinność)
        : base(punktyZdrowia, atakFizyczny, obrona, szczęście)
        {
            this.celność = celność;
            this.zwinność = zwinność;
        }

        public new void WyświetlStatystyki()
        {
            base.WyświetlStatystyki();
            System.Console.WriteLine($"Celność: { celność }");
            System.Console.WriteLine($"Zwinność: { zwinność }");
        }
    }
}