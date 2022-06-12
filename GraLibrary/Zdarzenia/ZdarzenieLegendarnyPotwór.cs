namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieLegendarnyPotwór : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Doszedłeś w końcu do najmroczniejszego zakątku zamku.");
            System.Console.WriteLine("Przed tobą ukazuje się wielki loch.");
            System.Console.WriteLine("Rozglądasz się wokół i zauważasz wyłaniającego się z mroku potwora.");
            System.Console.WriteLine("Twoim oczom ukazuje się legendarny potwór = czarnoksiężnik.");

            Przeciwnik czarnoksiężnik = new Przeciwnik(4000, 200, 1000, 15);

            postać.Walka(czarnoksiężnik);

            if(postać.zdrowie > 0)
            {
                System.Console.WriteLine("Pokonałeś czarnoksiężnika!");
                System.Console.WriteLine("Zostałeś bohaterem!");
                
                int zdobyteDoświadczenie = 400;
                int zdobyteZłoto = 4000;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                System.Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } doświadczenia i { zdobyteZłoto } złota.");
            }

        }
    }
}