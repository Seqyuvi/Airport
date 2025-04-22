using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModel.RegistrationViewModel
{
    public class RegistrationViewModel
    {
        public int idRegistration { get; set; }
        public string FlightNumber { get; set; }
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int? BagageCount { get; set; }
        public int? BagageWeight { get; set; }
        public string Status { get; set; }
    }
}
