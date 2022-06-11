namespace GraLibrary
{
    public abstract class Zdarzenie
    {
        public string nazwa;

        public Zdarzenie(string n)
        {
            nazwa = n;
        }
        public abstract void Wykonaj(Postać postać);
        
    }
}