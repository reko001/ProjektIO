namespace GraLibrary.Zdarzenia
{
    public class ZdarzenieDruid : Zdarzenie
    {
        public void Wykonaj(Postać postać)
        {
            System.Console.WriteLine("Spacerujesz sobie spokojnie, aż tu nagle z krzaków wychodzi dziwna postać.");
            System.Console.WriteLine("Okazuje się, że postacią tą jest druid.");
            System.Console.WriteLine("Druid chce sprzedać ci mikstury.");
            System.Console.WriteLine("Mikstury w ofercie druida:");

            Druid.PokażMikstury();

            System.Console.WriteLine($"Wybierz którą miksturę chcesz kupić (1-{ Druid.liczbaMikstur }) lub coś innego by wyjść.");

            try
            {
                int wybór = Convert.ToInt32(System.Console.ReadLine().Trim());
                if(wybór >= 1 && wybór <= Druid.liczbaMikstur)
                {
                    if(postać.złoto >= Druid.mikstury[wybór - 1].Value)
                    {
                        postać.złoto -= Druid.mikstury[wybór - 1].Value;
                        postać.DodajMiksturę(Druid.mikstury[wybór - 1].Key);
                    }
                }
            }
            catch
            {

            }
        }
    }
}