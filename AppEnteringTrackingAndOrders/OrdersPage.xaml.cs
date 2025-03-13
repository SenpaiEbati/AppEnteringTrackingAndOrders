using MaterialDesignThemes.Wpf;
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
using System.Xml;
using static AppEnteringTrackingAndOrders.ConstantsInitialValuesMethodsDb;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private Menu _menu = new Menu();
        private Group _nowgroup;
        private Order _noworder;
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
                    ItemMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
                }
            }
            using (var context = new RestaurantContext())
            {
                var menu = context.Menus.FirstOrDefault();
                if (menu == null)
                {
                    _menu.Name = "Main Menu";
                    context.Menus.Add(_menu);
                } 
                else
                    _menu = menu;

                var order = new Order
                {
                    OrderDate = DateTime.UtcNow
                };
                _noworder = order;
                context.Orders.Add(order);
                context.SaveChanges();

                List<Group> groups = context.Groups.AsNoTracking().ToList();
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
            ButtonOrdersSumWrapPanel.Content = $"Заказ {OrderSum()}₽";
        }

        private void MenuGroupButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                ItemMenuButtonsWrapPanel.Children.Clear();
                ItemMenuButtonsWrapPanel.Children.Add(ItemMenuButtonsWrapPanelAddPositionButton);
                Group group = (Group)clickedButton.Tag;
                if (group != null) 
                {
                    _nowgroup = group;
                    ItemMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Visible;
                    ItemMenuBorderTextBlock.Text = group.Name;
                    using (var context = new RestaurantContext())
                    {
                        List<MenuItem> listgroupitem = context.MenuItems.Where(l => l.GroupId == group.Id).AsNoTracking().ToList();
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
                            button.Click += MenuItemButton_Click;
                            ItemMenuButtonsWrapPanel.Children.Add(button);
                        }
                    }
                }
            }
        }

        private void MenuItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                MenuItem item = (MenuItem)clickedButton.Tag;
                if (item != null) 
                {
                    using (var context = new RestaurantContext())
                    {
                        var OrderItem = new OrderItem()
                        {
                            MenuItemId = item.Id,
                            Quantity = 1,
                            OrderId = _noworder.Id,
                        };
                        context.OrderItems.Add(OrderItem);
                        context.SaveChanges();
                    }
                    Button button = new Button()
                    {
                        Width = 605,
                        Height = 80,
                        Margin = new Thickness(0, 5, 0, 0),
                        Content = Convert.ToString($"⠀{item.Name}⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀1⠀⠀⠀⠀{item.Price}₽"),
                        FontSize = 24
                    };
                    button.Style = (Style)FindResource("ButtonOrderItem");
                    button.Tag = item;
                    button.GotFocus += ItemOrder_GotFocus;
                    button.LostFocus += ItemOrder_LostFocus;
                    OrderPanelInfoWrapPanel.Children.Add(button);
                }
            }
        }

        private void ItemOrder_GotFocus(object sender, RoutedEventArgs e)
        {
            Button clickedItemOrder = sender as Button;
            if (clickedItemOrder != null) 
            {
                MenuItem item = (MenuItem)clickedItemOrder.Tag;
                if (item != null)
                {
                    GroupMenuBorderText.Text = item.Name;
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;

                }
            }
        }

        private void ItemOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            Button clickedItemOrder = sender as Button;
            if (clickedItemOrder != null)
            {
                GroupMenuBorderText.Text = "Меню";
                GroupMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                ModifierMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
            }
        }

        private void ModifierMenuButtonsWrapPanel_ModifierButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifierMenuButtonsWrapPanel_QuantityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifierMenuButtonsWrapPanel_DeleteButton_Click(object sender, RoutedEventArgs e)
        {

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
