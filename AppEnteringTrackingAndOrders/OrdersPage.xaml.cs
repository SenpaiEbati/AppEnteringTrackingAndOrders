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
        private Menu _menu = new Menu();
        private Group _nowgroup;
        private int? _IDYourUserRoles;

        public OrdersPage(User user)
        {
            InitializeComponent();

            _IDYourUserRoles = GetRoleIdForUser(user);
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles != 1)
                {
                    GroupMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
                }
            }
            using (var context = new RestaurantContext())
            {
                var menu = context.Menus.FirstOrDefault();
                if (menu == null)
                {
                    _menu.Name = "Main Menu";
                    context.Menus.Add(_menu);
                    context.SaveChanges();
                }
                else
                    _menu = menu;

                List<Group> groups = context.Groups.ToList();
                foreach (var group in groups)
                {
                    Button button = new Button()
                    {
                        Width = 200,
                        Height = 175,
                        Margin = new Thickness(0, 0, 10, 10),
                        Content = group.Name,
                        FontSize = 24
                    };
                    button.Style = (Style)FindResource("ButtonStyleNo");
                    button.Tag = group;
                    button.Click += MenuGroupButton_Click;
                    GroupMenuButtonsWrapPanel.Children.Add(button);
                }
            }

            TopBorderText.Text = $"Создать заказ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀{DateTime.Now.ToString("HH:mm")}\nСтол:1 Гостей:2";
            OrderPanelInfoAddGuestButton.Content = "➕ Гость";
            ButtonOrdersSumWrapPanel.Content = $"Заказ {OrderSum()}₽";
            GroupMenuButtonsWrapPanelAddPositionButton.Content = "➕ Добавить\nгруппу позиций";
            ItemMenuButtonsWrapPanelAddPositionButton.Content = "➕ Добавить\nпозицию";

        }

        private void MenuGroupButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                Group group = (Group)clickedButton.Tag;
                if (group != null) 
                {
                    _nowgroup = group;
                    ItemMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Visible;
                    ItemMenuBorderTextBlock.Text = group.Name;
                    List<MenuItem> listgroupitem = group.MenuItems.ToList();
                    foreach (MenuItem item in listgroupitem) 
                    {
                        Button button = new Button()
                        {
                            Width = 200,
                            Height = 175,
                            Margin = new Thickness(0, 0, 10, 10),
                            Content = item.Name,
                            FontSize = 24
                        };
                        button.Style = (Style)FindResource("ButtonStyleNo");
                        button.Tag = item;
                        //button.Click += MenuGroupButton_Click;
                        ItemMenuButtonsWrapPanel.Children.Add(button);
                    }
                }
            }
        }

        private void BackListTableWaitersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrderPanelInfoAddGuestButton_Click(object sender, RoutedEventArgs e)
        {

            /* OrderPanelInfoWrapPanel.Children.Add();*/
        }

        private void GroupMenuButtonsWrapPanelAddPositionButton_Click(object sender, RoutedEventArgs e)
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

        private void ItemMenuButtonsWrapPanelAddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 1)
                {
                    if (_nowgroup != null)
                        NavigationService.Navigate(new AddMenuItemPage(_nowgroup));
                }
            }
        }
    }
}
