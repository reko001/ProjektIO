namespace GraLibrary
{
    public abstract class Postać
    {
        protected static Postać? instancja;

        public Statystyki statystyki;
        public Statystyki statystykiBazowe;
        
        public int zdrowie;
        public int złoto;
        public int poziom;
        public int doświadczenie;
        public Profesja profesja;
        public List<Przedmiot>? plecak;
        public int pojemnośćPlecaka;
        public List<Mikstura>? mikstury;

        public abstract void Walka(Przeciwnik przeciwnik);

        public abstract void WbiciePoziomu();

        public abstract void PokażStatystyki();

        public void PokażEkwipunek()
        {
            foreach(Przedmiot przedmiot in plecak)
            {
                System.Console.Write($"[ { przedmiot.nazwa } ({ przedmiot.koszt } złota)] ");
            }
            System.Console.WriteLine();
        }

        public void PokażMikstury()
        {
            foreach(Mikstura mikstura in mikstury)
            {
                System.Console.Write($"[ { mikstura.nazwa } ({ mikstura.zwracaneZdrowie })]");
            }
            System.Console.WriteLine();
        }

        public void WypijMiksturę(int index)
        {
            zdrowie += mikstury[index].zwracaneZdrowie;
            zdrowie = Math.Min(zdrowie, statystyki.punktyZdrowia);
        }

        public void DodajMiksturę(Mikstura mikstura)
        {
            mikstury.Add(mikstura);
        }

        public void DodajPrzedmiot(Przedmiot przedmiot)
        {
            plecak.Add(przedmiot);
        }

        public abstract void PrzeliczStatystyki();
    }
}