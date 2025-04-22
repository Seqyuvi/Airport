using Airport.Controllers.Flights;
using Airport.Controllers.Registration;
using Airport.Helpers.ModelHelper;
using Airport.validation.GeneralValid;
using Airport.View.Pages.Flights;
using Airport.View.Pages.Passanger;
using Airport.View.Pages.Registration;
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

namespace Airport.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly RegistrationController _registrationController;
        private readonly MoreInformationFlightController _moreInformationFlightController;
        public RegistrationPage()
        {
            InitializeComponent();
            
            _registrationController = new RegistrationController();
            _moreInformationFlightController = new MoreInformationFlightController();


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

        private bool Validate()
        {
            string errorMessage = "";
            if(!GeneralValidationRule.BasicValidate(PassportNumber_TextBox.Text) || !GeneralValidationRule.PasswordValidate(PassportNumber_TextBox.Text))
            {
                errorMessage += "Поле паспорта либо не заполнено, либо неправильная запись.\n";
            }
            if(!GeneralValidationRule.BasicValidate(PlacePassport_TextBox.Text)) { errorMessage += "Место выдачи паспорта пустое.\n"; }
            if(PassportDate_TextBox.Text == null) { errorMessage += "Дата выдачи паспорта не выбрана.\n"; }
            if(!GeneralValidationRule.BasicValidate(FIO_TextBox.Text)) { errorMessage += "Поле с ФИО не заполнено.\n"; }
            if(DateOfBirth_DatePciker.Text == null) { errorMessage += "Дата рождения не выбрана.\n"; }
            if(!GeneralValidationRule.BasicValidate(BagageCount_TextBox.Text) || !GeneralValidationRule.DigitValidate(BagageCount_TextBox.Text))
            {
                errorMessage += "В поле bagagecount пустое значение или должны быть только цифры.\n";
            }
            if (!GeneralValidationRule.BasicValidate(BagageWeight_TextBox.Text) || !GeneralValidationRule.DigitValidate(BagageWeight_TextBox.Text))
            {
                errorMessage += "В поле BagageWeight пустое значение или должны быть только цифры.\n";
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

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {

                var FIO = FIO_TextBox.Text.Trim() + " User" + " User";
                var resultAdd = _registrationController.IsRegistered(
                    FlightHelper.idFlight,
                    PassportNumber_TextBox.Text,
                    PlacePassport_TextBox.Text,
                    new DateTime(Convert.ToInt32(PassportDate_TextBox.Text.Split('.')[2]), Convert.ToInt32(PassportDate_TextBox.Text.Split('.')[1]), Convert.ToInt32(PassportDate_TextBox.Text.Split('.')[0])),
                    FIO.Split()[0] == "User" ? "" : FIO.Split()[0],
                    FIO.Split()[1] == "User" ? "" : FIO.Split()[1],
                    FIO.Split()[2] == "User" ? "" : FIO.Split()[2],
                    new DateTime(Convert.ToInt32(DateOfBirth_DatePciker.Text.Split('.')[2]), Convert.ToInt32(DateOfBirth_DatePciker.Text.Split('.')[1]), Convert.ToInt32(DateOfBirth_DatePciker.Text.Split('.')[0])),
                    int.Parse(BagageCount_TextBox.Text),
                    int.Parse(BagageWeight_TextBox.Text)
                    );

                if (resultAdd == true)
                {
                    var result = System.Windows.MessageBox.Show("Успешно зарегестрировыан, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.NavigationService.Navigate(new AllFlightsPage());
                    }
                    else
                    {
                        this.NavigationService.Navigate(new RegistrationPage());
                    }
                }
                else
                {

                    var result = System.Windows.MessageBox.Show("Пользователь не найден", "Не найдено", MessageBoxButton.OK, MessageBoxImage.Question);
                    
                }
            }
        }

        private void AllRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AllRegistrationPassangerPage());
        }
    }
}
