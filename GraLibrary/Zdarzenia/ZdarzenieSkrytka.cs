namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieSkrytka : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W opuszczonych ruinach, pod głazami, dostrzegasz tajemniczą skrytkę.");
            Console.WriteLine("Otwierasz skrytkę...");
            Random random = new Random();
            int szansaNaSukces = 20;
            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaSukces + postać.statystyki.szczęście) //znalezlismy skarb w skrytce
            {
                Console.WriteLine("Twoim oczom ukauje się duża ilość złota.");
                Console.WriteLine("Chowasz szybko skarb do sakiewki.");

                int zdobyteZłoto = 1000;
                postać.złoto += zdobyteZłoto;
                Console.WriteLine($"Zdobywasz { zdobyteZłoto } sztuk złota");
            }
            else
            {
                Console.WriteLine("W środku nic nie ma, skrytka jest pusta.");
            }
        }
    }
}