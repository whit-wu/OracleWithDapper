using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleWithDapper.Models
{
    public class GameCatalog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ESRB_Rating { get; set; }

    }
}
