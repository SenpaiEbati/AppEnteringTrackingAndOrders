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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private Menu _menu = new Menu();
        private Group _now_group;
        private Order _old_order;
        private Order _list_order = new Order();
        private bool _is_new_order;
        private UIElement _now_order_UI_item;
        //private OrderItem _now_order_item;
        //private List<OrderItem> _list_order_item = new List<OrderItem>();
        private MenuItem _now_menu_item;
        private OrderItem _now_order_item;
        private MenuItem _old_menu_item;
        //private OrderItemModifier _now_order_item_modifier;
        //private List<OrderItemModifier> _list_order_item_modifier = new List<OrderItemModifier>();
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
                    GroupMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Hidden;
                    ItemMenuButtonsWrapPanelAddPositionButton.Visibility = Visibility.Hidden;
                    ItemModifierButtonsWrapPanelAddPositionButton.Visibility = Visibility.Hidden;
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
                    _is_new_order = false;
                    _old_order = order;
                }
                else
                {
                    _is_new_order = true;
                    var oldorder = new Order { Id = _ID, OrderDate = DateTime.UtcNow };
                    _old_order = oldorder;
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

                List<OrderItem> OrderItem = context.OrderItems.Where(i => i.OrderId == _ID).ToList();
                foreach (OrderItem item in OrderItem)
                {
                    var menuitem = context.MenuItems.Where(i => i.Id == item.MenuItemId).FirstOrDefault();
                    if (menuitem != null)
                    {
                        int targetPosition = 52;
                        int paddingLength = targetPosition - menuitem.Name.Length - 1; // -1 учитывает "⠀" в начале
                        string paddedName = $"⠀{menuitem.Name}".PadRight(paddingLength, ' ');

                        Button button = new Button()
                        {
                            Width = 605,
                            Height = 80,
                            Margin = new Thickness(0, 5, 0, 0),
                            Content = Convert.ToString($"{paddedName}{item.Quantity}⠀⠀⠀⠀{menuitem.Price}₽"),
                            FontSize = 24
                        };
                        button.Style = (Style)FindResource("ButtonOrderItem");
                        button.Tag = menuitem;
                        button.GotFocus += ItemOrder_GotFocus;
                        button.LostFocus += ItemOrder_LostFocus;
                        OrderPanelInfoWrapPanel.Children.Add(button);

                        
                        List<OrderItemModifier> OrderItemModifier = context.OrderItemModifiers.Where(i => i.OrderItemId == item.Id).ToList();
                        foreach (OrderItemModifier itemmod in OrderItemModifier)
                        {
                            var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == itemmod.MenuItemModifierId).FirstOrDefault();
                            if (menuitemmod != null)
                            {
                                int targetPositionmod = 50;
                                int paddingLengthmod = targetPositionmod - menuitemmod.Name.Length - 1; // -1 учитывает "⠀" в начале
                                string paddedNamemod = $"⠀{menuitemmod.Name}".PadRight(paddingLengthmod, ' ');

                                Button buttonmod = new Button()
                                {
                                    Width = 605,
                                    Height = 80,
                                    Margin = new Thickness(0, 5, 0, 0),
                                    Content = Convert.ToString($"{paddedNamemod}{item.Quantity}⠀⠀⠀⠀{menuitemmod.AdditionalCost}₽"),
                                    FontSize = 24
                                };
                                buttonmod.Style = (Style)FindResource("ButtonOrderItemModifier");
                                buttonmod.GotFocus += ItemOrder_GotFocus;
                                buttonmod.LostFocus += ItemOrder_LostFocus;
                                buttonmod.Tag = menuitemmod;
                                OrderPanelInfoWrapPanel.Children.Add(buttonmod);
                            }
                        }
                    }
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
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Visible;
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
                    OrderItem orderitem = null;
                    using (var context = new RestaurantContext()) {
                        context.Attach(_old_order);
                        var menuitem = context.MenuItems.FirstOrDefault(i => i.Id == item.Id);
                        if (menuitem != null)
                        {
                            orderitem = new OrderItem() 
                            {
                                MenuItemId = menuitem.Id,
                                Quantity = 1,
                                OrderId = _old_order.Id
                            };
                            _list_order.Items.Add(orderitem);
                        }
                    }
                    if (orderitem != null)
                    {
                        int targetPosition = 52;
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
        }

        private void ItemOrder_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedItemOrder && clickedItemOrder.Tag != null)
            {
                var item = clickedItemOrder.Tag as MenuItem;
                if (item != null)
                {
                    _now_menu_item = item;
                    _now_order_UI_item = clickedItemOrder;
                    GroupMenuBorderText.Text = item.Name;
                    ItemMenuBorderTextBlock.Text = $"Выберите взаимодействие с {item.Name}";
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    return;
                }

                var itemModifier = clickedItemOrder.Tag as MenuItemModifier;
                if (itemModifier != null)
                {
                    GroupMenuBorderText.Text = itemModifier.Name;
                    ItemMenuBorderTextBlock.Text = $"Выберите взаимодействие с {itemModifier.Name}";
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                }
            }
        }

        private void ItemOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            Button clickedItemOrder = sender as Button;
            if (clickedItemOrder != null)
            {
                _old_menu_item = _now_menu_item;
                _now_menu_item = null;
                GroupMenuBorderText.Text = "Меню";
                ItemMenuBorderTextBlock.Text = "Выберите группу меню";
                GroupMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                ModifierMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                ItemModifierButtonsScrollViewer.Visibility = Visibility.Hidden;
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
                        context.Attach(itemModifier);
                        var orderitem = _list_order.Items.Count - 1;
                        if (orderitem != null && orderitem >= 0)
                        {
                            var OrderItemModifier = new OrderItemModifier()
                            {
                                OrderItemId = orderitem,
                                MenuItemModifierId = itemModifier.Id,
                            };
                            _list_order.Items[orderitem].Modifiers.Add(OrderItemModifier);
                        }
                    }
                    int targetPosition = 50;
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

                    int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
                    if (a != -1)
                        OrderPanelInfoWrapPanel.Children.Insert(a+1,button);
                    else
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
                    if (_now_menu_item != null)
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
                var itemModifier = context.MenuItemModifiers.Where(i => i.MenuItem.Id == _old_menu_item.Id).AsNoTracking().ToList();
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
                if (_is_new_order == true)
                {
                    context.Orders.Add(_old_order);
                    foreach (var item in _list_order.Items)
                    {
                        context.OrderItems.Add(item);
                        foreach (var mod in item.Modifiers)
                        {
                            context.OrderItemModifiers.Add(mod);
                        }
                    }
                }
                else
                {
                    foreach (var item in _list_order.Items)
                    {
                        context.OrderItems.Add(item);
                        foreach (var mod in item.Modifiers)
                        {
                            context.OrderItemModifiers.Add(mod);
                        }
                    }
                }
                context.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
