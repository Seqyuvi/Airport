using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories.AirportRepo

{
    public class AirportsRepository
    {
        public readonly Core _db;
        public AirportsRepository()
        {
            _db = new Core();
        }

        public List<Airports> GetAll()
        {
            var result = _db.context.Airports.ToList();
            return result;
        }
    }
}
