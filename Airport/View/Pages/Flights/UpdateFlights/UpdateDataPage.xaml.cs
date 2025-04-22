using Airport.Controllers.Flights;
using Airport.Controllers.Flights.UpdateController;
using Airport.Helpers.ModelHelper;
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

namespace Airport.View.Pages.Flights.UpdateFlights
{
    /// <summary>
    /// Логика взаимодействия для UpdateDataPage.xaml
    /// </summary>
    public partial class UpdateDataPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly UpdateController _updateController;
        public UpdateDataPage()
        {
            InitializeComponent();
            _moreInformationFlightController = new MoreInformationFlightController();
            _updateController = new UpdateController();
            var information = _moreInformationFlightController.GetMore(FlightHelper.idFlight);
            ArrivalDate_DatePicker.Watermark = information.ArrivalDate;
            DepartureDate_DatePicker.Watermark = information.DepartureDate;
            ArrivalTime_DatePicker.Watermark = information.ArrivalTime;
            DepartureTime_DatePicker.Watermark = information.DepartureTime;
        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            var depDate = DepartureDate_DatePicker.Text != null ?  new DateTime(Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[0])) : new DateTime();
            var arrDate = ArrivalDate_DatePicker.Text != null ? new DateTime(Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[0])) : new DateTime();
            var depTime = DepartureTime_DatePicker.Text != null ? new TimeSpan(Convert.ToInt32(DepartureTime_DatePicker.Text.Split(':')[0]), Convert.ToInt32(DepartureTime_DatePicker.Text.Split(':')[1]), 0) : new TimeSpan();
            var arrTime = ArrivalTime_DatePicker.Text != null ? new TimeSpan(Convert.ToInt32(ArrivalTime_DatePicker.Text.Split(':')[0]), Convert.ToInt32(ArrivalTime_DatePicker.Text.Split(':')[1]), 0) : new TimeSpan();
            var resultUp = _updateController.Update2(
                FlightHelper.idFlight, arrDate, depDate, arrTime, depTime
            );

            if (resultUp == true)
            {
                var result = MessageBox.Show("Успешно обновлено, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new UpdateFlightButtonPage());
                }
                else
                {
                    this.NavigationService.Navigate(new UpdateDataPage());
                }
            }
        }
    }
}
