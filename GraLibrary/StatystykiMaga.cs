namespace GraLibrary
{
    public class StatystykiMaga : Statystyki
    {
        public int atakMagiczny;
        public int mądrość;

        public StatystykiMaga(int punktyZdrowia, int atakFizyczny, int obrona, int szczęście, int atakMagiczny, int mądrość)
        : base(punktyZdrowia, atakFizyczny, obrona, szczęście)
        {
            this.atakMagiczny = atakMagiczny;
            this.mądrość = mądrość;
        }

        public new void WyświetlStatystyki()
        {
            base.WyświetlStatystyki();
            System.Console.WriteLine($"Atak Magiczny: { atakMagiczny }");
            System.Console.WriteLine($"Mądrość: { mądrość }");
        }
    }
}