namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieGrobowiec : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Na cmetarzu widzisz wielki opuszczony grobowiec.");
            Console.WriteLine("Wchodzisz do środka...");
            Random random = new Random();
            int szansaNaSkarb = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaSkarb + postać.statystyki.szczęście) //znalezlismy skarb w grobowcu
            {
                Console.WriteLine("W grobowcu, pod ławką znajdujesz pewną niewielką ilość złota");
                Console.WriteLine("Chowasz szybko złoto do sakiewki.");

                int zdobyteZłoto = 150;
                postać.złoto += zdobyteZłoto;
                Console.WriteLine($"Zdobywasz { zdobyteZłoto } sztuk złota");
            }
            else // atakuje nas zjawa
            {
                Console.WriteLine("Wchodząc do grobowca zostajesz napadnięty przez zjawę.");
                Console.WriteLine("Dochodzi do walki");
                
                Przeciwnik zjawa = new Przeciwnik(320, 45, 105, 6);

                postać.Walka(zjawa);
                
                int zdobyteDoświadczenie = 200;
                int zdobyteZłoto = 2500;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                System.Console.WriteLine("Gratulacje!");
                System.Console.WriteLine($"Pokonałeś zjawę i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
            }
        }
    }
}