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
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Overview { get; private set; }
        public DateTime ReleaseDate{ get; private set; }
        public long SoftwarehouseId{ get; private set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwarehouseId)
        {
            this.Id = id;
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.SoftwarehouseId = softwarehouseId;
        }

        public override string ToString()
        {
            return $"ID: {Id},\r\nName: {Name}";
        }
    }
}
