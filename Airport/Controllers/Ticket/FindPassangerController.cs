using Airport.Repositories.RegistrationTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Ticket
{
    public class FindPassangerController
    {
        private readonly TicketSellingRepository _ticketSellingRepository;
        public FindPassangerController()
        {
            _ticketSellingRepository = new TicketSellingRepository();
        }
        public List<Models.TicketsSelling> FindPassanger(int type, string info)
        {
            return _ticketSellingRepository.FindPassanger(type, info);
        }
    }
}
