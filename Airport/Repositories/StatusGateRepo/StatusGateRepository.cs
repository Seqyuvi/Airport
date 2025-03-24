using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Repositories.StatusGateRepo
{
    public class StatusGateRepository
    {
        private readonly Core _db;
        public StatusGateRepository()
        {
            _db = new Core();
        }

        public List<StatusGate> GetAll()
        {
            return _db.context.StatusGate.ToList();
        }

        public StatusGate GetByTitle(string title)
        {
            return _db.context.StatusGate.FirstOrDefault(x => x.StatusTitile == title);
        }
    }
}
