namespace GraLibrary.Zdarzenia
{
    public class ZdarzeniePodejrzanyCzłowiek : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            Console.WriteLine("W tych terenach znajdują się czasami podejrzani ludzie.");
            Random random = new Random();
            int szansaNaWalke = random.Next(0, 100);

            int wylosowanaLiczba = random.Next(1, 101);

            if (wylosowanaLiczba <= szansaNaWalke - postać.statystyki.szczęście)
            {
                Console.WriteLine("Przechadzając się, zostajesz zaatakowany przez podejrzanego człowieka.");
                Przeciwnik PodejrzanyCzłowiek = new Przeciwnik(200, 25, 35, 4);

                postać.Walka(PodejrzanyCzłowiek);

                int zdobyteDoświadczenie = 100;
                int zdobyteZłoto = 500;

                postać.doświadczenie += zdobyteDoświadczenie;
                postać.złoto += zdobyteZłoto;

                Console.WriteLine("Gratulacje!");
                Console.WriteLine(
                    $"Pokonałeś podejrzanego człowieka i zdobywasz {zdobyteDoświadczenie} EXP oraz {zdobyteZłoto} złota");
            }
            else
            {
                Console.WriteLine("Tym razem jednak nikogo tutaj nie ma, może to dlatego, że jest środek dnia?");
            }
        }
    }
}