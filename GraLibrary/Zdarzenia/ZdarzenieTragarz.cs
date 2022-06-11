namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieTragarz : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Na drodze widziasz zmęczonego tragarza, który z dużym trudem dźwiga swoje towary");
            Console.WriteLine("Decydujesz się mu pomóc");
            Random random = new Random();
            int szansaNaNagrodę = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101); 
            if(wylosowanaLiczba <= szansaNaNagrodę + postać.statystyki.szczęście) //tragarz odwdzięcza się 50szt złota
            {
                Console.WriteLine("Tragarz dziękuje ci za twoją pomoc i odwdzięcza się drobną zapłatą");
                int uzyskaneZłoto = 50;

                postać.złoto += uzyskaneZłoto;
                Console.WriteLine($"Zyskujesz { uzyskaneZłoto } sztuk złota.");
            }
            else // nic nie dostajemy
            {
                Console.WriteLine("Tragarz dziękuje ci za twoją pomoc");
                Console.WriteLine("Cóż, właściwie to liczyłeś na coś więcej, za tak duży wysiłek.");
            }
            int zdobyteDoświadczenie = 50;
            postać.doświadczenie += zdobyteDoświadczenie;
            Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP");
            
            int szansaNaUraz = random.Next(0, 50);
            wylosowanaLiczba = random.Next(1, 101);
            if (wylosowanaLiczba <= szansaNaUraz - postać.statystyki.szczęście)
            {
                Console.WriteLine("Niestety podczas dźwigania dostałeś urazu stawów.");
                int straconeZdrowie = 50;
                postać.złoto -= straconeZdrowie;
                Console.WriteLine($"Tracisz { straconeZdrowie } pkt zdrowia");
            }
        }
    }
}