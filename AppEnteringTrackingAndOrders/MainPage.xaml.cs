using MaterialDesignThemes.Wpf;
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
using static AppEnteringTrackingAndOrders.ConstantsInitialValuesMethodsDb;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeRoles();
            InitializeAdminUser();
            // Для Тестирования белой и темной темы
            // -----------
            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";
            // -----------
            
        }
        // Для Тестирования белой и темной темы
        // -----------
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        // -----------

        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "1";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "1";
                passwordBox.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "2";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "2";
                passwordBox.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "3";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "3";
                passwordBox.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "4";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "4";
                passwordBox.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "5";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "5";
                passwordBox.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "6";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "6";
                passwordBox.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "7";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "7";
                passwordBox.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "8";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "8";
                passwordBox.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "9";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "9";
                passwordBox.Focus();
            }
        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (textBox.Text.Length > 0)
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                if (passwordBox.Password.Length > 0)
                    passwordBox.Password = passwordBox.Password.Substring(0, passwordBox.Password.Length - 1);
                passwordBox.Focus();
            }
        }

        private void CenterButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += ".";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += ".";
                passwordBox.Focus();
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "0";
                textBox.Focus();
            }
            else if (passwordBox.IsKeyboardFocused)
            {
                passwordBox.Password += "0";
                passwordBox.Focus();
            }
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && textBox.Text.Length != 0 && passwordBox.Password.Length != 0)
            {
                var user = AuthenticateUser(textBox.Text, passwordBox.Password);
                if (user != null)
                {
                    NavigationService.Navigate(new ListTableWaiters(user));
                }
                else
                {
                    textBox.Foreground = Brushes.Black;
                    HintAssist.SetHint(textBox, "Введите логин");
                    ShowError(passwordBox, "Неверный пароль!");
                }
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length == 0 && passwordBox.Password.Length != 0)
            {
                passwordBox.Foreground = Brushes.Black;
                HintAssist.SetHint(passwordBox, "Введите пароль");

                ShowError(textBox, "Не введён пользователь!");
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length != 0 && passwordBox.Password.Length == 0)
            {
                textBox.Foreground = Brushes.Black;
                HintAssist.SetHint(textBox, "Введите логин");

                ShowError(passwordBox, "Не введен пароль!");
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length == 0 && passwordBox.Password.Length == 0)
            {
                ShowError(textBox, "Не введён пользователь!");
                ShowError(passwordBox, "Не введен пароль!");
            }
            else
            {
                ShowError(textBox, "Не найден пользователь!");
                ShowError(passwordBox, "Не найден пользователь!");
            }
        }

        private void ButtonSettingUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && textBox.Text.Length != 0 && passwordBox.Password.Length != 0)
            {
                var user = AuthenticateUser(textBox.Text, passwordBox.Password);
                if (user != null && GetRoleIdForUser(user) == 1)
                {
                    NavigationService.Navigate(new SettingUsers());
                }
                else
                {
                    textBox.Foreground = Brushes.Black;
                    HintAssist.SetHint(textBox, "Введите логин");
                    ShowError(passwordBox, "Неверный пароль!");
                }
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length == 0 && passwordBox.Password.Length != 0)
            {
                passwordBox.Foreground = Brushes.Black;
                HintAssist.SetHint(passwordBox, "Введите пароль");

                ShowError(textBox, "Не введён пользователь!");
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length != 0 && passwordBox.Password.Length == 0)
            {
                textBox.Foreground = Brushes.Black;
                HintAssist.SetHint(textBox, "Введите логин");

                ShowError(passwordBox, "Не введен пароль!");
            }
            else if (FindUser(textBox.Text) && textBox.Text.Length == 0 && passwordBox.Password.Length == 0)
            {
                ShowError(textBox, "Не введён пользователь!");
                ShowError(passwordBox, "Не введен пароль!");
            }
            else
            {
                ShowError(textBox, "Не найден пользователь!");
                ShowError(passwordBox, "Не найден пользователь!");
            }
        }

        private void ShowError(Control control, string hintMessage)
        {
            if (control is System.Windows.Controls.TextBox textBox) textBox.Foreground = Brushes.Red;
            if (control is System.Windows.Controls.PasswordBox passwordBox) passwordBox.Foreground = Brushes.Red;

            HintAssist.SetHint(control, hintMessage);
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Black;
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Foreground = Brushes.Black;
        }
    }
}

