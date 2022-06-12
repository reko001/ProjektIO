using System.Collections.Generic;
namespace GraLibrary
{
    public static class Druid
    {
        public static List<KeyValuePair<Mikstura, int>> mikstury = new List<KeyValuePair<Mikstura, int>>(); // mikstury i jej koszty
        public static int liczbaMikstur = 0;

        public static void DodajMiksturę(int zwracaneZdrowie, int koszt, string nazwa)
        {
            mikstury.Add(new KeyValuePair<Mikstura, int>(new Mikstura(nazwa, zwracaneZdrowie), koszt));
            liczbaMikstur++;
        }

        public static void PokażMikstury()
        {
            foreach(var para in mikstury)
            {
                System.Console.Write($"[{ para.Key.nazwa }] ");
            }
            System.Console.WriteLine();
        }
    }
}