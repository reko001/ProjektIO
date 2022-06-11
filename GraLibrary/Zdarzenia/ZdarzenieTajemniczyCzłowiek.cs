namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieTajemniczyCzłowiek : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Nad wybrzeżem morza widzisz tajemniczego człowieka siedzącego na pomoście.");
            Console.WriteLine("Podchodzisz do niego...");
            Random random = new Random();
            int szansaNaŻeglarza = random.Next(0, 100);
            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaŻeglarza + postać.statystyki.szczęście) //hojny żeglarz
            {
                Console.WriteLine("Tajemniczy człowiek okazuje się być hojnym żeglarzem, który właśnie wrócił z wyprawy.");
                Console.WriteLine("Daje ci złoto i życzy udanej dalszej wędrówki.");

                int zdobyteDoświadczenie = 50;
                int zdobyteZłoto = 500;
                postać.złoto += zdobyteZłoto;
                postać.doświadczenie += zdobyteDoświadczenie;
                Console.WriteLine($"Zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } sztuk złota");
            }
            else //  złodziej
            {
                Console.WriteLine("Tajemniczy człowiek okazuje się być złodziejem, który nie ma wobec nas dobrych zamiarów.");
                Console.WriteLine("Dochodzi do walki");
                
                Przeciwnik złodziej = new Przeciwnik(120, 13, 25, 2);

                postać.Walka(złodziej);
                
                int zdobyteDoświadczenie = 75;
                int zdobyteZłoto = 200;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                System.Console.WriteLine("Gratulacje!");
                System.Console.WriteLine($"Pokonałeś złodzieja i zdobywasz { zdobyteDoświadczenie } EXP oraz { zdobyteZłoto } złota");
            }
        }
    }
}