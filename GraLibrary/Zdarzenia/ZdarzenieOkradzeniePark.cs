namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieOkradzeniePark : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Wchodzisz do parku. Wygląda spokojnie, chociaż chodzą słuchy, że nie jest to bezpiczne miejsce");
            Random random = new Random();
            int szansaNaWalke = random.Next(0, 30);
            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaWalke - postać.statystyki.szczęście)
            {
                Console.WriteLine("Niespodziewanie zaczepia cię złodziej.");
                Console.WriteLine("Próbuje ukraść twoje złoto. Bronisz się, dochodzi do walki.");
                Przeciwnik złodziej = new Przeciwnik(120, 13, 25, 2);

                postać.Walka(złodziej);

                int zdobyteDoświadczenie = 75;
                int zdobyteZłoto = 200;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                Console.WriteLine("Gratulacje!");
                Console.WriteLine(
                    $"Pokonałeś złodzieja i zdobywasz {zdobyteDoświadczenie} EXP oraz {zdobyteZłoto} złota");
            }
            else
            {
                Console.WriteLine("Nic szczególnego się tu nie dzieje");
            }
        }
    }
}