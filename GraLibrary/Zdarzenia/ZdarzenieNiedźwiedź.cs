namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieNiedźwiedź : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Słyszałeś pogłoski o tym, że Ciemny Las jest niebezpieczny.");
            System.Console.WriteLine("Wchodzisz do Ciemnego Lasu i rozglądasz się za jakimś niespodziewanym zagrożeniem.");

            Random random = new Random();
            int szansaNaZaatakowaniePrzezNiedźwiedzia = random.Next(0, 41);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaZaatakowaniePrzezNiedźwiedzia - postać.statystyki.szczęście) //zaatakanowanie przez niedźwiedzia
            {
                System.Console.WriteLine("Zauważasz czającego się za drzewem niedźwiedzia.");
                System.Console.WriteLine("Zostałeś zaatakowany!");

                Przeciwnik niedźwiedź = new Przeciwnik(300, 40, 100, 5);

                postać.Walka(niedźwiedź);
                
                int zdobyteDoświadczenie = 200;
                int zdobyteZłoto = 1500;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                System.Console.WriteLine("Gratulacje!");
                System.Console.WriteLine($"Pokonałeś niedźwiedzia i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
            }
            else //nie się nie wydarza
            {
                System.Console.WriteLine("Nie widzisz nic podejrzanego, więc kontynuujesz swoją wędrówkę.");
            }
        }
    }
}