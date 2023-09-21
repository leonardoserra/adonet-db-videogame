using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public float Id { get; private set; }
        public string Name { get; private set; }
        public string Overview { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public float SoftwareHouseId { get; private set; }
        
        public Videogame(float id, string name, string overview, DateOnly releaseDate, float softwareHouseId)
        {
            this.Id = id;
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $@"ID: {Id}, {Name}

                    {Overview} 

                    {ReleaseDate}";
        }
    }
}
