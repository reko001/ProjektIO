namespace GraLibrary
{
    public interface IUzbrojenieFabryka
    {
        public Broń StwórzBroń(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom);
        public Buty StwórzButy(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom);
        public Zbroja StwórzZbroję(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom);
        public Spodnie StwórzSpodnie(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom);
        public Hełm StwórzHełm(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom);

    }
}