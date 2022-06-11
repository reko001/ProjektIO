namespace GraLibrary
{
    public class Statystyki //podstawowe statystki
    {
        public int punktyZdrowia;
        public int atakFizyczny;
        public int obrona;
        public int szczęście;

        public Statystyki(int pz, int af, int o, int s)
        {
            punktyZdrowia = pz;
            atakFizyczny = af;
            obrona = o;
            szczęście = s;
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