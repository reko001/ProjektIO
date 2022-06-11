namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieStudnia : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("Pośrodku widzisz studnię. Krążą legnedy, że wrzucenie monety przyniesie szczęście.");
            if (postać.złoto >= 1)
            {
                int wrzconaMoneta = 1;
                postać.złoto -= wrzconaMoneta;
                Console.WriteLine("Podchodzisz do studni i wrzucasz monetę.");

                Random random = new Random();
                int szansaNaSukces = 1;
                int wylosowanaLiczba = random.Next(1, 500);

                if(wylosowanaLiczba <= szansaNaSukces + postać.statystyki.szczęście) //wrzucenie monety dało nam szczęście
                {
                    Console.WriteLine("Legendy czasem okazują się mieć w sobie ziarno prawdy.");
                    int uzyskaneSzczęście = 10;

                    postać.statystyki.szczęście += uzyskaneSzczęście;
                    Console.WriteLine($"Zyskujesz { uzyskaneSzczęście } punktów szczęścia.");
                }
                else //wrzucenie monety nic nam nie dało
                {
                    Console.WriteLine("Legendy zazwyczaj nie są jednak prawdziwe.");
                    Console.WriteLine("No cóż, jedna moneta to nie tak dużo.");
                }
            }
            else
            {
                Console.WriteLine("Podchodzisz do studni i chcesz wrzucic monetę. Sięgasz po sakiewkę...");
                Console.WriteLine("W sakiewce nie ma już żadnego złota! Chyba czas coś zarobić.");
            }
        }
    }
}