namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieStrażnik : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Podchodzi ciebie strażnik.");

            Random random = new Random();
            int szansaNaUznanieZaPodejrzanego = random.Next(0,31);

            int wylosowanaLiczba = random.Next(1, 101);

            if(wylosowanaLiczba <= szansaNaUznanieZaPodejrzanego - postać.statystyki.szczęście) //uznanie za podejrzanego
            {
                System.Console.WriteLine("Strażnik uznaje cię za podejrzaną osobę.");
                System.Console.WriteLine("Otrzymujesz karę chłosty.");

                int traconeZdrowie = 100;

                postać.zdrowie -= traconeZdrowie;
                System.Console.WriteLine($"Tracisz { traconeZdrowie } punktów zdrowia.");
            }
            else //ostrzeżenie
            {
                System.Console.WriteLine("Strażnik ostrzega cię przed kręcocymi się w pobliżu złodziajami.");
            }

            int zdobyteDoświadczenie = 50;
            postać.doświadczenie += zdobyteDoświadczenie;
            System.Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP.");
        }
    }
}