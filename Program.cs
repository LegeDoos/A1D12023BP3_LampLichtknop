using LampLichtknop.DataAccessLayer;

namespace LampLichtknop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL dal = new DAL();
            //dal.VoegTestDataToe();
            dal.DataOphalen();


            //Lichtknop lichtknop = new Lichtknop("Mooie lichtknop");
            //dal.Lichtknoppen.Add(lichtknop);
            //
            //for (int i = 0; i < 5; i++)
            //{
            //    // maak een instantie van een lamp aan
            //    Lamp lampToevoegen = new Lamp(lichtknop);
            //    // voeg toe aan de lijst van lampen van de lichtknop
            //    lichtknop.LampToevoegen(lampToevoegen);
            //}
            //
            //Lichtknop dimschakelaar = new DimSchakelaar("Mooie dimschakelaar");
            //dal.Lichtknoppen.Add(dimschakelaar);

            // toon lichtknoppen
            Console.WriteLine("\n\nLichtknoppen:");
            int j = 1;
            foreach (Lichtknop knop in dal.Lichtknoppen)
            {
                Console.WriteLine($"Lichtknop {knop.Id} met beschrijving {knop.Beschrijving} staat aan: {knop.AanUit} en heeft {knop.Lampen.Count} lampen en heeft als type {knop.GetType()}");
                j++;    
            }


        }
    }
}
