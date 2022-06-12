namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieSkrzynia : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Zobaczyłeś w kącie tajemniczą skrzynię.");

            Random random = new Random();
            int szansaNaZłoto = random.Next(0, 101);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaZłoto + postać.statystyki.szczęście) //znalezienie złota w skrzyni
            {
                int zdobyteZłoto = 500;

                postać.złoto += zdobyteZłoto;
                System.Console.WriteLine($"Otwierasz skrzynię i znajdujesz { zdobyteZłoto } złota");
            }
            else //skrzynia okazuje się pułapką
            {
                System.Console.WriteLine("Otwierasz skrzynię i...");
                System.Console.WriteLine("...");
                System.Console.WriteLine("Skrzynia WYBUCHA !!!");

                int traconeZdrowie = 1000;
                postać.zdrowie -= traconeZdrowie;
            }
        }
    }
}