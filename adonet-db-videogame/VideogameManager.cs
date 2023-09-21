using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string databaseConnectionInfo = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";

        public static List<Videogame> GetVideogamesList()
        {
            List<Videogame> videogames = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try { 
                    connection.Open();
                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using(SqlDataReader data = cmd.ExecuteReader()) {
                        while (data.Read())
                        {
                            long id = data.GetInt64(0);
                            string name = data.GetString(1);
                            string overview = data.GetString(2);
                            DateTime date = data.GetDateTime(3);
                            long softwareHouseId = data.GetInt64(4);
                            videogames.Add(new Videogame(id, name, overview, date, softwareHouseId));

                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return videogames;
        }

/*        public static bool InsertVideogame(string name)
        {
            
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO videogames (name, overview)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                          

                            

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return false;
        }
*/    }
}
