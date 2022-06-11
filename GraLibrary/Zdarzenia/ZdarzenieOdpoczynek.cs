namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieOdpoczynek : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Taka piękna pogoda. Czas chyba, żeby usiąśc i chwilę odpocząć.");
            Console.WriteLine("Siadasz nad brzegiem morza i robisz sobie krótką drzemkę.");
            Random random = new Random();
            int szansaNaBycieOkradzionym = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101);
            if (wylosowanaLiczba <= szansaNaBycieOkradzionym - postać.statystyki.szczęście)
            {
                Console.WriteLine("Podczas drzemki, ktoś próbuje ukaść złoto z twojej sakiewki.");
                if (postać.złoto == 0)
                {
                    Console.WriteLine("Chociaż ty chyba nie musisz się tym przejmować.");
                    Console.WriteLine("W końcu twoja sakiewka jest zupełnie pusta.");
                }
                else 
                {
                    int straconeZłoto = random.Next(1, 200);
                    straconeZłoto = Math.Min(straconeZłoto, postać.złoto);
                    postać.złoto -= straconeZłoto;
                
                    Console.WriteLine($"Zostałeś okradziony! Tracisz { straconeZłoto } sztuk złota.");
                }
            }

            int zregenerowaneZdrowie = 150;
            zregenerowaneZdrowie = Math.Min(zregenerowaneZdrowie, postać.statystyki.punktyZdrowia - postać.zdrowie);
            int zdobyteDoświadczenie = 50;
            Console.WriteLine("Krótki odpoczynek nad brzegiem morza dobrze robi na zdrowie.");
            Console.WriteLine($"Zdobywasz  { zdobyteDoświadczenie }  EXP oraz regenerujesz { zregenerowaneZdrowie } punktów zdrowia");
        }
        
    }
}