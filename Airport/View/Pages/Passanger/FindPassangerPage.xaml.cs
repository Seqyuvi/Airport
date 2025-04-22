using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
using Airport.validation.GeneralValid;
using Airport.View.Pages.Flights;
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
    /// Логика взаимодействия для FindPassangerPage.xaml
    /// </summary>
    public partial class FindPassangerPage : Page
    {
        private readonly FindPassangerController _findPassangerController;
        public FindPassangerPage()
        {
            InitializeComponent();
            FlightHelper.idFlight = 0;
            
			_findPassangerController = new FindPassangerController();
        }


        private bool Validate()
        {
            string errorMessage = "";
            if (FlightInformation_TextBox.Text == "") { errorMessage += "Поле ввода пустое.\n"; }
            if (Fio_RadioButton.IsChecked == false && Passport_RadioButton.IsChecked == false) { errorMessage += "Вы не выбрали тип поиска.\n"; }
            if (Passport_RadioButton.IsChecked == true)
            {
                if (!GeneralValidationRule.PasswordValidate(FlightInformation_TextBox.Text))
                {
                    errorMessage += "Неправильный ввод данных паспорта.\n";
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

                if (Passport_RadioButton.IsChecked == true)
                {
					FindPassangerHelper.idTicket.AddRange(_findPassangerController.FindPassanger(1, FlightInformation_TextBox.Text) == new List<Models.TicketsSelling>() ? new List<int>() : _findPassangerController.FindPassanger(1, FlightInformation_TextBox.Text).Select(x => x.IdTicketSelling));
					if (FindPassangerHelper.idTicket.Count() == 0)
                    {
                        var resultM = MessageBox.Show("Пассажир не найден, попробовать снова?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultM == MessageBoxResult.Yes)
                        {
                            this.NavigationService.Navigate(new FindPassangerPage());
                        }
                        else
                        {
                            this.NavigationService.Navigate(new MainPage());
                        }
                    }
                    else
                    {

                        this.NavigationService.Navigate(new PassangerListPage());
                    }
                }
                else
                {

                    FindPassangerHelper.idTicket.AddRange(_findPassangerController.FindPassanger(2, FlightInformation_TextBox.Text) == new List<Models.TicketsSelling>() ? new List<int>() : _findPassangerController.FindPassanger(2, FlightInformation_TextBox.Text).Select(x => x.IdTicketSelling));
                    if (FindPassangerHelper.idTicket.Count() == 0)
                    {
                        var resultM = MessageBox.Show("Пассажир не найден, попробовать снова?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultM == MessageBoxResult.Yes)
                        {
                            this.NavigationService.Navigate(new FindPassangerPage());
                        }
                        else
                        {
                            this.NavigationService.Navigate(new MainPage());
                        }
                    }
                    else
                    {

                        this.NavigationService.Navigate(new PassangerListPage());
                    }
                }
            }
        }
    }
}
