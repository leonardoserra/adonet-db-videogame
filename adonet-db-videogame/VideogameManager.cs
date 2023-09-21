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
        public static Videogame SearchVideogameById(long idSearched)
        {
            
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", idSearched));
                        SqlDataReader data = cmd.ExecuteReader();
                        if (data.Read()==false)
                            throw new NullReferenceException();

                        long id = data.GetInt64(0);
                        string nameFound = data.GetString(1);
                        string overview = data.GetString(2);
                        DateTime date = data.GetDateTime(3);
                        long softwareHouseId = data.GetInt64(4);
                        return new Videogame(id, nameFound, overview, date, softwareHouseId);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            throw new NullReferenceException();
        }


        public static List<Videogame> SearchVideogameByName(string name)
        {
            List<Videogame> videogames = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try
                {
                    string newName = $"%{name}%";
                    connection.Open();
                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name LIKE @Name";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Name", newName));
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            long id = data.GetInt64(0);
                            string nameFound = data.GetString(1);
                            string overview = data.GetString(2);
                            DateTime date = data.GetDateTime(3);
                            long softwareHouseId = data.GetInt64(4);
                            videogames.Add(new Videogame(id, nameFound, overview, date, softwareHouseId));

                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }finally {
                    connection.Close();
                }
            }
            return videogames;
        }

        public static bool InsertVideogame(string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    
                    cmd.Parameters.Add(new SqlParameter("@Name", name));
                    cmd.Parameters.Add(new SqlParameter("@Overview", overview));
                    cmd.Parameters.Add(new SqlParameter("@ReleaseDate", releaseDate));
                    cmd.Parameters.Add(new SqlParameter("@SoftwareHouseId", softwareHouseId));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    connection.Close();
                }
            }
            return false;
        }

        public static bool DeleteVideogame(long idToDelete)
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionInfo))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM videogames WHERE id=@Id";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add(new SqlParameter("@Id", idToDelete));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return false;
        }

    }
}
