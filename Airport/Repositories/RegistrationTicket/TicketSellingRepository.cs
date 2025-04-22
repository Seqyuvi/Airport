using Airport.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.RegistrationTicket
{
    public class TicketSellingRepository
    {
        private readonly Data.Core _db;
        public TicketSellingRepository()
        {
            _db = new Data.Core();
        }
        public bool Create(TicketsSelling tickets)
        {
            try
            {
                _db.context.TicketsSelling.Add(tickets);
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка создания билета: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public bool Delete(int numberTicket)
        {
            try
            {
                var item = _db.context.TicketsSelling.FirstOrDefault(x => x.IdTicketSelling == numberTicket);
                _db.context.TicketsSelling.Remove(item);
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка удаления билета: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public List<TicketsSelling> GetAll()
        {
            try
            {
                return _db.context.TicketsSelling.ToList();

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

        public List<TicketsSelling> GetById(List<int> id)
        {
            try
            {
                List<TicketsSelling> result = new List<TicketsSelling>();
                foreach(var item in id)
                {
                    result.Add(_db.context.TicketsSelling.First(x => x.IdTicketSelling == item));
                }
                return result;

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

        public List<TicketsSelling> GetByFligth(int flight)
        {
            try
            {
                return _db.context.TicketsSelling.Where(x => x.IdFlight == flight).ToList();

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

        public List<TicketsSelling> FindPassanger(int findType, string findInformation)
        {
            try
            {
                switch (findType)
                {
                    case 1:
                        return _db.context.TicketsSelling.Where(x => x.PassportNumber.ToUpper().Contains(findInformation.ToUpper())).ToList().Count() > 0
                            ? _db.context.TicketsSelling.Where(x => x.PassportNumber.ToUpper().Contains(findInformation.ToUpper())).ToList()
                            : new List<TicketsSelling>();
                    case 2:
                        return _db.context.TicketsSelling.Where(x => x.FirstName.ToUpper().Contains(findInformation.ToUpper()) || x.SecondName.ToUpper().Contains(findInformation.ToUpper()) || x.Surname.ToUpper().Contains(findInformation.ToUpper())).ToList().Count() > 0
                            ? _db.context.TicketsSelling.Where(x => x.FirstName.ToUpper().Contains(findInformation.ToUpper()) || x.SecondName.ToUpper().Contains(findInformation.ToUpper()) || x.Surname.ToUpper().Contains(findInformation.ToUpper())).ToList()
                            : new List<TicketsSelling>();

                }
                return null;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка поиска пассажира: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }
    }
}
