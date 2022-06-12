namespace GraLibrary
{
    public class UzbrojenieStrzelcaFabryka : IUzbrojenieFabryka
    {
        public Broń StwórzBroń(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Broń(nazwa, (StatystykiStrzelca)statystyki, wymaganyPoziom, koszt, Profesja.STRZELEC);
        }
        public Buty StwórzButy(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Buty(nazwa, (StatystykiStrzelca)statystyki, wymaganyPoziom, koszt, Profesja.STRZELEC);
        }
        public Zbroja StwórzZbroję(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Zbroja(nazwa, (StatystykiStrzelca)statystyki, wymaganyPoziom, koszt, Profesja.STRZELEC);
        }
        public Spodnie StwórzSpodnie(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Spodnie(nazwa, (StatystykiStrzelca)statystyki, wymaganyPoziom, koszt, Profesja.STRZELEC);
        }
        public Hełm StwórzHełm(string nazwa, Statystyki statystyki, int koszt, int wymaganyPoziom)
        {
            return new Hełm(nazwa, (StatystykiStrzelca)statystyki, wymaganyPoziom, koszt, Profesja.STRZELEC);
        }

    }
}