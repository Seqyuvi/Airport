using Airport.Controllers.Flights;
using Airport.Helpers.ModelHelper;
using Airport.validation.GeneralValid;
using Airport.View.Pages.Flights.UpdateFlights;
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

namespace Airport.View.Pages.Flights
{
    /// <summary>
    /// Логика взаимодействия для FindFlightPage.xaml
    /// </summary>
    public partial class FindFlightPage : Page
    {
        private readonly FindFlightController _findFlightController;
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly AllFlightsController _allFlightsController;
        public FindFlightPage()
        {
            InitializeComponent();
            FlightHelper.idFlight = 0;
            
			_findFlightController = new FindFlightController();
            _moreInformationFlightController = new MoreInformationFlightController();
            _allFlightsController = new AllFlightsController();
        }

        private bool Validate()
        {
            string errorMessage = "";
            if(FlightInformation_TextBox.Text == "") { errorMessage += "Поле ввода пустое.\n"; }
            if(AirportTitle_RadioButton.IsChecked == false && NumberFlights_RadioButton.IsChecked == false) { errorMessage += "Вы не выбрали тип поиска.\n"; }
            if(NumberFlights_RadioButton.IsChecked == true)
            {
                if (!GeneralValidationRule.ValidateFlightNumber(FlightInformation_TextBox.Text))
                {
                    errorMessage += "Неправильный ввод номера рейса.\n";
                }
            }
            if (errorMessage != "")
            {
                System.Windows.MessageBox.Show(
                $"Обнаружены следующие ошибки:\n\n{errorMessage}",
                "Ошибка валидации",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
                    );
                return false;
            }
            return true;
        }


        private void Find_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {

                if (AirportTitle_RadioButton.IsChecked == true)
                {
                    var result = _findFlightController.FindFlight(2, FlightInformation_TextBox.Text) == null ? new List<Models.Flights>() : _findFlightController.FindFlight(2, FlightInformation_TextBox.Text);
                    if (result.Count() == 0)
                    {
                        var resultM = MessageBox.Show("Рейс(-ы) не найден(-ы), попробовать снова?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultM == MessageBoxResult.Yes)
                        {
                            this.NavigationService.Navigate(new FindFlightPage());
                        }
                        else
                        {
                            this.NavigationService.Navigate(new AllFlightsPage());
                        }
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            FindFlightHelper.idFlight.Add(item.IdFlight);
                        }
                        this.NavigationService.Navigate(new AllFlightsPage());
                    }


                }
                else
                {
                    var model = _findFlightController.FindFlight(1, FlightInformation_TextBox.Text) == null ? new List<Models.Flights>() : _findFlightController.FindFlight(1, FlightInformation_TextBox.Text);


                    if (model.Count() == 0)
                    {
                        var resultM = MessageBox.Show("Рейс(-ы) не найден(-ы), попробовать снова?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultM == MessageBoxResult.Yes)
                        {
                            this.NavigationService.Navigate(new FindFlightPage());
                        }
                        else
                        {
                            this.NavigationService.Navigate(new AllFlightsPage());
                        }
                    }
                    else
                    {
                        var id = model.Last().IdFlight;
                        var info = _allFlightsController.GetFlight(id);
                        var item = (new MoreInformationPage(info));
                        this.NavigationService.Navigate(item);
                    }
                }
                
                

                    
            }
        }
    }
}
