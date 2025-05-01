using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using static MaterialDesignThemes.Wpf.Theme;
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
        private MenuItem _now_menu_item;
        private OrderItem _now_order_item;
        private MenuItem _old_menu_item;
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
                    System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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

                RefreshOrderPanelInfo();
            }
            TopBorderText.Text = $"Создать заказ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀{DateTime.Now.ToString("HH:mm")}\nСтол:1 Гостей:2";

            //ButtonOrdersSumWrapPanel.Content = $"Заказ {OrderSum()}₽";
        }



        private void MenuGroupButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedButton = sender as System.Windows.Controls.Button;

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
                            System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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
            System.Windows.Controls.Button clickedButton = sender as System.Windows.Controls.Button;

            if (clickedButton != null)
            {
                MenuItem item = (MenuItem)clickedButton.Tag;
                if (item != null)
                {
                    using (var context = new RestaurantContext())
                    {
                        context.Attach(_old_order);
                        var menuitem = context.MenuItems.FirstOrDefault(i => i.Id == item.Id);
                        if (menuitem != null)
                        {
                            OrderItem orderitem = new OrderItem()
                            {
                                MenuItemId = menuitem.Id,
                                Quantity = 1,
                                OrderId = _old_order.Id
                            };
                            _list_order.Items.Add(orderitem);

                            UI_OrderItems(menuitem, orderitem);
                        }
                    }
                }
            }
        }

        private void ItemOrder_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button clickedItemOrder && clickedItemOrder.Tag != null)
            {
                // Приводим Tag к ValueTuple<MenuItem, OrderItem>
                if (clickedItemOrder.Tag is ValueTuple<MenuItem, OrderItem> tuple)
                {
                    _now_menu_item = tuple.Item1;
                    _now_order_item = tuple.Item2;
                    _now_order_UI_item = clickedItemOrder;
                    GroupMenuBorderText.Text = _now_menu_item.Name;
                    ItemMenuBorderTextBlock.Text = $"Выберите взаимодействие с {_now_menu_item.Name}";
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    ModifierMenuButtonsWrapPanel_ModifierButton.Visibility = Visibility.Visible;
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
                    ModifierMenuButtonsWrapPanel_ModifierButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ItemOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedItemOrder = sender as System.Windows.Controls.Button;
            if (clickedItemOrder != null)
            {
                _old_menu_item = _now_menu_item;
                _now_menu_item = null;
                _now_order_item = null;
                _now_order_UI_item = null;
                GroupMenuBorderText.Text = "Меню";
                ItemMenuBorderTextBlock.Text = "Выберите группу меню";
                GroupMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                ModifierMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                ItemModifierButtonsScrollViewer.Visibility = Visibility.Hidden;
                ItemQuantityButton.Visibility = Visibility.Hidden;
            }
        }

        private void ModifierMenuButtonsWrapPanel_ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            ItemQuantityButton.Visibility = Visibility.Hidden;
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
                        System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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
            
            System.Windows.Controls.Button clickedButton = sender as System.Windows.Controls.Button;

            if (clickedButton != null)
            {
                MenuItemModifier itemModifier = (MenuItemModifier)clickedButton.Tag;
                if (itemModifier != null)
                {
                    using (var context = new RestaurantContext())
                    {
                        context.Attach(itemModifier);
                        var count = _list_order.Items.Count - 1;
                        if (_old_order != null && (count >= 0 || _old_order.Items.Count >= 0) )
                        {
                            int index = _list_order.Items.IndexOf(_now_order_item);
                            var OrderItemModifier = new OrderItemModifier()
                            {
                                OrderItemId = index,
                                MenuItemModifierId = itemModifier.Id,
                            };

                            if (count >= 0)
                            {
                                _list_order.Items[index].Modifiers.Add(OrderItemModifier);
                            }
                            else
                            {
                                OrderItem orderitem = new OrderItem()
                                {
                                    Id = -1,
                                    MenuItemId = _now_order_item.MenuItemId,
                                    Quantity = _now_order_item.Quantity,
                                    OrderId = _now_order_item.OrderId,
                                };
                                _list_order.Items.Add(orderitem);
                                _list_order.Items[count + 1].Modifiers.Add(OrderItemModifier);
                            }

                            UI_OrderItem_Modifiers(itemModifier);
                        }
                    }
                }
            }
        }

        private void ModifierMenuButtonsWrapPanel_QuantityButton_Click(object sender, RoutedEventArgs e)
        {
            if (_now_order_item != null)
            {
                ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                ItemModifierButtonsScrollViewer.Visibility = Visibility.Hidden;
                ItemQuantityButton.Visibility = Visibility.Visible;
                ItemMenuBorderTextBlock.Text = "Изменение количества";
                ItemQuantityNumericUpDown.Value = _now_order_item.Quantity;
            }
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
                    System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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
                    System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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
                    System.Windows.Controls.Button button = new System.Windows.Controls.Button()
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

        private void RefreshOrderPanelInfo()
        {
            OrderPanelInfoWrapPanel.Children.Clear();
            using (var context = new RestaurantContext())
            {
                List<OrderItem> OrderItem = context.OrderItems.Where(i => i.OrderId == _ID).ToList();
                foreach (OrderItem item in OrderItem)
                {
                    var menuitem = context.MenuItems.Where(i => i.Id == item.MenuItemId).FirstOrDefault();
                    if (menuitem != null)
                    {
                        UI_OrderItems(menuitem, item);

                        List<OrderItemModifier> OrderItemModifier = context.OrderItemModifiers.Where(i => i.OrderItemId == item.Id).ToList();
                        foreach (OrderItemModifier itemmod in OrderItemModifier)
                        {
                            var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == itemmod.MenuItemModifierId).FirstOrDefault();

                            if (menuitemmod != null)
                                UI_OrderItem_Modifiers(menuitemmod);
                        }
                    }
                }
            }
        }

        private void UI_OrderItems(MenuItem menuitem, OrderItem item)
        {
            int targetPosition = 52;
            int paddingLength = targetPosition - menuitem.Name.Length - 1; // -1 учитывает "⠀" в начале
            string paddedName = $"⠀{menuitem.Name}".PadRight(paddingLength, ' ');

            System.Windows.Controls.Button button = new System.Windows.Controls.Button()
            {
                Width = 605,
                Height = 80,
                Margin = new Thickness(0, 5, 0, 0),
                Content = Convert.ToString($"{paddedName}{item.Quantity}⠀⠀⠀⠀{menuitem.Price}₽"),
                FontSize = 24
            };
            button.Style = (Style)FindResource("ButtonOrderItem");

            ValueTuple<MenuItem, OrderItem> tuple = new ValueTuple<MenuItem, OrderItem>(menuitem, item);
            button.Tag = tuple;

            button.GotFocus += ItemOrder_GotFocus;
            button.LostFocus += ItemOrder_LostFocus;

            int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
            if (a != -1)
                OrderPanelInfoWrapPanel.Children.Insert(a + 1, button);
            else
                OrderPanelInfoWrapPanel.Children.Add(button);
        }

        private void UI_OrderItem_Modifiers(MenuItemModifier itemModifier)
        {
            int targetPosition = 50;
            int paddingLength = targetPosition - itemModifier.Name.Length - 1; // -1 учитывает "⠀" в начале
            string paddedName = $"⠀{itemModifier.Name}".PadRight(paddingLength, ' ');

            System.Windows.Controls.Button button = new System.Windows.Controls.Button()
            {
                Width = 605,
                Height = 80,
                Margin = new Thickness(0, 5, 0, 0),
                Content = Convert.ToString($"{paddedName}⠀⠀⠀⠀⠀{itemModifier.AdditionalCost}₽"),
                FontSize = 24
            };
            button.Style = (Style)FindResource("ButtonOrderItemModifier");
            button.Tag = itemModifier;
            button.GotFocus += ItemOrder_GotFocus;
            button.LostFocus += ItemOrder_LostFocus;

            int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
            if (a != -1)
                OrderPanelInfoWrapPanel.Children.Insert(a + 1, button);
            else
                OrderPanelInfoWrapPanel.Children.Add(button);
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
                        if (item.Id != -1)
                        {
                            context.OrderItems.Add(item);
                            foreach (var mod in item.Modifiers)
                            {
                                context.OrderItemModifiers.Add(mod);
                            }
                        }
                        else
                        {
                            foreach (var mod in item.Modifiers)
                            {
                                context.OrderItemModifiers.Add(mod);
                            }
                        }
                    }
                }
                context.SaveChanges();
                NavigationService.GoBack();
            }
        }

        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "1";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "2";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "3";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "4";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "5";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "6";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "7";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "8";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "9";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string currentValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture);
            if (currentValue.Length > 0)
            {
                string newValue = currentValue.Substring(0, currentValue.Length - 1);
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    ItemQuantityNumericUpDown.Value = result;
                else
                    ItemQuantityNumericUpDown.Value = 0; // Если строка пустая, сбрасываем на 0
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            string newValue = ItemQuantityNumericUpDown.Value.ToString(CultureInfo.InvariantCulture) + "0";
            if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                ItemQuantityNumericUpDown.Value = result;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                var item = context.OrderItems.Where(i => i.Id == _now_order_item.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Quantity = ItemQuantityNumericUpDown.Value;
                    context.Update(item);
                    context.SaveChanges();
                    RefreshOrderPanelInfo();
                }
                else
                {
                    int index = _list_order.Items.IndexOf(_now_order_item);
                    _list_order.Items[index].Quantity = ItemQuantityNumericUpDown.Value;

                    int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
                    if (a != -1)
                    {
                        UI_OrderItems(_now_menu_item, _list_order.Items[index]);
                        OrderPanelInfoWrapPanel.Children.RemoveAt(a);
                    }
                }
            }
        }
    }
}
