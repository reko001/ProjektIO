namespace GraLibrary.Zdarzenia
{
    public class ZdarzeniePiwo : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W tawernie nic tak nie poprawia humoru jak kufel zimnego piwa.");
            if (postać.złoto >= 5)
            {
                int wydaneZłoto = 5;
                postać.złoto -= wydaneZłoto;
                Console.WriteLine("Kupujesz kufel piwa za 5 sztuk złota");

                Random random = new Random();
                int szansaNaUpicieSie = random.Next(15, 50);
                int wylosowanaLiczba = random.Next(1, 101);

                if(wylosowanaLiczba <= szansaNaUpicieSie - postać.statystyki.szczęście) //upicie sie
                {
                    Console.WriteLine("To chyba było dla ciebie za dużo.");
                    Console.WriteLine("Będzie dobrze jak wyjdziesz stąd o własmych siłach.");
                    Console.WriteLine("To z pewnością nie ma dobrego wpływu na twoje zdrowie.");
                    int straconeZdrowie = 10;

                    postać.zdrowie -= straconeZdrowie;
                    Console.WriteLine($"Tracisz { straconeZdrowie } punktów zdrowia.");
                }
                else // nic sie nie dzieje
                {
                    Console.WriteLine("Zimne piwo, świetne jak zawsze.");
                }
            }
            else
            {
                Console.WriteLine("Żeby kupić piwo potrzebujesz 5 szt złota.");
                Console.WriteLine($"W sakiewce zostało tylko { postać.złoto } złota! Chyba czas coś zarobić.");
            }
        }
    }
}