namespace GraLibrary
{
    public class Miejsce
    {
        private string nazwa;
        private List<Zdarzenie> zdarzenia;
        private int liczbaZdarzeń;

        public string Nazwa{ get{ return nazwa; } }

        public Miejsce(string n)
        {
            nazwa = n;
            zdarzenia = new List<Zdarzenie>();
            liczbaZdarzeń = 0;
        }

        public void DodajZdarzenie(Zdarzenie zdarzenie)
        {
            zdarzenia.Add(zdarzenie);
            liczbaZdarzeń++;
        }

        public void WykonajZdarzenie(Postać postać)
        {
            if(liczbaZdarzeń > 0)
            {
                Random random = new Random();
                zdarzenia[random.Next(0, liczbaZdarzeń - 1)].Wykonaj(postać);
            }
        }
    }
}