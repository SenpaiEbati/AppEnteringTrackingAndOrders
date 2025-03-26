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
        private Group _now_group;
        private Order _now_order;
        private OrderItem _now_order_item;
        private List<OrderItem> _list_order_item = new List<OrderItem>();
        private MenuItem _now_menu_item;
        private OrderItemModifier _now_order_item_modifier;
        private List<OrderItemModifier> _list_order_item_modifier = new List<OrderItemModifier>();
        private int? _IDYourUserRoles;
        private int _ID = 0;

        public OrdersPage(User user, int OrderID)
        {
            _ID = OrderID;
            InitializeComponent();

            _IDYourUserRoles = GetRoleIdForUser(user);
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles != 1)
                {
                    GroupMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
                    ItemMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
                    ItemModifierButtonsWrapPanelAddPositionButton.Visibility = Visibility.Collapsed;
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

                context.SaveChanges();

                var order = context.Orders.FirstOrDefault(i => i.Id == _ID);
                if (order != null)
                {
                    _now_order = order;
                }
                else
                {
                    var neworder = new Order { Id = _ID, OrderDate = DateTime.UtcNow };
                    _now_order = neworder;
                }

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

            TopBorderText.Text = $"Создать заказ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀{DateTime.Now.ToString("HH:mm")}\nСтол:1 Гостей:2";
            //ButtonOrdersSumWrapPanel.Content = $"Заказ {OrderSum()}₽";
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
                    _now_group = group;
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
                    using (var context = new RestaurantContext()) {
                        context.Attach(_now_order);
                        context.Attach(item);
                        int count = context.OrderItems.Count();
                        if (count > 0)
                        {
                            //var maxId = context.OrderItems.OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
                            var OrderItem = new OrderItem()
                            {
                                //Id = maxId + 1,
                                MenuItemId = item.Id,
                                Quantity = 1,
                                OrderId = _now_order.Id
                            };

                            _now_order_item = OrderItem;
                            _list_order_item.Add(OrderItem);
                        }
                        else
                        {
                            var OrderItem = new OrderItem()
                            {
                                Id = 1,
                                MenuItemId = item.Id,
                                Quantity = 1,
                                OrderId = _now_order.Id,
                                MenuItem = item,
                            };

                            _now_order_item = OrderItem;
                            _list_order_item.Add(OrderItem);
                        }

                    }
                    int targetPosition = 65;
                    int paddingLength = targetPosition - item.Name.Length - 1; // -1 учитывает "⠀" в начале
                    string paddedName = $"⠀{item.Name}".PadRight(paddingLength, ' ');

                    Button button = new Button()
                    {
                        Width = 605,
                        Height = 80,
                        Margin = new Thickness(0, 5, 0, 0),
                        Content = Convert.ToString($"{paddedName}1⠀⠀⠀⠀{item.Price}₽"),
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
            if (sender is Button clickedItemOrder && clickedItemOrder.Tag != null)
            {
                var item = clickedItemOrder.Tag as MenuItem;
                if (item != null)
                {
                    _now_menu_item = item;
                    GroupMenuBorderText.Text = item.Name;
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    ItemModifierButtonsScrollViewer.Visibility = Visibility.Visible;
                    return;
                }

                var itemModifier = clickedItemOrder.Tag as MenuItemModifier;
                if (itemModifier != null)
                {
                    GroupMenuBorderText.Text = itemModifier.Name;
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    ItemModifierButtonsScrollViewer.Visibility = Visibility.Visible;
                }
            }
        }

        private void ItemOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            Button clickedItemOrder = sender as Button;
            if (clickedItemOrder != null)
            {
                _now_menu_item = null;
                GroupMenuBorderText.Text = "Меню";
                GroupMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                ItemMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                ModifierMenuButtonsScrollViewer.Visibility = Visibility.Collapsed;
                ItemModifierButtonsScrollViewer.Visibility = Visibility.Collapsed;
            }
        }

        private void ModifierMenuButtonsWrapPanel_ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            ItemModifierButtonsScrollViewer.Visibility = Visibility.Visible;
            ItemMenuBorderTextBlock.Text = "Начинка";
            ItemModifierButtonsWrapPanel.Children.Clear();
            ItemModifierButtonsWrapPanel.Children.Add(ItemModifierButtonsWrapPanelAddPositionButton);

            if (_now_menu_item != null)
            {
                using (var context = new RestaurantContext())
                {
                    var itemModifier = context.MenuItemModifiers.Where(i => i.MenuItem.Id == _now_menu_item.Id).AsNoTracking().ToList();
                    foreach (var item in itemModifier)
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
                        button.Click += AddModifierToOrder;
                        button.Focusable = false;
                        ItemModifierButtonsWrapPanel.Children.Add(button);
                    }
                }
            }
        }


        private void AddModifierToOrder(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                MenuItemModifier itemModifier = (MenuItemModifier)clickedButton.Tag;
                if (itemModifier != null)
                {
                    using (var context = new RestaurantContext())
                    {
                        context.Attach(_now_order_item);
                        context.Attach(itemModifier);
                        int count = context.OrderItemModifiers.Count();
                        if (count > 0)
                        {
                            //var maxId = context.OrderItems.LastOrDefault();

                            var OrderItemModifier = new OrderItemModifier()
                            {
                                //Id = maxId.Id + 1,
                                OrderItemId = _now_order_item.Id,
                                OrderItem = _now_order_item,
                                MenuItemModifierId = itemModifier.Id,
                                MenuItemModifier = itemModifier
                            };
                            _now_order_item_modifier = OrderItemModifier;
                            _list_order_item_modifier.Add(OrderItemModifier);
                        }
                        else
                        {
                            var OrderItemModifier = new OrderItemModifier()
                            {
                                Id = 1,
                                OrderItemId = _now_order_item.Id,
                                OrderItem = _now_order_item,
                                MenuItemModifierId = itemModifier.Id,
                                MenuItemModifier = itemModifier
                            };
                            _now_order_item_modifier = OrderItemModifier;
                            _list_order_item_modifier.Add(OrderItemModifier);
                        }
                    }
                    int targetPosition = 65;
                    int paddingLength = targetPosition - itemModifier.Name.Length - 1; // -1 учитывает "⠀" в начале
                    string paddedName = $"⠀{itemModifier.Name}".PadRight(paddingLength, ' ');

                    Button button = new Button()
                    {
                        Width = 605,
                        Height = 80,
                        Margin = new Thickness(0, 5, 0, 0),
                        Content = Convert.ToString($"{paddedName}1⠀⠀⠀⠀{itemModifier.AdditionalCost}₽"),
                        FontSize = 24
                    };
                    button.Style = (Style)FindResource("ButtonOrderItemModifier");
                    button.GotFocus += ItemOrder_GotFocus;
                    button.LostFocus += ItemOrder_LostFocus;

                    OrderPanelInfoWrapPanel.Children.Add(button);
                }
            }
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
                    AddGroupMenuPage AddGroupMenuPage = new AddGroupMenuPage();
                    AddGroupMenuPage.Unloaded += (s, args) => RefreshGroupMenuData();
                    NavigationService.Navigate(AddGroupMenuPage);
                }
            }
        }

        private void RefreshGroupMenuData()
        {
            GroupMenuButtonsWrapPanel.Children.Clear();
            GroupMenuButtonsWrapPanel.Children.Add(GroupMenuButtonsWrapPanelAddPositionButton);
            using (var context = new RestaurantContext())
            {
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
        }

        private void ItemMenuButtonsWrapPanelAddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 1)
                {
                    if (_now_group != null)
                    {
                        AddMenuItemPage AddMenuItemPage = new AddMenuItemPage(_now_group);
                        AddMenuItemPage.Unloaded += (s, args) => RefreshMenuItemData();
                        NavigationService.Navigate(AddMenuItemPage);
                    }
                }
            }
        }

        private void RefreshMenuItemData()
        {
            ItemMenuButtonsWrapPanel.Children.Clear();
            ItemMenuButtonsWrapPanel.Children.Add(ItemMenuButtonsWrapPanelAddPositionButton);
            using (var context = new RestaurantContext())
            {
                List<MenuItem> listgroupitem = context.MenuItems.Where(l => l.GroupId == _now_group.Id).AsNoTracking().ToList();
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

        private void ItemModifierButtonsWrapPanelAddPositionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 1)
                {
                    if (_now_group != null)
                    {
                        AddModifierItemPage AddModifierItemPage = new AddModifierItemPage(_now_menu_item);
                        AddModifierItemPage.Unloaded += (s, args) => RefreshModifierItemData();
                        NavigationService.Navigate(AddModifierItemPage);
                    }
                }
            }
        }

        private void RefreshModifierItemData()
        {
            ItemModifierButtonsWrapPanel.Children.Clear();
            ItemModifierButtonsWrapPanel.Children.Add(ItemModifierButtonsWrapPanelAddPositionButton);
            using (var context = new RestaurantContext())
            {
                var itemModifier = context.MenuItemModifiers.Where(i => i.MenuItem.Id == _now_menu_item.Id).AsNoTracking().ToList();
                foreach (var item in itemModifier)
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
                    button.Click += AddModifierToOrder;
                    button.Focusable = false;
                    ItemModifierButtonsWrapPanel.Children.Add(button);
                }
            }
        }

        private decimal OrderSum()
        {
            return 0;
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                if (_now_order != null)
                {
                    context.Orders.Add(_now_order);
                    context.SaveChanges();
                }
                if (_list_order_item.Count > 0)
                {
                    foreach (var orderItem in _list_order_item)
                    {
                        if (orderItem != null && orderItem.MenuItem != null)
                            context.Entry(orderItem.MenuItem).State = EntityState.Unchanged; // Указываем, что MenuItem не нужно сохранять

                        context.OrderItems.Add(orderItem);
                        context.SaveChanges();
                    }
                }
                if (_list_order_item_modifier.Count > 0)
                {
                    foreach (var orderItemMod in _list_order_item_modifier)
                    {
                        if (orderItemMod != null && orderItemMod.MenuItemModifier != null && orderItemMod.OrderItem != null)
                        {
                            context.Entry(orderItemMod.MenuItemModifier).State = EntityState.Unchanged;
                            context.Entry(orderItemMod.OrderItem).State = EntityState.Unchanged;
                        }
                        
                        context.OrderItemModifiers.Add(orderItemMod);
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
