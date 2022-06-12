namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieZjawa : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Krążą legendy, że Tajemniczy Zamek jest nawiedzony.");
            System.Console.WriteLine("Mimo tego odważasz się wejść.");

            Random random = new Random();
            int szansaNaZaatakowaniePrzezZjawę = random.Next(0, 101);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaZaatakowaniePrzezZjawę - postać.statystyki.szczęście) //zaatakowanie przez zjawę
            {
                System.Console.WriteLine("Tuż przy wejściu czai się zjawa.");
                System.Console.WriteLine("Zostałeś zaatakowany!");

                Przeciwnik zjawa = new Przeciwnik(250, 150, 0, 6);

                postać.Walka(zjawa);

                if(postać.zdrowie > 0)
                {
                    int zdobyteDoświadczenie = 200;
                    int zdobyteZłoto = 2000;

                    postać.doświadczenie += zdobyteDoświadczenie;
                    postać.złoto += zdobyteZłoto;

                    System.Console.WriteLine("Gratulacje!");
                    System.Console.WriteLine($"Udało ci się pokonać zjawę, zdobywasz { zdobyteDoświadczenie } EXP i { zdobyteZłoto } złota.");
                }
            }
        }
    }
}