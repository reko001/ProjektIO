namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieStarzec : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Rozglądasz się po dokoła. W oddali widzisz starca siedzącego na ruinach.");
            Console.WriteLine("Podchodzisz do niego, wygląda jakby nad czymś rozmyślał.");
            Console.WriteLine("Kiedy próbujesz się odezwać, nagle starszy człowiek zaczyna opowiadać swoją historię zwiążaną z tym miejscem.");
            Console.WriteLine("Okazało się, że za tymi ruinami stoi bardzo ciekawa historia.");
            Console.WriteLine("Wysłuchujesz całej historii z uwagą.");
            Random random = new Random();
            int szansaNaNagrodę = random.Next(0, 40);
            int wylosowanaLiczba = random.Next(1, 101); 
            if(wylosowanaLiczba <= szansaNaNagrodę + postać.statystyki.szczęście) //starzec daje nam 100szt złota
            {
                int uzyskaneZłoto = 100;
                Console.WriteLine("Starzec życzy ci powodzenia w dalszej wędrówce i daje ci drobny prezent.");
                postać.złoto += uzyskaneZłoto;
                Console.WriteLine($"Zyskujesz { uzyskaneZłoto } sztuk złota.");
            }
            else // nic nie dostajemy
            {
                Console.WriteLine("Starzec życzy ci powodzenia w dalszej wędrówce.");
            }
            int zdobyteDoświadczenie = 50;
            postać.doświadczenie += zdobyteDoświadczenie;
            Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP");
        }
    }
}