namespace GraLibrary
{
    public class UzbrojenieMagaFabryka : IUzbrojenieFabryka
    {
        public Broń StwórzBroń(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Broń(nazwa, (StatystykiMaga)statystyki, wymaganyPoziom, koszt, Profesja.MAG);
        }
        public Buty StwórzButy(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Buty(nazwa, (StatystykiMaga)statystyki, wymaganyPoziom, koszt, Profesja.MAG);
        }
        public Zbroja StwórzZbroję(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Zbroja(nazwa, (StatystykiMaga)statystyki, wymaganyPoziom, koszt, Profesja.MAG);
        }
        public Spodnie StwórzSpodnie(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Spodnie(nazwa, (StatystykiMaga)statystyki, wymaganyPoziom, koszt, Profesja.MAG);
        }
        public Hełm StwórzHełm(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Hełm(nazwa, (StatystykiMaga)statystyki, wymaganyPoziom, koszt, Profesja.MAG);
        }

    }
}