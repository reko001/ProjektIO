namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieKoperta : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Widzisz siedzącego człowieka, który nie wie jak poprawnie zaadresować kopertę.");
            Console.WriteLine("Wygląda na zmartwionego, decydujesz się mu pomóc");
            Random random = new Random();
            int szansaNaNagrodę = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101); 
            if(wylosowanaLiczba <= szansaNaNagrodę + postać.statystyki.szczęście) //człowiek odwdzięcza się 25szt złota
            {
                Console.WriteLine("Człowiek dziękuje ci za twoją pomoc i odwdzięcza się drobną zapłatą");
                int uzyskaneZłoto = 25;

                postać.złoto += uzyskaneZłoto;
                Console.WriteLine($"Zyskujesz { uzyskaneZłoto } sztuk złota.");
            }
            else // nic nie dostajemy
            {
                Console.WriteLine("Człowiek dziękuje ci za twoją pomoc");
            }
            int zdobyteDoświadczenie = 30;
            postać.doświadczenie += zdobyteDoświadczenie;
            Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP");
            
        }
    }
}