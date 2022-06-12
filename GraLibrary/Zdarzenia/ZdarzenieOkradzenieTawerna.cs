namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieOkradzenieTawerna : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Picie piwa może trochę uśpić czujność, szczególnie w tłumnie odwiedzanej tawernie.");
            Random random = new Random();
            int szansaNaOkradzenie = random.Next(0, 30);

            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaOkradzenie - postać.statystyki.szczęście)
            {
                Console.WriteLine("Podczas gdy ty delektujesz się kuflem złocistego trunku,");
                Console.WriteLine("ktoś niespodziewanie kradnie złoto z twojej sakiewki");
                if (postać.złoto == 0)
                {
                    Console.WriteLine("Chociaż ty chyba nie musisz się tym przejmować.");
                    Console.WriteLine("W końcu twoja sakiewka jest zupełnie pusta.");
                }
                else
                {
                    random = new Random();
                    int straconeZłoto = random.Next(1, 200);
                    straconeZłoto = Math.Min(straconeZłoto, postać.złoto);
                    postać.złoto -= straconeZłoto;

                    Console.WriteLine($"Zostałeś okradziony! Tracisz {straconeZłoto} sztuk złota.");
                }
            }
            else
            {
                Console.WriteLine("Tym razem jednak nic szczególnego się nie wydarza.");
            }
        }
    }
}