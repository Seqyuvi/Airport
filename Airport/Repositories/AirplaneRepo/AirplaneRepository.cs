using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories.AirplaneRepo
{
    public class AirplaneRepository
    {
        private readonly Core _db;
        public AirplaneRepository()
        {
            _db = new Core();
        }

        public List<Airplane> GetAll()
        {
            return _db.context.Airplane.ToList();
        }
    }
}
