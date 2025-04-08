using Airport.Repositories.AirplaneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Airplane
{
    
    public class AirplaneController
    {
        private readonly AirplaneRepository _airplaneRepository;
        public AirplaneController()
        {
            _airplaneRepository = new AirplaneRepository();
        }

        public List<Models.Airplane> GetAllAirplane()
        {
            return _airplaneRepository.GetAll();
        }
    }
}
