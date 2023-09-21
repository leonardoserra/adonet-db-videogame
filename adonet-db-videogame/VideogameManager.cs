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
                    string query = "SELECT id, name, overview FROM videogames";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using(SqlDataReader data = cmd.ExecuteReader()) {
                        while (data.Read())
                        {
                            float id = data.GetInt64(0);
                            string name = data.GetString(1);
                            string overview = data.GetString(2);

                            videogames.Add(new Videogame(id, name, overview));

                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return videogames;
        } 
    }
}
