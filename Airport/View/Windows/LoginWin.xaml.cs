using Airport.Controllers;
using Airport.Helpers.ModelHelper;
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
using System.Windows.Shapes;

namespace Airport.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        private readonly LoginWinController _loginController;
        public LoginWin()
        {
            InitializeComponent();
            FlightHelper.idFlight = 0;
            _loginController = new LoginWinController();
        }



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_loginController.Authorization(EnterLogin_TextBox.Text, EnterPassword_PasswordBox.Password))
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                
                    var result = System.Windows.MessageBox.Show("Неверные данные для вохда", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Question);
                   
            }


        }

        private void MyPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                // Находим элемент WatermarkText внутри шаблона
                var template = passwordBox.Template;
                if (template != null)
                {
                    var watermarkText = template.FindName("WatermarkText", passwordBox) as TextBlock;
                    if (watermarkText != null)
                    {
                        // Показываем или скрываем watermark в зависимости от наличия текста
                        watermarkText.Visibility = string.IsNullOrEmpty(passwordBox.Password)
                            ? Visibility.Visible
                            : Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
