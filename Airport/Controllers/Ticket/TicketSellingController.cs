using Airport.Controllers.Booking;
using Airport.Helpers.ModelHelper;
using Airport.Models;
using Airport.Repositories.Flight;
using Airport.Repositories.RegistrationTicket;
using Airport.ViewModel.PassangerViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

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

        public bool TicketBuy(Models.TicketsSelling model)
        {
            try
            {
                //TicketPrintWord(model);
                _ticketSellingRepository.Create
                    (
                       model
                    );
                var result = _bookingTicketsController.TicketPlusBooking(model.IdTicketSelling);
                
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

       

        private bool TicketPrintWord( TicketsSelling model)
        {
            try
            {
                Word.Application application = new Word.Application();
                Word.Document document = application.Documents.Open($"{AppDomain.CurrentDomain.BaseDirectory}" +
                    $"\\Docs\\TicketWord\\ElectroTicket.docx");

                document.Bookmarks["date"].Range.Text = DateTime.Now.ToString("dd-MM-yyyy");
                document.Bookmarks["name"].Range.Text = model.FirstName + " " + model.SecondName + " " + model.Surname;
                document.Bookmarks["NumberTicket"].Range.Text = Convert.ToString(model.NumberTicket);
                document.Bookmarks["BookingNumber"].Range.Text = BookingMiodelHelper.BookingCode;
                document.Bookmarks["Place"].Range.Text = _flightsRepository.GetFlightInformation(model.IdFlight).AirportDeparture + "/" + _flightsRepository.GetFlightInformation(model.IdFlight).AirportArrival;
                document.Bookmarks["Flight"].Range.Text = _flightsRepository.GetFlightInformation(model.IdFlight).FlightNumber;
                document.Bookmarks["CL"].Range.Text = "Ec";
                document.Bookmarks["DateDep"].Range.Text = _flightsRepository.GetFlightInformation(model.IdFlight).DepartureDate;
                document.Bookmarks["TimeDep"].Range.Text = _flightsRepository.GetFlightInformation(model.IdFlight).DepartureTime;
                document.Bookmarks["TARIF"].Range.Text = "Не знаю";
                document.Bookmarks["Bagage"].Range.Text = Convert.ToString(model.BagageCount);
                document.Bookmarks["FormPay"].Range.Text = model.FormOfPaymentId == 1 ? "Card" : "Cash";
                document.Bookmarks["TarifCalc"].Range.Text = "Не знаю";
                document.Bookmarks["Fare"].Range.Text = "Не знаю";
                document.Bookmarks["Tax"].Range.Text = "Не знаю";
                Random rnd = new Random();
                document.Bookmarks["Total"].Range.Text = Convert.ToString(rnd.Next(50000));

                var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Docs\\Ticket_{DateTime.Now.ToString("dd-MM-yyyy")}_{DateTime.Now.ToString("HH-mm-ss")}.docx";
                document.SaveAs(path);
                
                if (File.Exists(path))
                {
                    
                    application.Quit();

					return true;
                }
                else return false;
                 
                

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка выписки билета: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }

        }

        private Models.TicketsSelling GetLastTicket()
        {
            try
            {
                return _ticketSellingRepository.GetAll().Last();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        public bool TicketAddCart(int idFlight, string passportNumber, string placeOfIssue, DateTime dateOfIssue,
            string firstName, string secondName, string surName, DateTime dateOfBirth, int formOfPayment, string email, int ticketCount )
        {
            try
            {
                var count = TickerSellingCartServiceHelper.ListTicket.Count();

				var lastTicket = GetLastTicket();
                TickerSellingCartServiceHelper.ListTicket.Add
                    (
                        new Models.TicketsSelling
                        {
                            IdFlight = idFlight,
                            NumberTicket = lastTicket.NumberTicket + ticketCount + 1,
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


                 var result = _flightsRepository.UpdateTotalSeatsFree(idFlight);
                if (result && count < TickerSellingCartServiceHelper.ListTicket.Count()) return true; else return false;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка добавления билета: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }


        public List<PassangerListViewModel> AllListOfPassanger()
        {
            try
            {
            return _ticketSellingRepository.GetAll().Select(x => new PassangerListViewModel
            {
                idTicket = x.IdTicketSelling,
                PassportNumber = x.PassportNumber,
                PlaceOfIssue = x.PlaceOfIssue,
                DateOfIssue = x.DateOfIssue,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Surname = x.Surname
            }).ToList();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        public List<PassangerListViewModel> PassangerByFlight(int idFlight)
        {
            try
            {
                return _ticketSellingRepository.GetByFligth(idFlight).Select(x => new PassangerListViewModel
                {
                    idTicket = x.IdTicketSelling,
                    PassportNumber = x.PassportNumber,
                    PlaceOfIssue = x.PlaceOfIssue,
                    DateOfIssue = x.DateOfIssue,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    Surname = x.Surname
                }).ToList();

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        public List<PassangerListViewModel> FindPassanger(int type, string info)
        {
            try
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
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }
    }
}
