namespace GraLibrary
{
    public class Buty : Przedmiot
    {
        public Buty(string nazwa, Statystyki statystyki, int wymaganyPoziom, int koszt, Profesja profesja) :
        base(nazwa, statystyki, wymaganyPoziom, koszt, profesja){}
    }
}