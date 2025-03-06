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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private Menu _menu;
        private int? _IDYourUserRoles;

        public OrdersPage(User user)
        {
            _IDYourUserRoles = GetRoleIdForUser(user);
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 1)
                {
                    using (var context = new RestaurantContext())
                    {
                        var menu = context.Menus.FirstOrDefault();
                        if (menu == null)
                        {
                            // Создаем меню
                            var newmenu = new Menu { Name = "Main Menu" };
                            context.Menus.Add(newmenu);
                            context.SaveChanges();
                        }
                        else
                            _menu = menu;
                    }
                }
                else
                {
                    MenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
                }
            }

            InitializeComponent();

            TopBorderText.Text = $"Создать заказ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀{DateTime.Now.ToString("HH:mm")}\nСтол:1 Гостей:2";
            OrderPanelInfoAddGuestButton.Content = "➕ Гость";
            ButtonOrdersSumWrapPanel.Content = $"Заказ {OrderSum()}₽";
            MenuButtonsWrapPanelAddPositionButton.Content = "➕ Добавить\nгруппу позиций";
        }

        private void BackListTableWaitersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderPanelInfoAddGuestButton_Click(object sender, RoutedEventArgs e)
        {

           /* OrderPanelInfoWrapPanel.Children.Add();*/
        }

        private void MenuButtonsWrapPanelAddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 1)
                {
                    NavigationService.Navigate(new AddGroupMenuPage());
                }
            }
        }

        private decimal OrderSum()
        {
            return 0;
        }
    }
}
