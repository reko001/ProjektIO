namespace GraLibrary
{
    public class UzbrojenieWojownikaFabryka : IUzbrojenieFabryka
    {
        public Broń StwórzBroń(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Broń(nazwa, (StatystykiWojownika)statystyki, wymaganyPoziom, koszt, Profesja.WOJOWNIK);
        }
        public Buty StwórzButy(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Buty(nazwa, (StatystykiWojownika)statystyki, wymaganyPoziom, koszt, Profesja.WOJOWNIK);
        }
        public Zbroja StwórzZbroję(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Zbroja(nazwa, (StatystykiWojownika)statystyki, wymaganyPoziom, koszt, Profesja.WOJOWNIK);
        }
        public Spodnie StwórzSpodnie(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Spodnie(nazwa, (StatystykiWojownika)statystyki, wymaganyPoziom, koszt, Profesja.WOJOWNIK);
        }
        public Hełm StwórzHełm(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Hełm(nazwa, (StatystykiWojownika)statystyki, wymaganyPoziom, koszt, Profesja.WOJOWNIK);
        }

    }
}