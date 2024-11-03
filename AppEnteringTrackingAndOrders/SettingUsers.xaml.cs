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
            comboboxroles.ItemsSource = roles;
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

        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CenterButtonPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
