namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieRozładunek : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W porcie morskim, widzisz zmęczonych maryanrzy, którzy z trudem rozładowywują towary ze statku");
            Console.WriteLine("Decydujesz się im pomóc");

            Random random = new Random();
            int szansaNaZapłatę = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101);
            int zdobyteDoświadczenie = 25;
            
            int szansaNaUraz = random.Next(0, 100);
            if (wylosowanaLiczba <= szansaNaUraz - postać.statystyki.szczęście)
            {
                int straconeZdrowie = 25;
                postać.zdrowie -= straconeZdrowie;
                Console.WriteLine("W trakcie pomocy przy rozładunku doznajesz bloesnej kontuzji.");
                Console.WriteLine($"Tracisz  { straconeZdrowie }  punktów zdrowia");
            }
            
            if (wylosowanaLiczba <= szansaNaZapłatę + postać.statystyki.szczęście)
            {
                Console.WriteLine("Po skończonym rozładunku, otrzymujesz solidną zapłatę");
                int otrzymaneZłoto = 300;
                postać.złoto += otrzymaneZłoto;
                postać.doświadczenie += zdobyteDoświadczenie;
                Console.WriteLine($"Zdobywasz  { zdobyteDoświadczenie }  EXP oraz {otrzymaneZłoto} sztuk złota");
            }
            else
            {
                postać.doświadczenie += zdobyteDoświadczenie;
                Console.WriteLine("Po skończonym rozładunku, wszyscy gdzieś poszli i zostałeś sam.");
                Console.WriteLine("Miałeś nadzieję na chociaż symboliczną zapłatę, ale tym razem pomoc się nie opłaciła.");
                Console.WriteLine($"Zdobywasz  { zdobyteDoświadczenie }  EXP");
            }

        }
    }
}