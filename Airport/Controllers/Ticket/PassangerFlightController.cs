using Airport.Models;
using Airport.Repositories.RegistrationTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Ticket
{
    public class PassangerFlightController
    {
        private readonly TicketSellingRepository _ticketSellingRepository;
        public PassangerFlightController()
        {
            _ticketSellingRepository = new TicketSellingRepository();
        }

        public List<TicketsSelling> GetAll(int flightNumber)
        {
            try
            {
                return _ticketSellingRepository.GetByFligth(flightNumber);

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

        public List<Models.TicketsSelling> GetByIdTicket(List<int> id)
        {
            try
            {
                return _ticketSellingRepository.GetById(id);

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

    public List<Models.TicketsSelling> GetAllTicket()
        {
            return _ticketSellingRepository.GetAll();
        }

        public bool Delete(int id)
        {

            return _ticketSellingRepository.Delete(id);
        }
    }
}
