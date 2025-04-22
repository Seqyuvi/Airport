using Airport.Controllers.Registration;
using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
using Airport.ViewModel.PassangerViewModel;
using Airport.ViewModel.RegistrationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport.View.Pages.Registration
{
    /// <summary>
    /// Логика взаимодействия для AllRegistrationPassangerPage.xaml
    /// </summary>
    public partial class AllRegistrationPassangerPage : Page
    {
        private readonly RegistrationController _registrationController;
        public AllRegistrationPassangerPage()
        {
            InitializeComponent();
			
			_registrationController = new RegistrationController();
            if (FlightHelper.idFlight == 0)
            {
                Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(1);

            }
            else
            {
                Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(2, FlightHelper.idFlight);
            }
        }

        private void DeletePassanger_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // 2. Получаем данные строки из DataContext
                if (button.DataContext is RegistrationViewModel item)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить \" Пассажира {item.FirstName}\"?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    // Если пользователь подтвердил удаление
                    if (result == MessageBoxResult.Yes)
                    {
                        _registrationController.DeleteReg(item.idRegistration);
                        MessageBox.Show("Элемент удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (FlightHelper.idFlight == 0)
                        {
                            Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(1);

                        }
                        else
                        {
                            Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(2, FlightHelper.idFlight);
                        }
                    }
                }
            }
        }

        private void CancelRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // 2. Получаем данные строки из DataContext
                if (button.DataContext is RegistrationViewModel item)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите отменить регистрацию \" Пассажира {item.FirstName}\"?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    // Если пользователь подтвердил удаление
                    if (result == MessageBoxResult.Yes)
                    {
                        _registrationController.CancelledReg(item.idRegistration);
                        MessageBox.Show("Элемент удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (FlightHelper.idFlight == 0)
                        {
                            Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(1);

                        }
                        else
                        {
                            Passanger_DataGrid.ItemsSource = _registrationController.GetAllRegistration(2, FlightHelper.idFlight);
                        }
                    }
                }
            }
        }
    }
}
