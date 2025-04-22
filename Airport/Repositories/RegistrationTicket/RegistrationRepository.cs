using Airport.Models;
using Airport.ViewModel.RegistrationViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.RegistrationTicket
{
    public class RegistrationRepository
    {
        private readonly Data.Core _db;
        public RegistrationRepository()
        {
            _db = new Data.Core();
        }

        /// <summary>
        /// Работа с БД. Создание регистрации на рейс
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Create(Registration registration)
        {
            try
            {
                int count = _db.context.Registration.Count();
                _db.context.Registration.Add(registration);
                _db.context.SaveChanges();
                if (count < _db.context.Registration.Count()) return true; else return false;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка создания регистрации: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        /// <summary>
        /// Работа с БД. Удаление регистрации на рейс
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(int idRegistration)
        {
            try
            {
                var item = _db.context.Registration.FirstOrDefault(x => x.IdRegistration == idRegistration);
                _db.context.Registration.Remove(item);
                _db.context.SaveChanges();
                return true;

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

        public bool Cancel(int idRegistration)
        {
            try
            {
                var item = _db.context.Registration.FirstOrDefault(x => x.IdRegistration == idRegistration);
                item.IdStatusRegistration = 4;
                _db.context.SaveChanges();
                return true;

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
                return false;
            }
        }

        /// <summary>
        /// Работа с БД. Получение всех регистраций
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<RegistrationViewModel> GetAll()
        {
            try
            {
                return _db.context.Registration
                    .Include(i => i.Bagage)
                    .Include(i => i.StatusRegistration)
                    .Include(i => i.TicketsSelling)
                    .Include(i => i.TicketsSelling.Flights)
                    .ToList()
                    .Select(s => new RegistrationViewModel
                    {
                        idRegistration = s.IdRegistration,
                        FlightNumber = s.TicketsSelling.Flights.FlightNumber,
                        PassportNumber = s.TicketsSelling.PassportNumber,
                        FirstName = s.TicketsSelling.FirstName,
                        SecondName = s.TicketsSelling.SecondName,
                        Surname = s.TicketsSelling.Surname,
                        BagageCount = s.Bagage.CountBagage,
                        BagageWeight = s.Bagage.WeightBagage,
                        Status = s.StatusRegistration.TitleStatus
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

        public List<RegistrationViewModel> GetAllByFlightId(int idFlight)
        {
            try
            {
                return _db.context.Registration
                    .Include(i => i.Bagage)
                    .Include(i => i.StatusRegistration)
                    .Include(i => i.TicketsSelling)
                    .Include(i => i.TicketsSelling.Flights)
                    .ToList()
                    .Where(w => w.TicketsSelling.Flights.IdFlight == idFlight)
                    .Select(s => new RegistrationViewModel
                    {
                        idRegistration = s.IdRegistration,
                        FlightNumber = s.TicketsSelling.Flights.FlightNumber,
                        PassportNumber = s.TicketsSelling.PassportNumber,
                        FirstName = s.TicketsSelling.FirstName,
                        SecondName = s.TicketsSelling.SecondName,
                        Surname = s.TicketsSelling.Surname,
                        BagageCount = s.Bagage.CountBagage,
                        BagageWeight = s.Bagage.WeightBagage,
                        Status = s.StatusRegistration.TitleStatus
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
