using System.Collections.Generic;
namespace GraLibrary
{
    public static class Handlarz
    {
        public static List<Przedmiot> przedmioty = new List<Przedmiot>();//przedmioty w ofercie handlarza
        public static int liczbaPrzedmiotów = 0;

        public static void DodajPrzedmiot(Przedmiot przedmiot)
        {
            przedmioty.Add(przedmiot);
            liczbaPrzedmiotów++;
        }

        public static void PokażTowary()
        {
            int numeracja = 1;
            foreach(Przedmiot przedmiot in przedmioty)
            {
                System.Console.WriteLine($"{ numeracja }:[{ przedmiot.nazwa }] - koszt: { przedmiot.koszt } złota");
                przedmiot.statystyki.WyświetlStatystyki();
                System.Console.WriteLine($"Wymagany poziom: { przedmiot.wymaganyPoziom }");
                System.Console.WriteLine();
                numeracja++;
            }
        }
    }
}