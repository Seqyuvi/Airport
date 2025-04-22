using Airport.Repositories.RegistrationTicket;
using Airport.ViewModel.RegistrationViewModel;
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
                var ticket = _ticketSellingRepository.GetAll().FirstOrDefault(x => x.IdFlight == idFlight
                && x.PassportNumber == passportNumber
                && x.FirstName == firstName
                && x.SecondName == secondName
                && x.DateOfBirth == dateOfBirth
                );
            
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
                return false;
            }
        }

        public List<RegistrationViewModel> GetAllRegistration(int type = 0, int flightId = 0)
        {
            switch (type)
            {
                case 1:
                    return _registrationRepository.GetAll();
                    case 2:
                    return _registrationRepository.GetAllByFlightId(flightId);
                    default:
                    return new List<RegistrationViewModel>();

            }
        }

        public bool CancelledReg(int idRegistration)
        {
            try
            {
                 return _registrationRepository.Cancel(idRegistration);

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка отмены регистрации: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false ;
            }
        }

        public bool DeleteReg(int idRegistration)
        {
            try
            {
                return _registrationRepository.Delete(idRegistration);

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка удаления регистрации: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }
    }
}
