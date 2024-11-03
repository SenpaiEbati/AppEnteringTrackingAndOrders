using Microsoft.EntityFrameworkCore;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для SettingUsers.xaml
    /// </summary>
    public partial class SettingUsers : Page
    {
        public SettingUsers()
        {
            InitializeComponent();

            List<string> roles = new List<string> { "Официант", "Администратор" };
            ComboBoxRolesChange.ItemsSource = ComboBoxRolesAdd.ItemsSource = roles;
            
        }

        // Логика назначения ролей
        public void AddUserWithRoles(string username, string password, List<string> roleNames)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = new User
                {
                    Username = username,
                    PasswordHash = PasswordHasher.HashPassword(password),
                    Roles = context.Roles.Where(r => roleNames.Contains(r.RoleName)).ToList()
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "1";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "1";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "2";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "2";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "3";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "3";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "4";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "4";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "5";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "5";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "6";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "6";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "7";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "7";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "8";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "8";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "9";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "9";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
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
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                if (passwordBoxOne.Password.Length > 0)
                    passwordBoxOne.Password = passwordBoxOne.Password.Substring(0, passwordBoxOne.Password.Length - 1);
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += ".";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += ".";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "0";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "0";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            BorderComboBoxRolesChange.Visibility = Visibility.Hidden;
            BorderPasswordBoxTwo.Visibility = Visibility.Hidden;

            BorderPasswordBoxOne.Visibility = Visibility.Visible;
            BorderComboBoxRolesAdd.Visibility = Visibility.Visible;
        }

        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text))
            {
                BorderComboBoxRolesChange.Visibility = Visibility.Visible;
                BorderPasswordBoxTwo.Visibility = Visibility.Visible;

                BorderPasswordBoxOne.Visibility = Visibility.Visible;
                BorderComboBoxRolesAdd.Visibility = Visibility.Hidden;
            }
            else 
            {
                BorderComboBoxRolesChange.Visibility = Visibility.Hidden;
                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;

                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRolesAdd.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            BorderComboBoxRolesChange.Visibility = Visibility.Hidden;
            BorderPasswordBoxTwo.Visibility = Visibility.Visible;

            BorderPasswordBoxOne.Visibility = Visibility.Visible;
            BorderComboBoxRolesAdd.Visibility = Visibility.Hidden;
        }

        public bool FindUser(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);
                
                if (user != null )
                {
                    return true;
                }
                return false;
            }
        }
    }
}
