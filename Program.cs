namespace LampLichtknop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lichtknop> lichtknoppen = new List<Lichtknop>();

            Lichtknop lichtknop = new Lichtknop("Mooie lichtknop");
            lichtknoppen.Add(lichtknop);

            for (int i = 0; i < 5; i++)
            {
                // maak een instantie van een lamp aan
                Lamp lampToevoegen = new Lamp(lichtknop);
                // voeg toe aan de lijst van lampen van de lichtknop
                lichtknop.LampToevoegen(lampToevoegen);
            }

            Lichtknop dimschakelaar = new DimSchakelaar("Mooie dimschakelaar");
            lichtknoppen.Add(dimschakelaar);

            // toon lichtknoppen
            Console.WriteLine("\n\nLichtknoppen:");
            int j = 1;
            foreach (Lichtknop knop in lichtknoppen)
            {
                Console.WriteLine($"Lichtknop {knop.Beschrijving} staat aan: {knop.AanUit} en heeft {knop.Lampen.Count} lampen en heeft als type {knop.GetType()}");
                j++;    
            }


        }
    }
}
