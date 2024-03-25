using LampLichtknop.DataAccessLayer;

namespace LampLichtknop
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Lichtknop nieuweKnop = new Lichtknop(0, "Nieuwe lichtknop");
                nieuweKnop.Omzetten();
                nieuweKnop.Beschrijving = "Ik geef een andere beschrijving!"; // dit kan en mag gewoon want de setter is public (by design)
                nieuweKnop.AddToDatabase();
               
                DimSchakelaar nieuweDimschakelaar = new DimSchakelaar(0, "Nieuwe dimschakelaar", 33);
                nieuweDimschakelaar.AddToDatabase();

                // toon lichtknoppen
                Console.WriteLine("\n\nLichtknoppen:");
                int j = 1;
                foreach (Lichtknop knop in Lichtknop.ReadLightSwitches()) // haal zo laat mogelijk de gegevens op uit de database
                {
                    Console.WriteLine($"Lichtknop {knop.Id} met beschrijving {knop.Beschrijving} staat aan: {knop.AanUit} en heeft {knop.Lampen.Count} lampen en heeft als type {knop.GetType()}");
                    j++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Er ging iets mis. Neem contact op met de service desk!");
                //throw;
            }
            finally
            {
                Console.WriteLine("Wel leuk dat je onze applicatie gebruikt!");
            }


        }
    }
}
