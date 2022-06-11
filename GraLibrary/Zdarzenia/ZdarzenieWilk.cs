namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieWilk : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Wchodzisz do lasu i słyszysz niepokojący szelest krzaków.");

            Random random = new Random();
            int szansaNaZaatakowaniePrzezWilka = random.Next(50, 101);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaZaatakowaniePrzezWilka) //zaatakowanie przez wilka
            {
                System.Console.WriteLine("Podchodzisz do krzaków i nagle wyłania się ogromny czarny wilk.");
                System.Console.WriteLine("Zostałeś zaatakowany!");

                Przeciwnik wilk = new Przeciwnik(150, 21, 15, 3);

                postać.Walka(wilk);

                int zdobyteDoświadczenie = 100;
                int zdobyteZłoto = 800;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                System.Console.WriteLine("Gratulacje!");
                System.Console.WriteLine($"Pokonałeś wilka i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
            }

            else //nic się nie wydarza
            {
                System.Console.WriteLine("Podchodzisz do krzaków, ale nic w nich nie ma.");
                System.Console.WriteLine("Spokojnym krokiem kontynuujesz swoją wędrówkę");
            }
        }
    }
}