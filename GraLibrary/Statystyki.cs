namespace GraLibrary
{
    public class Statystyki //podstawowe statystki
    {
        public int punktyZdrowia;
        public int atakFizyczny;
        public int obrona;
        public int szczęście;

        public Statystyki(int punktyZdrowia, int atakFizyczny, int obrona, int szczęście)
        {
            this.punktyZdrowia = punktyZdrowia;
            this.atakFizyczny = atakFizyczny;
            this.obrona = obrona;
            this.szczęście = szczęście;
        }

        public void WyświetlStatystyki()
        {
            System.Console.WriteLine($"Punkty Zdrowia: { punktyZdrowia }");
            System.Console.WriteLine($"Atak Fizyczny: { atakFizyczny }");
            System.Console.WriteLine($"Obrona: { obrona }");
            System.Console.WriteLine($"Szczęście: { szczęście }");
        }

    }
}