using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModel.PassangerViewModel
{
    public class PassangerListViewModel
    {
        public int idTicket { get; set; }
        public string PassportNumber { get; set; }
        public string PlaceOfIssue { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
    }
}
