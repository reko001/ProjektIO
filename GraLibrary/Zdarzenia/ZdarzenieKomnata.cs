namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieKomnata : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Wchodzisz do ciemnej komnaty.");
            System.Console.WriteLine("Włosy stają ci dęba i odczuwasz nieoczekiwany strach.");

            Random random = new Random();
            int szansaNaZaatakowanie = random.Next(50, 101);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaZaatakowanie) //zostajesz zaatakowany przez bestię
            {
                System.Console.WriteLine("Nieoczekiwanie z mroku wyłania się bestia.");
                System.Console.WriteLine("Zostałeś zaatakowany!");

                Przeciwnik bestia = new Przeciwnik(1000, 100, 350, 9);

                postać.Walka(bestia);

                if(postać.zdrowie > 0)
                {
                    int zdobyteDoświadczenie = 300;
                    int zdobyteZłoto = 3000;

                    postać.doświadczenie += zdobyteDoświadczenie;
                    postać.złoto += zdobyteZłoto;

                    System.Console.WriteLine("Gratulacje!");
                    System.Console.WriteLine($"Pokonałeś bestię i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota.");
                }

            }
            else //nic się nie wydarza
            {
                System.Console.WriteLine("Idziesz w napięciu lecz ostatecznie nic się nie wydarza.");
            }
        }
    }
}