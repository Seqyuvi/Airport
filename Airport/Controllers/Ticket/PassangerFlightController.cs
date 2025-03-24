using Airport.Models;
using Airport.Repositories.RegistrationTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Ticket
{
    public class PassangerFlightController
    {
        private readonly TicketSellingRepository _ticketSellingRepository;
        public PassangerFlightController()
        {
            _ticketSellingRepository = new TicketSellingRepository();
        }

        public List<TicketsSelling> GetAll(int flightNumber)
        {
            return _ticketSellingRepository.GetByFligth(flightNumber);
        } 
    }
}
