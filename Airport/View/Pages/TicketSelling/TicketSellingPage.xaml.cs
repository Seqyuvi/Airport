using Airport.Controllers.Airline;
using Airport.Controllers.Airplane;
using Airport.Controllers.Flights;
using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
using Airport.validation.GeneralValid;
using Airport.View.Pages.Flights;
using Airport.View.Pages.Passanger;
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

namespace Airport.View.Pages.TicketSelling
{
    /// <summary>
    /// Логика взаимодействия для TicketSellingPage.xaml
    /// </summary>
    public partial class TicketSellingPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly TicketSellingController _ticketSellingController;
        public TicketSellingPage()
        {
            InitializeComponent();
            
            _moreInformationFlightController = new MoreInformationFlightController();
            _ticketSellingController = new TicketSellingController();
            

            var information = _moreInformationFlightController.GetMore(FlightHelper.idFlight);
            AirLines_TextBlock.Text = information.AirLine;
            Airplane_TextBlock.Text = information.Airplane;
            TotalSeats_TextBlock.Text = information.TotalSeats.ToString();
            TotalSeatsFree_TextBlock.Text = information.TotalSeatsFree.ToString();
            Status_TextBlock.Text = information.Status;
            GateNumber_TextBlock.Text = information.GateNumber;
            DepartureDate_TextBlock.Text = information.DepartureDate;
            DepartureTime_TextBlock.Text = information.DepartureTime;


        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private bool Validate()
        {
            string errorMessage = "";
            if (!GeneralValidationRule.BasicValidate(Passport_TextBox.Text) || !GeneralValidationRule.PasswordValidate(Passport_TextBox.Text))
            {
                errorMessage += "Поле паспорта либо не заполнено, либо неправильная запись.\n";
            }
            if (!GeneralValidationRule.BasicValidate(PlaceOfissuePassport_TextBox.Text)) { errorMessage += "Место выдачи паспорта пустое.\n"; }
            if (PassportIssueDate_DatePicker.Text == null) { errorMessage += "Дата выдачи паспорта не выбрана.\n"; }
            if (!GeneralValidationRule.BasicValidate(FIO_TextBox.Text)) { errorMessage += "Поле с ФИО не заполнено.\n"; }
            if (DateOfBirth_DatePicker.Text == null) { errorMessage += "Дата рождения не выбрана.\n"; }
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

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var FIO = FIO_TextBox.Text.Trim() + " User" + " User";
                var resultAdd = _ticketSellingController.TicketAddCart(
                    FlightHelper.idFlight,
                    Passport_TextBox.Text,
                    PlaceOfissuePassport_TextBox.Text,
                    new DateTime(Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[0])),
                    FIO.Split()[0] == "User" ? "" : FIO.Split()[0],
                    FIO.Split()[1] == "User" ? "" : FIO.Split()[1],
                    FIO.Split()[2] == "User" ? "" : FIO.Split()[2],
                    new DateTime(Convert.ToInt32(DateOfBirth_DatePicker.Text.Split('.')[2]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(DateOfBirth_DatePicker.Text.Split('.')[0])),
                    1,
                    Email_TextBox.Text,
                    1
                    );

                if (resultAdd == true)
                {
                    var result = System.Windows.MessageBox.Show("Успешно зарегистрирован, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.NavigationService.Navigate(new AllFlightsPage());
                    }
                    else
                    {
                        this.NavigationService.Navigate(new TicketSellingPage());
                    }
                }
            }
        }

        private void AllTicket_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PassangerListPage());
        }
    }
}
