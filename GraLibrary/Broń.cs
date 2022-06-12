namespace GraLibrary
{
    public class Broń : Przedmiot
    {
        public Broń(string nazwa, Statystyki statystyki, int wymaganyPoziom, int koszt, Profesja profesja) :
        base(nazwa, statystyki, wymaganyPoziom, koszt, profesja){}
    }
}