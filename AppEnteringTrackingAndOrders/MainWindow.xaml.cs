using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            AuthenticateUser(textBox.Text, passwordBox.Password);
            MainFrame.Navigate(new ListTableWaiters());
        }

        private void ButtonSettingUser_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == textBox.Text);

                if (user != null && PasswordHasher.VerifyPassword(passwordBox.Password, user.PasswordHash))
                {
                    MainFrame.Navigate(new SettingUsers());
                }
            }
        }

        // Инициализация ролей 
        private void InitializeRoles()
        {
            using (var context = new ApplicationDbContext())
            {
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { RoleName = "Руководитель" },
                        new Role { RoleName = "Администратор" },
                        new Role { RoleName = "Официант" }
                    );
                    context.SaveChanges();
                }
            }
        }
        // Инициализация руководителя
        private void InitializeAdminUser()
        {
            using (var context = new ApplicationDbContext())
            {
                if (!context.Users.Any())
                {
                    var user = new User
                    {
                        Username = "1",
                        PasswordHash = PasswordHasher.HashPassword("123456789"),
                        Roles = context.Roles.Where(r => r.RoleId == 1).ToList()
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }

        // Логика аутентификации 
        public User AuthenticateUser(string username, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    return user;
                }
                return null;
            }
        }

        
    }
}