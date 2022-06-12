namespace GraLibrary.Zdarzenia
{
    public class ZdarzeniePodchmieleniBywalcy : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W porcie czasami kręcą się podchmieleni bywalcy tawerny.");
            Random random = new Random();
            int szansaNaWalke = random.Next(0, 20);

            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaWalke - postać.statystyki.szczęście)
            {
                Console.WriteLine("Przechadzając się, zostajesz zaatakowany przez niezbyt trzeźwych marynarzy.");
                Przeciwnik PodchmieleniBywalcy = new Przeciwnik(120, 15, 20, 2);

                postać.Walka(PodchmieleniBywalcy);

                int zdobyteDoświadczenie = 100;
                int zdobyteZłoto = 500;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                Console.WriteLine("Gratulacje!");
                Console.WriteLine(
                    $"Pokonałeś podchmielonych marynarzy i zdobywasz {zdobyteDoświadczenie} EXP oraz {zdobyteZłoto} złota");
            }
            else
            {
                Console.WriteLine("Tym razem jednak nikogo tutaj nie ma, może to dlatego, że jest środek dnia?");
            }
        }
    }
}