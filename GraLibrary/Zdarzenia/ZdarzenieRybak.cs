namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieRybak : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W porcie morskim, widzisz siedzącego rybaka, który prawdopodobnie właśnie wrócił z wyprawy.");
            Console.WriteLine("Podchodzisz do niego, zaczyna ci opowiadać żeglarskie opowieści...");
            Console.WriteLine("Po dłuższym czasie w końcu rybak skończył opowiadać.");

            Random random = new Random();
            int szansaNaPrezent = random.Next(0, 20);
            int wylosowanaLiczba = random.Next(1, 101);
            int zdobyteDoświadczenie = 25;

            if (wylosowanaLiczba <= szansaNaPrezent + postać.statystyki.szczęście)
            {
                Console.WriteLine("Już chciałeś odejść, ale rybak daje ci jeszcze drobny prezent i życzy udanej wędrówki.");
                int otrzymaneZłoto = 20;
                postać.złoto += otrzymaneZłoto;
                postać.doświadczenie += zdobyteDoświadczenie;
                Console.WriteLine($"Zdobywasz  { zdobyteDoświadczenie }  EXP oraz  { otrzymaneZłoto } sztuk złota");
            }
            else
            {
                Console.WriteLine("Trochę to trwało, ale chociaż się czegoś nowego dowiedziałeś.");
                Console.WriteLine($"Zdobywasz  { zdobyteDoświadczenie }  EXP");
            }
        }
    }
}