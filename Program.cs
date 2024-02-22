namespace LampLichtknop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "teststring";
            List<string> list = new List<string>();
            
            Lichtknop lichtknop = new Lichtknop();
            lichtknop.Omzetten();
            Console.WriteLine($"De lichtknop staat: {lichtknop.aanUit}");


        }
    }
}
