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
                nieuweKnop.AddTodatabase();

                DimSchakelaar nieuweDimschakelaar = new DimSchakelaar(0, "Nieuwe dimschakelaar", 33);
                nieuweDimschakelaar.AddTodatabase();


                // toon lichtknoppen
                Console.WriteLine("\n\nLichtknoppen:");
                int j = 1;
                foreach (Lichtknop knop in Lichtknop.ReadLightSwitches())
                {
                    Console.WriteLine($"Lichtknop {knop.Id} met beschrijving {knop.Beschrijving} staat aan: {knop.AanUit} en heeft {knop.Lampen.Count} lampen en heeft als type {knop.GetType()}");
                    j++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Er ging iets mis. De foutmelding was 'dit'. Neem contact op met de service desk!");
                //throw;
            }
            finally
            {
                Console.WriteLine("Wel leuk dat je onze applicatie gebruikt!");
            }


        }
    }
}
