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
        public string Overview { get; private set; }
        public string Name { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public float SoftwareHouseId { get; private set; }
        
        public Videogame(float id, string overview, string name, DateOnly releaseDate, DateTime createdAt, DateTime updatedAt, float softwareHouseId)
        {
            this.Id = id;
            this.Overview = overview;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
