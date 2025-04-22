using Airport.Controllers.Flights;
using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
using Airport.View.Pages.Flights;
using Airport.ViewModel.FlightsViewModel;
using Airport.ViewModel.PassangerViewModel;
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

namespace Airport.View.Pages.Passanger
{
    /// <summary>
    /// Логика взаимодействия для PassangerListPage.xaml
    /// </summary>
    public partial class PassangerListPage : Page
        
    {
        private readonly PassangerFlightController _passangerFlightController;
        public PassangerListPage()
        {
            InitializeComponent();
			
			_passangerFlightController = new PassangerFlightController();

            if(FlightHelper.idFlight == 0)
            {
                Passanger_DataGrid.ItemsSource = _passangerFlightController.GetAllTicket();
				ClearSearh_Button.Visibility = Visibility.Collapsed;

			}
            else
            {
                Passanger_DataGrid.ItemsSource = _passangerFlightController.GetAll(FlightHelper.idFlight);
				ClearSearh_Button.Visibility = Visibility.Collapsed;
			}
            if(FindPassangerHelper.idTicket.Count() != 0)
            {
                Passanger_DataGrid.ItemsSource = _passangerFlightController.GetByIdTicket(FindPassangerHelper.idTicket);
				ClearSearh_Button.Visibility = Visibility.Visible;
			}

        }

        

        private void DeletePassanger_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // 2. Получаем данные строки из DataContext
                if (button.DataContext is Models.TicketsSelling item)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить \" Пассажира {item.FirstName}\"?",
                        "Подтверждение удаления",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    // Если пользователь подтвердил удаление
                    if (result == MessageBoxResult.Yes)
                    {
                        _passangerFlightController.Delete(item.IdTicketSelling);
                        MessageBox.Show("Элемент удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (FlightHelper.idFlight == 0)
                        {
                            Passanger_DataGrid.ItemsSource = _passangerFlightController.GetAllTicket();
                            ClearSearh_Button.Visibility = Visibility.Collapsed;

                        }
                        else
                        {
                            Passanger_DataGrid.ItemsSource = _passangerFlightController.GetAll(FlightHelper.idFlight);
							ClearSearh_Button.Visibility = Visibility.Collapsed;
						}
                        if (FindPassangerHelper.idTicket.Count() != 0)
                        {
                            Passanger_DataGrid.ItemsSource = _passangerFlightController.GetByIdTicket(FindPassangerHelper.idTicket);
							ClearSearh_Button.Visibility = Visibility.Visible;
						}
                    }
                }
            }

            
        }

		private void ClearSearh_Button_Click(object sender, RoutedEventArgs e)
		{
			Passanger_DataGrid.ItemsSource = _passangerFlightController.GetAllTicket();
			
			ClearSearh_Button.Visibility = Visibility.Collapsed;
		}
	}
}
