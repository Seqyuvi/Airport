using Airport.Controllers.Booking;
using Airport.Repositories.Flight;
using Airport.Repositories.RegistrationTicket;
using Airport.ViewModel.PassangerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Ticket
{
    public class TicketSellingController
    {
        private readonly TicketSellingRepository _ticketSellingRepository;
        private readonly BookingTicketsController _bookingTicketsController;
        private readonly FlightsRepository _flightsRepository;
        public TicketSellingController()
        {
            _ticketSellingRepository = new TicketSellingRepository();
            _bookingTicketsController = new BookingTicketsController();
            _flightsRepository = new FlightsRepository();
        }

        public bool TicketBuy(int idFlight, string passportNumber, string placeOfIssue, DateTime dateOfIssue,
            string firstName, string secondName, string surName, DateTime dateOfBirth, int formOfPayment, string email)
        {
            try
            {
                var lastTicket = _ticketSellingRepository.GetAll().Last();
                _ticketSellingRepository.Create
                    (
                        new Models.TicketsSelling
                        {
                            IdFlight = idFlight,
                            NumberTicket = lastTicket.NumberTicket + 1,
                            PassportNumber = passportNumber,
                            PlaceOfIssue = placeOfIssue,
                            DateOfIssue = dateOfIssue,
                            FirstName = firstName,
                            SecondName = secondName,
                            Surname = surName,
                            DateOfBirth = dateOfBirth,
                            BagageCount = 2,
                            FormOfPaymentId = formOfPayment,
                            Email = email

                        }
                    );
                
                
                var result = _bookingTicketsController.TicketPlusBooking(lastTicket.NumberTicket + 1);
                _flightsRepository.UpdateTotalSeatsFree(idFlight);
                if (result) return true; else return false;

            }
            catch ( Exception ex )
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка покупки билета: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка покупки билета:{ex.Message}");
            }
        }


        public List<PassangerListViewModel> AllListOfPassanger()
        {
            return _ticketSellingRepository.GetAll().Select(x => new PassangerListViewModel
            {
                PassportNumber = x.PassportNumber,
                PlaceOfIssue = x.PlaceOfIssue,
                DateOfIssue = x.DateOfIssue,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Surname = x.Surname
            }).ToList();
        }

        public List<PassangerListViewModel> PassangerByFlight(int idFlight)
        {
            return _ticketSellingRepository.GetByFligth(idFlight).Select(x => new PassangerListViewModel
            {
                PassportNumber = x.PassportNumber,
                PlaceOfIssue = x.PlaceOfIssue,
                DateOfIssue = x.DateOfIssue,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Surname = x.Surname
            }).ToList();
        }

        public List<PassangerListViewModel> FindPassanger(int type, string info)
        {
            return _ticketSellingRepository.FindPassanger(type, info).Select(x => new PassangerListViewModel
            {
                PassportNumber = x.PassportNumber,
                PlaceOfIssue = x.PlaceOfIssue,
                DateOfIssue = x.DateOfIssue,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Surname = x.Surname
            }).ToList();
        }
    }
}
