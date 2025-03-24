using Airport.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Repositories.RegistrationTicket
{
    public class TicketSellingRepository
    {
        private readonly Data.Core _db;
        public TicketSellingRepository()
        {
            _db = new Data.Core();
        }
        public bool Create(TicketsSelling tickets)
        {
            _db.context.TicketsSelling.Add(tickets);
            _db.context.SaveChanges();
            return true;
        }

        public Task<bool> Delete(int numberTicket)
        {
            throw new NotImplementedException();
        }

        public List<TicketsSelling> GetAll()
        {
            return _db.context.TicketsSelling.ToList();
        }

        public Task<TicketsSelling> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TicketsSelling> GetByFligth(int flight)
        {
            return _db.context.TicketsSelling.Where(x => x.IdFlight == flight).ToList();
        }

        public List<TicketsSelling> FindPassanger(int findType, string findInformation)
        {
            switch (findType)
            {
                case 1:
                    return _db.context.TicketsSelling.Where(x => x.PassportNumber.Contains(findInformation)).ToList();
                case 2:
                    return _db.context.TicketsSelling.Where(x => x.FirstName.Contains( findInformation )|| x.SecondName.Contains(findInformation) || x.Surname.Contains(findInformation)).ToList();

            }
            return null;
        }
    }
}
