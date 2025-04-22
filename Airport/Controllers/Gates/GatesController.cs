using Airport.Models;
using Airport.Repositories.Flights;
using Airport.Repositories.StatusGateRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Gates
{
    public class GatesController
    {
        private readonly GatesRepository _gatesRepository;
        private readonly StatusGateRepository _statusGateRepository;

        public GatesController()
        {
            _gatesRepository = new GatesRepository();
            _statusGateRepository = new StatusGateRepository();
        }

        public List<Models.Gates> GatesRepository()
        {
            try
            {
                return _gatesRepository.GetAll();

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

        public bool UpdateGateStatus(int idGate, string titleStatus)
        {
            try
            {
                int idStatus = _statusGateRepository.GetByTitle(titleStatus).IdStatusGate;
                var result = _gatesRepository.Update(idGate, idStatus);
                if (result) return true; else return false;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления статуса гейта: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }

        }

        
    }
}
