namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieKsiądz : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Na cmentarzu, nieopodal starej kaplicy, widzisz księdza trzymającego w ręku księgę");
            Console.WriteLine("Podchodzisz do niego.");
            Console.WriteLine("Kapłan patrzy na ciebie i zaczyna odprawiać egzorcyzmy.");
            Random random = new Random();
            int szansaNaSukces = random.Next(0,100);
            int wylosowanaLiczba = random.Next(1, 101);
            if(wylosowanaLiczba <= szansaNaSukces + postać.statystyki.szczęście) 
            {
                Console.WriteLine("Czujesz, że to dobrze na ciebie działa.");
                int uzyskaneSzczęście = 1;

                postać.statystyki.szczęście += uzyskaneSzczęście;
                Console.WriteLine($"Zyskujesz { uzyskaneSzczęście } punktów szczęścia.");
            }
            else 
            {
                Console.WriteLine("Czujesz, że to chyba nie był najlepszy pomysł.");
                int straconeSzczęście = 1;

                postać.statystyki.szczęście += straconeSzczęście;
                Console.WriteLine($"Tracisz { straconeSzczęście } punktów szczęścia.");
            }
        }
    }
}