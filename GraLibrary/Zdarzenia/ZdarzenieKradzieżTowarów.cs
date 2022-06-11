namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieKradzieżTowarów : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Widzisz niestrzeżony towar za rogiem.");
            System.Console.WriteLine("Próbujesz dokonać kradzieży.");

            Random random = new Random();
            int szansaNaPrzyłapanie = random.Next(0, 101);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaPrzyłapanie - postać.statystyki.szczęście) //przyłapanie na kradzieży
            {
                System.Console.WriteLine("Zostałeś zauważony przez strażnika.");
                System.Console.WriteLine("Dostajesz karę chłosty.");

                int traconeZdrowie = 100;

                postać.zdrowie -= traconeZdrowie;
                System.Console.WriteLine($"Tracisz { traconeZdrowie } punktów zdrowia.");
            }
            else //udana kradzież
            {
                System.Console.WriteLine("Udało ci się niepostrzeżenie ukraść towar.");

                int zdobyteZłoto = 500;

                postać.złoto += zdobyteZłoto;
                System.Console.WriteLine($"Zdobywasz { zdobyteZłoto } złota");
            }

            int zdobyteDoświadczenie = 50;

            postać.doświadczenie += zdobyteDoświadczenie;
            System.Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP");
        }
    }
}