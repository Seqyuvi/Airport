using Airport.Repositories.RegistrationTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Registration
{
    public class RegistrationController
    {
        private readonly RegistrationRepository _registrationRepository;
        private readonly TicketSellingRepository _ticketSellingRepository;
        private readonly BagageRepository _bagageRepository;
        public RegistrationController()
        {
            _registrationRepository = new RegistrationRepository();
            _ticketSellingRepository = new TicketSellingRepository();
            _bagageRepository = new BagageRepository();
        }

        public bool IsRegistered(int idFlight, string passportNumber, string placeOfIssue, DateTime dateOfIssue,
            string firstName, string secondName, string surName, DateTime dateOfBirth, int countBagage, int weightBagage)
        {
            try
            {
                var ticket = _ticketSellingRepository.GetAll().FirstOrDefault(x => x.IdFlight == idFlight && x.PassportNumber == passportNumber);
            
                if(ticket != null)
                {
                    var result1 = _bagageRepository.Create
                        (
                            new Models.Bagage
                            {
                                CountBagage = countBagage,
                                WeightBagage = weightBagage
                            }
                        );

                    var result2 = _registrationRepository.Create
                     (
                        new Models.Registration
                        {
                            IdBagage = _bagageRepository.GetAll().Last().IdBagage,
                            IdStatusRegistration = 1,
                            IdTicketSelling = ticket.IdTicketSelling
                        }
                     );
                    if (result1 && result2) return true; else return false;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка Регистрации на рейс: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка регистрации на рейс:{ex.Message}");
            }
        }
    }
}
