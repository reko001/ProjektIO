namespace GraLibrary
{
	public class StatystykiWojownika : Statystyki
	{
		public int wytrzymałość;
		public int szansaNaCiosKrytyczny;

		public StatystykiWojownika(int punktyZdrowia, int atakFizyczny, int obrona, int szczęście, int wytrzymałość, int szansaNaCiosKrytyczny) 
		: base(punktyZdrowia, atakFizyczny, obrona, szczęście)
		{
			this.wytrzymałość = wytrzymałość;
			this.szansaNaCiosKrytyczny = szansaNaCiosKrytyczny;
		}

		public new void WyświetlStatystyki()
        {
            base.WyświetlStatystyki();
            System.Console.WriteLine($"Wytrzymałość: { wytrzymałość }");
            System.Console.WriteLine($"Szansa na cios krytyczny: { szansaNaCiosKrytyczny }");
        }
	}
}