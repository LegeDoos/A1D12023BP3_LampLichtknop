using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LampLichtknop.DataAccessLayer
{


    /// <summary>
    /// Dit is de data access laag en is de 
    /// laag die de data ophaalt en wegschrijft
    /// Dit is een soort "tolk"
    /// </summary>
    public class DAL
    {
        string connectionString = "Data Source=.;Initial Catalog=BP3LampLichtknop;Integrated Security=true";

        public List<Lichtknop> Lichtknoppen { get; set; } = new List<Lichtknop>();

        public void VoegTestDataToe()
        {
            Lichtknop lichtknop = new Lichtknop(1, "Lichtknop uit de DAL");
            Lichtknoppen.Add(lichtknop);
        }


        public void CreateLightswitch(Lichtknop lichtknop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "insert into LichtKnop (Aanuit, Beschrijving, Dimpercentage, Type) values (@AanUit, @Beschrijving, @Dimpercentage, @type)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Aanuit", lichtknop.AanUit);
                    command.Parameters.AddWithValue("@Beschrijving", lichtknop.Beschrijving);
                    
                    if (lichtknop is DimSchakelaar)
                    {
                        DimSchakelaar dimschakelaar = lichtknop as DimSchakelaar;
                        command.Parameters.AddWithValue("@Dimpercentage", dimschakelaar.DimPercentage);
                        command.Parameters.AddWithValue("@Type", "Dimschakelaar");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Type", "Schakelaar");
                        command.Parameters.AddWithValue("@Dimpercentage", DBNull.Value);
                    }
                    command.ExecuteNonQuery();                    
                }
            }
            ReadLightswitches();
        }


        /// <summary>
        /// Deze method haalt alle gegevens van de lichtknoppen op uit de database die relevant zijn
        /// </summary>
        public void ReadLightswitches()
        {
            Lichtknoppen.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "select id, AanUit, beschrijving, dimpercentage, type from LichtKnop";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // voeg op basis van de reader items toe aan de lichtknoppen lijst
                            int id = reader.GetInt32(0);
                            bool aanuit = reader.GetBoolean(1);
                            string beschrijving = reader.GetString(2);
                            string type = reader.GetString(4);

                            Lichtknop lichtknop;
                            if (type.Equals("Schakelaar"))
                            {
                                lichtknop = new Lichtknop(id, beschrijving);
                            }
                            else
                            {
                                int dimpercentage = reader.GetInt32(3);
                                lichtknop = new DimSchakelaar(id, beschrijving, dimpercentage);
                            }
                            lichtknop.Omzetten();
                            Lichtknoppen.Add(lichtknop);
                        }
                    }
                }

                foreach (var lichtknop in Lichtknoppen)
                {
                    // lampen ophalen
                    string lampenQuery = $"select * from Lamp where LichtknopId = {lichtknop.Id}";
                    using (SqlCommand commandLampen = new SqlCommand(lampenQuery, connection))
                    {
                        using (SqlDataReader readerLampen = commandLampen.ExecuteReader())
                        {
                            while (readerLampen.Read())
                            {
                                Lamp l = new Lamp(lichtknop, readerLampen.GetString(2));
                                lichtknop.LampToevoegen(l);
                            }
                        }
                    }
                }
            }
        }
    }
}
