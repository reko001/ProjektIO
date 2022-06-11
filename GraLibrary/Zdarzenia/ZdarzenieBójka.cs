namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieBójka : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Zostałeś zaczepiony przez grupkę nietrzeźwych marynarzy");
            System.Console.WriteLine("Jeden z nich zaczyna cię obrażać. Wszczynasz bójkę.");

            Przeciwnik pijaniMarynarze = new Przeciwnik(150, 15, 30, 2);

            postać.Walka(pijaniMarynarze);
                
            int zdobyteDoświadczenie = 300;
            int zdobyteZłoto = 800;

            postać.doświadczenie += zdobyteDoświadczenie;
            postać.złoto += zdobyteZłoto;

            System.Console.WriteLine("Gratulacje!");
            System.Console.WriteLine($"Pokonałeś przeciwników i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
        }
    }
}