using Airport.Controllers.Airline;
using Airport.Controllers.Airplane;
using Airport.Controllers.Flights;
using Airport.Controllers.Ticket;
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

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            _ticketSellingController.TicketAddCart(
                FlightHelper.idFlight,
                Passport_TextBox.Text,
                PlaceOfissuePassport_TextBox.Text,
                new DateTime(Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[0])),
                FIO_TextBox.Text.Split()[0],
                FIO_TextBox.Text.Split()[1],
                FIO_TextBox.Text.Split()[2],
                new DateTime(Convert.ToInt32(DateOfBirth_DatePicker.Text.Split('.')[2]), Convert.ToInt32(PassportIssueDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(DateOfBirth_DatePicker.Text.Split('.')[0])),
                1,
                Email_TextBox.Text,
                1
                );
        }
    }
}
