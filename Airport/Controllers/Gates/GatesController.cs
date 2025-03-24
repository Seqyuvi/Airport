using Airport.Models;
using Airport.Repositories.Flights;
using Airport.Repositories.StatusGateRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Gates
{
    public class GatesController
    {
        private readonly GatesRepository _gatesRepository;
        private readonly StatusGateRepository _statusGateRepository;

        public GatesController()
        {
            _gatesRepository = new GatesRepository();
            _statusGateRepository = new StatusGateRepository();
        }

        public List<Models.Gates> GatesRepository()
        {
            return _gatesRepository.GetAll();
        }

        public bool UpdateGateStatus(int idGate, string titleStatus)
        {
            int idStatus = _statusGateRepository.GetByTitle(titleStatus).IdStatusGate;
            _gatesRepository.Update(idGate, idStatus);
            return true;

        }
    }
}
