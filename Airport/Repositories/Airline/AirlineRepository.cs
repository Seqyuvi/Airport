using Airport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories.Airline
{
    public class AirlineRepository
    {
        private readonly Core _db;
        public AirlineRepository()
        {
            _db = new Core();
        }

        public List<Models.Airlines> GetAll()
        {
            return _db.context.Airlines.ToList();
        }
    }
}
