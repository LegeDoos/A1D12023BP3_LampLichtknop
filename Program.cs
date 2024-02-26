namespace LampLichtknop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lichtknop lichtknop = new Lichtknop();
            
            Lamp lamp1 = new Lamp(lichtknop);
            Lamp lamp2 = new Lamp(lichtknop);
            lichtknop.LampToevoegen(lamp1);
            lichtknop.LampToevoegen(lamp2);

            for (int i = 0; i < 100; i++)
            {
                lichtknop.LampToevoegen(new Lamp(lichtknop));
            }

            lichtknop.Omzetten();
           
            Console.WriteLine($"De lichtknop staat: {lichtknop.AanUit}");
            foreach (var lamp in lichtknop.Lampen)
            {
                Console.WriteLine($"Lamp staat aan = {lamp.AanUit}");
            }


        }
    }
}
