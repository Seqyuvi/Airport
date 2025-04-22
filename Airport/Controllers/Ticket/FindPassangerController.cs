using Airport.Repositories.RegistrationTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Ticket
{
    public class FindPassangerController
    {
        private readonly TicketSellingRepository _ticketSellingRepository;
        public FindPassangerController()
        {
            _ticketSellingRepository = new TicketSellingRepository();
        }
        public List<Models.TicketsSelling> FindPassanger(int type, string info)
        {
            try
            {
                return _ticketSellingRepository.FindPassanger(type, info);

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка поиска пассажира(-ов): {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }

        }
    }
}
