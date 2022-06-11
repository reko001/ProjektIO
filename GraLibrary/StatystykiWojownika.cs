namespace GraLibrary
{
	public class StatystykiWojownika : Statystyki
	{
		public int wytrzymałość;
		public int szansaNaCiosKrytyczny;

		public StatystykiWojownika(int pz, int af, int o, int s, int w, int ck) : base(pz, af, o, s)
		{
			wytrzymałość = w;
			szansaNaCiosKrytyczny = ck;
		}

		public new void WyświetlStatystyki()
        {
            base.WyświetlStatystyki();
            System.Console.WriteLine($"Wytrzymałość: { wytrzymałość }");
            System.Console.WriteLine($"Szansa na cios krytyczny: { szansaNaCiosKrytyczny }");
        }
	}
}