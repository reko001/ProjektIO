namespace GraLibrary
{

    public abstract class Przedmiot
    {
        public string nazwa;
        public Statystyki statystyki;
        public int wymaganyPoziom;
        public int koszt;
        public Profesja profesja;

        public Przedmiot(string n, Statystyki s, int wp, int k, Profesja p)
        {
            nazwa = n;
            statystyki = s;
            wymaganyPoziom = wp;
            koszt = k;
            profesja = p;
        }
    }
}