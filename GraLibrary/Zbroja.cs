namespace GraLibrary
{
    public class Zbroja : Przedmiot
    {
        public Zbroja(string nazwa, Statystyki statystyki, int wymaganyPoziom, int koszt, Profesja profesja) :
        base(nazwa, statystyki, wymaganyPoziom, koszt, profesja){}    }
}