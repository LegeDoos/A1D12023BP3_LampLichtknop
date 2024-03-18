using LampLichtknop.DataAccessLayer;

namespace LampLichtknop
{
    internal class Program
    {
        static void Main()
        {
            DAL dal = new DAL();
            dal.ReadLightswitches();


            Lichtknop nieuweKnop = new Lichtknop(0, "Nieuwe lichtknop");
            nieuweKnop.Omzetten();
            dal.CreateLightswitch(nieuweKnop);

            DimSchakelaar nieuweDimschakelaar = new DimSchakelaar(0, "Nieuwe dimschakelaar", 33);
            dal.CreateLightswitch(nieuweDimschakelaar);

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
