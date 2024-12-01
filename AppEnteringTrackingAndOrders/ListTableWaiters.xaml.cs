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
    /// Логика взаимодействия для ListTableWaiters.xaml
    /// </summary>
    public partial class ListTableWaiters : Page
    {
        private int? _IDYourUserRoles;
        public ListTableWaiters(User user)
        {
            InitializeComponent();
            _IDYourUserRoles = GetRoleIdForUser(user);
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 3)
                {
                    BorderCenterTopMenu.Width += 5;
                    BorderButtonLeftTopMenu.Width += 5;
                    ButtonLeftTopMenu.Visibility = Visibility.Hidden;
                    ButtonRightTopMenu.Visibility = Visibility.Hidden;
                    TextBlockBorderCenterTopMenu.Text = "Все заказы";
                }
            }
        }

        private void ButtonLeftTopMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRightTopMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
