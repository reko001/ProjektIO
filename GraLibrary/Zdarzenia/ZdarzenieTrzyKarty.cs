namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieTrzyKarty : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Na uboczu siedzi pewien dziwnie wyglądający typ. W rękach trzyma talię kart");
            Console.WriteLine("Podchodzisz do niego.");
            if (postać.złoto >= 100)
            {
                Console.WriteLine("Decydujesz się zagrać w trzy karty za 100szt złota.");
                int postawioneZłoto = 100;
                postać.złoto -= postawioneZłoto;
                Console.WriteLine("Każdy szczęsciu dopomoże, każdy dzisiaj wygrać może.");
                Console.WriteLine("Raz, dwa ,trzy...");

                Random random = new Random();
                int szansaNaSukces = random.Next(0,40);
                int wylosowanaLiczba = random.Next(1, 101);

                if(wylosowanaLiczba <= szansaNaSukces + postać.statystyki.szczęście) //wygrana
                {
                    Console.WriteLine("Brawo! Udało ci się wygrać!");
                    int wygraneZłoto = 300;

                    postać.złoto += wygraneZłoto;
                    Console.WriteLine($"Zyskujesz { wygraneZłoto } złota.");
                }
                else // porażka
                {
                    Console.WriteLine("No niestety tym razem się nie udało.");
                }
            }
            else
            {
                Console.WriteLine("Aby zagrać musisz mieć conajmniej 100 sztuk złota. Sięgasz po sakiewkę...");
                Console.WriteLine($"W sakiewce zostało tylko { postać.złoto } złota! Chyba czas coś zarobić.");
            }
        }
    }
}