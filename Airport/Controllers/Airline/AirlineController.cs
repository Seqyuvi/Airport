using Airport.Repositories.Airline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Airline
{
    public class AirlineController
    {
        private readonly AirlineRepository _airlineRepository;
        public AirlineController()
        {
            _airlineRepository = new AirlineRepository();
        }

        public List<Models.Airlines> GetAllAirlines()
        {
            return _airlineRepository.GetAll();
        } 
    }
}
