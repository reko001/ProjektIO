namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieSpacer : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Taka piękna pogoda. Czas chyba, żeby wybrać się na krótki spacer.");
            Random random = new Random();
            int szansaNaWalke = random.Next(0, 30);
            int wylosowanaLiczba = random.Next(1, 101);
            if (wylosowanaLiczba <= szansaNaWalke - postać.statystyki.szczęście)
            {
                Console.WriteLine("Podczas przechadzania się po parku, nagle podchodzi do ciebie kieszonkowiec");
                Przeciwnik Kieszonkowiec = new Przeciwnik(100, 10, 20, 1);

                postać.Walka(Kieszonkowiec);
                
                int zdobyteDoświadczenie = 50;
                int zdobyteZłoto = 150;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                Console.WriteLine("Gratulacje!");
                Console.WriteLine($"Pokonałeś kieszonkowca i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
            }
            else
            {
                int zregenerowaneZdrowie = 50;
                zregenerowaneZdrowie = Math.Min(zregenerowaneZdrowie, postać.statystyki.punktyZdrowia - postać.zdrowie);
                int zdobyteDoświadczenie = 25;
                Console.WriteLine("Krótki spacer zdecydowanie jest dobry na zdrowie.");
                Console.WriteLine(
                    $"Zdobywasz  {zdobyteDoświadczenie}  EXP oraz regenerujesz {zregenerowaneZdrowie} punktów zdrowia");
            }
        }
    }
}