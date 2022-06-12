namespace GraLibrary
{

    public abstract class Przedmiot
    {
        public string nazwa;
        public Statystyki statystyki;
        public int wymaganyPoziom;
        public int koszt;
        public Profesja profesja;

        public Przedmiot(string nazwa, Statystyki statystyki, int wymaganyPoziom, int koszt, Profesja profesja)
        {
            this.nazwa = nazwa;
            this.statystyki = statystyki;
            this.wymaganyPoziom = wymaganyPoziom;
            this.koszt = koszt;
            this.profesja = profesja;
        }

        public void PokażStatystyki()
        {
            System.Console.WriteLine(nazwa);
            statystyki.WyświetlStatystyki();
            System.Console.WriteLine($"Wymagany poziom: { wymaganyPoziom }");
            System.Console.WriteLine($"Koszt: { koszt } złota");
        }
    }
}