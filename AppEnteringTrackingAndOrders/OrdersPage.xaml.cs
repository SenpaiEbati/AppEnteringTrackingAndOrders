using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private decimal _sumorder = 0.00M;
        private UIElement _now_order_UI_item;
        private MenuItem _now_menu_item;
        private OrderItem _now_order_item;
        private OrderItemModifier _now_order_item_modifier;
        private MenuItem _old_menu_item;
        private MenuItemModifier _now_menu_item_modifier;
        private UIElement _now_order_modifier_UI_item;
        private int _now_guest_id;
        private UIElement _now_guest_UI_item;
        private User _user;
        private int? _IDYourUserRoles;

        // Свойства
        private int _ID = 0;
        private int _Guest = 0;
        private int _TableID = 0;
        private bool _Theme;
        private bool _IsPaid = false;
        private bool _IsClosed = false;


        public OrdersPage(User user, int ID)
        {
            InitializeComponent();
            _user = user;
            _ID = ID;
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

            }

            RefreshOrderPanelInfo();
            RefreshGroupMenuData();
        }

        private void YourPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_Theme == true)
            {
                ImageLeftButton.Source = new BitmapImage(new Uri("/Image/buttonleft.png", UriKind.Relative));
                ImageRightButton.Source = new BitmapImage(new Uri("/Image/buttonleft.png", UriKind.Relative));
                ImageDeleteOrder.Source = new BitmapImage(new Uri("/Image/deleteorderblack.png", UriKind.Relative));
            }
            else
            {
                ImageLeftButton.Source = new BitmapImage(new Uri("/Image/buttonleftwhite.png", UriKind.Relative));
                ImageRightButton.Source = new BitmapImage(new Uri("/Image/buttonleftwhite.png", UriKind.Relative));
                ImageDeleteOrder.Source = new BitmapImage(new Uri("/Image/deleteorder.png", UriKind.Relative));
            }

            using (var context = new RestaurantContext())
            {
                var order = context.Orders.FirstOrDefault(i => i.Id == _ID);
                if (order != null)
                {
                    _is_new_order = false;
                    _old_order = order;
                    _TableID = order.TableID;
                    _IsPaid = order.IsPaid;
                    _IsClosed = order.IsClosed;
                    _Guest = context.OrderItems.Where(i => i.OrderId == _ID && i.Guest > 0 && order.IsClosed == false).Count();
                    NameOrderTopText.Text = $"Изменение заказа №{_ID}";
                }
                else
                {
                    _is_new_order = true;
                    var oldorder = new Order { Id = _ID, TableID = _TableID, OrderDate = DateTime.UtcNow, UserId = _user.UserId, IsPaid = _IsPaid};
                    _old_order = oldorder;
                    NameOrderTopText.Text = $"Создание заказа №{_ID}";
                }
            }
            TableGuestTopText.Text = $"Стол:{_TableID} Гостей: {_Guest}";
            TimeTopText.Text = DateTime.Now.ToString("HH:mm");

            if (_is_new_order == false)
            {
                ButtonDeleteOrder.Style = (Style)FindResource("ButtonStyleFull");
            }
            if (_IsPaid == true && _IDYourUserRoles != 3)
            {
                ButtonCloseOrder.Visibility = Visibility.Visible;
            }
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
                                Focusable = false,
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
                                OrderId = _old_order.Id,
                                Guest = 0
                            };
                            if (_now_guest_id > 0) 
                            {
                                orderitem.Guest = _now_guest_id;
                                _list_order.Items.Add(orderitem);
                            }
                            else
                            {
                                _list_order.Items.Add(orderitem);
                            }
                            

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
                    _now_menu_item_modifier = null;
                    _now_order_item_modifier = null;
                    _now_order_modifier_UI_item = null;
                    _now_menu_item = tuple.Item1;
                    _now_order_item = tuple.Item2;
                    _now_order_UI_item = clickedItemOrder;
                    GroupMenuBorderText.Text = _now_menu_item.Name;
                    ItemMenuBorderTextBlock.Text = $"Выберите взаимодействие с {_now_menu_item.Name}";
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    ModifierMenuButtonsWrapPanel_ModifierButton.Visibility = Visibility.Visible;
                    ModifierMenuButtonsWrapPanel_QuantityButton.Visibility = Visibility.Visible;
                    return;
                }

                if (clickedItemOrder.Tag is ValueTuple<MenuItemModifier, OrderItemModifier> tupleMod)
                {
                    _now_menu_item_modifier = tupleMod.Item1;
                    _now_order_item_modifier = tupleMod.Item2;
                    _now_order_modifier_UI_item = clickedItemOrder;
                    GroupMenuBorderText.Text = _now_menu_item_modifier.Name;
                    ItemMenuBorderTextBlock.Text = $"Выберите взаимодействие с {_now_menu_item_modifier.Name}";
                    GroupMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ItemMenuButtonsScrollViewer.Visibility = Visibility.Hidden;
                    ModifierMenuButtonsScrollViewer.Visibility = Visibility.Visible;
                    ModifierMenuButtonsWrapPanel_ModifierButton.Visibility = Visibility.Collapsed;
                    ModifierMenuButtonsWrapPanel_QuantityButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ItemOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedItemOrder = sender as System.Windows.Controls.Button;
            if (clickedItemOrder != null)
            {
                _now_menu_item_modifier = null;
                _now_order_item_modifier = null;
                _now_order_modifier_UI_item = null;
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
                            if (index == -1)
                                index = context.OrderItems.Where(x => x.Id == _now_order_item.Id).FirstOrDefault().Id;

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

                            UI_OrderItem_Modifiers(itemModifier, OrderItemModifier);
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

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                var item = context.OrderItems.Where(i => i.Id == _now_order_item.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Quantity = ItemQuantityNumericUpDown.Value;
                    context.OrderItems.Update(item);
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
                    RefreshOrderSum();
                }
            }
        }

        private void ModifierMenuButtonsWrapPanel_DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_now_order_item != null)
            {
                using (var context = new RestaurantContext())
                {
                    var item = context.OrderItems.FirstOrDefault(i => i.Id == _now_order_item.Id);
                    if (item != null)
                    {
                        // Удаляем из базы данных
                        context.OrderItems.Remove(item);
                        context.SaveChanges();
                        RefreshOrderPanelInfo();
                    }
                    else
                    {
                        // Удаляем из временного списка
                        int itemIndex = _list_order.Items.IndexOf(_now_order_item);
                        if (itemIndex != -1)
                        {
                            // Находим индекс элемента в UI
                            int uiIndex = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
                            if (uiIndex != -1)
                            {
                                // Удаляем сам элемент
                                OrderPanelInfoWrapPanel.Children.RemoveAt(uiIndex);

                                // Удаляем все модификаторы этого элемента
                                // Идем назад, так как модификаторы следуют сразу после элемента
                                for (int i = uiIndex; i < OrderPanelInfoWrapPanel.Children.Count;)
                                {
                                    var child = OrderPanelInfoWrapPanel.Children[i];
                                    if (child is System.Windows.Controls.Button button && button.Tag is ValueTuple<MenuItemModifier, OrderItemModifier>)
                                    {
                                        OrderPanelInfoWrapPanel.Children.RemoveAt(i);
                                    }
                                    else
                                    {
                                        break; // Прерываем, если следующий элемент не модификатор
                                    }
                                }

                                // Проверяем, не нужно ли удалить заголовок гостя
                                if (itemIndex < _list_order.Items.Count && _list_order.Items[itemIndex].Guest > 0)
                                {
                                    // Ищем заголовок гостя перед удаленным элементом
                                    if (uiIndex > 0 && OrderPanelInfoWrapPanel.Children[uiIndex - 1] is System.Windows.Controls.Button guestButton &&
                                        guestButton.Tag is int guestId && guestId == _list_order.Items[itemIndex].Guest)
                                    {
                                        OrderPanelInfoWrapPanel.Children.RemoveAt(uiIndex - 1);
                                        _Guest--;
                                    }
                                }

                                // Удаляем из временного списка
                                _list_order.Items.RemoveAt(itemIndex);
                            }
                        }
                    }
                }
                RefreshOrderSum();
            }
            else if (_now_order_item_modifier != null)
            {
                using (var context = new RestaurantContext())
                {
                    var itemMod = context.OrderItemModifiers.FirstOrDefault(i => i.Id == _now_order_item_modifier.Id);
                    if (itemMod != null)
                    {
                        // Удаляем из базы данных
                        context.OrderItemModifiers.Remove(itemMod);
                        context.SaveChanges();
                        RefreshOrderPanelInfo();
                    }
                    else
                    {
                        // Удаляем из временного списка
                        int uiIndex = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_modifier_UI_item);
                        if (uiIndex != -1)
                        {
                            // Находим родительский элемент (блюдо) для этого модификатора
                            int parentIndex = -1;
                            for (int i = uiIndex - 1; i >= 0; i--)
                            {
                                var child = OrderPanelInfoWrapPanel.Children[i];
                                if (child is System.Windows.Controls.Button button && button.Tag is ValueTuple<MenuItem, OrderItem>)
                                {
                                    parentIndex = i;
                                    break;
                                }
                            }

                            if (parentIndex != -1)
                            {
                                // Находим индекс в списке заказов
                                var parentTuple = (ValueTuple<MenuItem, OrderItem>)((System.Windows.Controls.Button)OrderPanelInfoWrapPanel.Children[parentIndex]).Tag;
                                int orderItemIndex = _list_order.Items.IndexOf(parentTuple.Item2);

                                if (orderItemIndex != -1)
                                {
                                    // Находим и удаляем модификатор из списка
                                    var modifierToRemove = (ValueTuple<MenuItemModifier, OrderItemModifier>)((System.Windows.Controls.Button)_now_order_modifier_UI_item).Tag;
                                    _list_order.Items[orderItemIndex].Modifiers.Remove(modifierToRemove.Item2);

                                    // Удаляем из UI
                                    OrderPanelInfoWrapPanel.Children.RemoveAt(uiIndex);
                                }
                            }
                        }
                    }
                }
                RefreshOrderSum();
            }
        }

        private void BackListTableWaitersButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем список несохраненных изменений
            _list_order.Items.Clear();

            NavigationService.GoBack();
            if (_is_new_order)
                NavigationService.GoBack();
        }

        private void OrderPanelInfoAddGuestButton_Click(object sender, RoutedEventArgs e)
        {
            if (_now_order_item != null)
            {
                using (var context = new RestaurantContext())
                {
                    var item = context.OrderItems.Where(i => i.Id == _now_order_item.Id).FirstOrDefault();
                    if (item != null && item.Guest == 0)
                    {
                        item.Guest = ++_Guest; // Увеличиваем счетчик гостей перед использованием
                        context.OrderItems.Update(item);
                        context.SaveChanges();

                        // Получаем индекс текущего элемента в UI
                        int currentIndex = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);

                        // Перемещаем элемент и его модификаторы в конец
                        MoveItemToBottom(currentIndex, item.Guest);

                        RefreshOrderPanelInfo();
                    }
                    else
                    {
                        if (_now_order_item.Guest == 0)
                        {
                            int i = _list_order.Items.IndexOf(_now_order_item);
                            int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
                            if (i != -1)
                            {
                                _now_order_item.Guest = ++_Guest; // Увеличиваем счетчик гостей перед использованием
                            }
                            if (a != -1)
                            {
                                // Перемещаем элемент и его модификаторы в конец
                                MoveItemToBottom(a, _now_order_item.Guest);
                            }
                        }
                    }
                }
            }
            else if (_now_menu_item_modifier != null)
            {
                using (var context = new RestaurantContext())
                {
                    var itemMod = context.OrderItemModifiers.Where(i => i.Id == _now_order_item_modifier.Id).FirstOrDefault();
                    if (itemMod != null)
                    {
                        var item = context.OrderItems.Where(i => i.Id == itemMod.OrderItemId).FirstOrDefault();
                        if (item != null && item.Guest == 0)
                        {
                            item.Guest = ++_Guest; // Увеличиваем счетчик гостей перед использованием
                            context.OrderItems.Update(item);
                            context.SaveChanges();

                            // Находим родительский элемент (блюдо) для этого модификатора
                            int parentIndex = FindParentItemIndex(itemMod.OrderItemId);
                            if (parentIndex != -1)
                            {
                                // Перемещаем элемент и его модификаторы в конец
                                MoveItemToBottom(parentIndex, item.Guest);
                            }

                            RefreshOrderPanelInfo();
                        }
                    }
                }
            }
            TableGuestTopText.Text = $"Стол:{_TableID} Гостей: {_Guest}";
        }

        // Метод для перемещения элемента и его модификаторов в конец списка
        private void MoveItemToBottom(int itemIndex, int guestId)
        {
            if (itemIndex == -1) return;

            // Находим все элементы, которые нужно переместить (блюдо + модификаторы)
            var itemsToMove = new List<UIElement>();
            int modifierCount = 0;

            // Начинаем с текущего элемента (блюда)
            itemsToMove.Add(OrderPanelInfoWrapPanel.Children[itemIndex]);

            // Проверяем следующие элементы на предмет модификаторов
            for (int i = itemIndex + 1; i < OrderPanelInfoWrapPanel.Children.Count; i++)
            {
                var child = OrderPanelInfoWrapPanel.Children[i];
                if (child is System.Windows.Controls.Button button && button.Tag is ValueTuple<MenuItemModifier, OrderItemModifier>)
                {
                    itemsToMove.Add(child);
                    modifierCount++;
                }
                else
                {
                    break; // Прерываем, если следующий элемент не модификатор
                }
            }

            // Удаляем все элементы, которые нужно переместить
            foreach (var item in itemsToMove)
            {
                OrderPanelInfoWrapPanel.Children.Remove(item);
            }

            // Добавляем заголовок гостя в конец
            UI_Guest(guestId, OrderPanelInfoWrapPanel.Children.Count, RefreshGuestSum(guestId));

            // Добавляем перемещаемые элементы после заголовка гостя
            foreach (var item in itemsToMove)
            {
                OrderPanelInfoWrapPanel.Children.Add(item);
            }

            RefreshOrderSum();
        }

        // Метод для поиска индекса родительского элемента (блюда) по ID
        private int FindParentItemIndex(int orderItemId)
        {
            for (int i = 0; i < OrderPanelInfoWrapPanel.Children.Count; i++)
            {
                var child = OrderPanelInfoWrapPanel.Children[i];
                if (child is System.Windows.Controls.Button button && button.Tag is ValueTuple<MenuItem, OrderItem> tuple &&
                    tuple.Item2.Id == orderItemId)
                {
                    return i;
                }
            }
            return -1;
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
                        Focusable = false,
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
                        Focusable = false,
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
            OrderPanelInfoWrapPanel.Children.Add(OrderPanelInfoWrapPanelBorderSum);

            using (var context = new RestaurantContext())
            {
                var order = context.Orders.Where(i => i.Id == _ID && i.IsClosed == false).FirstOrDefault();
                if (order != null)
                {
                    // Получаем все элементы заказа
                    List<OrderItem> allOrderItems = context.OrderItems
                        .Where(i => i.OrderId == _ID)
                        .Include(i => i.Modifiers)
                        .ToList();

                    // Сначала выводим элементы гостя 0 (общие позиции)
                    var commonItems = allOrderItems.Where(item => item.Guest == 0).ToList();
                    foreach (OrderItem item in commonItems)
                    {
                        var menuItem = context.MenuItems.FirstOrDefault(i => i.Id == item.MenuItemId);
                        if (menuItem != null)
                        {
                            UI_OrderItems(menuItem, item);

                            foreach (OrderItemModifier itemMod in item.Modifiers)
                            {
                                var menuItemMod = context.MenuItemModifiers.FirstOrDefault(i => i.Id == itemMod.MenuItemModifierId);
                                if (menuItemMod != null)
                                    UI_OrderItem_Modifiers(menuItemMod, itemMod);
                            }
                        }
                    }

                    // Затем выводим элементы с гостями, сгруппированные по номеру гостя
                    var itemsWithGuest = allOrderItems.Where(item => item.Guest != 0)
                                                     .GroupBy(item => item.Guest)
                                                     .OrderBy(group => group.Key)
                                                     .ToList();

                    foreach (var guestGroup in itemsWithGuest)
                    {
                        int guestId = guestGroup.Key;
                        decimal guestSum = RefreshGuestSum(guestId);

                        // Добавляем заголовок гостя
                        int currentIndex = OrderPanelInfoWrapPanel.Children.Count;
                        UI_Guest(guestId, currentIndex, guestSum);

                        // Добавляем все элементы этого гостя
                        foreach (OrderItem item in guestGroup)
                        {
                            var menuItem = context.MenuItems.FirstOrDefault(i => i.Id == item.MenuItemId);
                            if (menuItem != null)
                            {
                                UI_OrderItems(menuItem, item);

                                foreach (OrderItemModifier itemMod in item.Modifiers)
                                {
                                    var menuItemMod = context.MenuItemModifiers.FirstOrDefault(i => i.Id == itemMod.MenuItemModifierId);
                                    if (menuItemMod != null)
                                        UI_OrderItem_Modifiers(menuItemMod, itemMod);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UI_OrderItems(MenuItem menuitem, OrderItem item)
        {
            // Создаем кнопку
            System.Windows.Controls.Button button = new System.Windows.Controls.Button
            { 
                Height = 80,
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Stretch, // Растягивается по горизонтали
                Width = double.NaN,
            };

            // Создаем Grid
            Grid grid = new Grid();

            // Добавляем колонки с пропорциональной шириной (*)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(193, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(83, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(122, GridUnitType.Star) });

            // Создаем TextBlock для названия блюда (первая колонка)
            TextBlock dishNameTextBlock = new TextBlock
            {
                Text = $" {menuitem.Name}",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            Grid.SetColumn(dishNameTextBlock, 0);

            // Создаем TextBlock для количества (вторая колонка)
            TextBlock quantityTextBlock = new TextBlock
            {
                Text = $"{item.Quantity} шт.",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetColumn(quantityTextBlock, 1);

            // Создаем TextBlock для цены (третья колонка)
            TextBlock priceTextBlock = new TextBlock
            {
                Text = $"{menuitem.Price * item.Quantity} руб.",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetColumn(priceTextBlock, 2);

            // Добавляем TextBlock'и в Grid
            grid.Children.Add(dishNameTextBlock);
            grid.Children.Add(quantityTextBlock);
            grid.Children.Add(priceTextBlock);

            // Устанавливаем Grid в Content кнопки
            button.Content = grid;

            button.Style = (Style)FindResource("ButtonOrderItem");

            ValueTuple<MenuItem, OrderItem> tuple = new ValueTuple<MenuItem, OrderItem>(menuitem, item);
            button.Tag = tuple;

            button.GotFocus += ItemOrder_GotFocus;
            button.LostFocus += ItemOrder_LostFocus;

            // Вставляем элемент сразу после OrderPanelInfoWrapPanelBorderSum (индекс 0)
            int insertIndex = 1; // После суммы (индекс 0)

            // Если это элемент гостя, ищем место для вставки после заголовка гостя
            if (item.Guest > 0)
            {
                // Находим индекс заголовка гостя
                for (int i = 0; i < OrderPanelInfoWrapPanel.Children.Count; i++)
                {
                    if (OrderPanelInfoWrapPanel.Children[i] is System.Windows.Controls.Button btn &&
                        btn.Tag is int guestId && guestId == item.Guest)
                    {
                        insertIndex = i + 1;
                        break;
                    }
                }
            }

            OrderPanelInfoWrapPanel.Children.Insert(insertIndex, button);
            RefreshOrderSum();
        }

        private void UI_OrderItem_Modifiers(MenuItemModifier menuItemModifier, OrderItemModifier orderItemModifier)
        {
            // Создаем кнопку
            System.Windows.Controls.Button button = new System.Windows.Controls.Button
            {
                Height = 80,
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Stretch, // Растягивается по горизонтали
                Width = double.NaN,
            };

            // Создаем Grid
            Grid grid = new Grid();

            // Добавляем колонки с пропорциональной шириной (*)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(193, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(83, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(122, GridUnitType.Star) });

            // Создаем TextBlock для названия блюда (первая колонка)
            TextBlock dishNameTextBlock = new TextBlock
            {
                Text = menuItemModifier.Name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            Grid.SetColumn(dishNameTextBlock, 0);

            // Создаем TextBlock для количества (вторая колонка)
            TextBlock quantityTextBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetColumn(quantityTextBlock, 1);

            // Создаем TextBlock для цены (третья колонка)
            TextBlock priceTextBlock = new TextBlock
            {
                Text = $"{menuItemModifier.AdditionalCost} руб.",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetColumn(priceTextBlock, 2);

            // Добавляем TextBlock'и в Grid
            grid.Children.Add(dishNameTextBlock);
            grid.Children.Add(quantityTextBlock);
            grid.Children.Add(priceTextBlock);

            // Устанавливаем Grid в Content кнопки
            button.Content = grid;

            button.Style = (Style)FindResource("ButtonOrderItemModifier");

            ValueTuple<MenuItemModifier, OrderItemModifier> tuple = new ValueTuple<MenuItemModifier, OrderItemModifier>(menuItemModifier, orderItemModifier);
            button.Tag = tuple;

            button.GotFocus += ItemOrder_GotFocus;
            button.LostFocus += ItemOrder_LostFocus;

            int a = OrderPanelInfoWrapPanel.Children.IndexOf(_now_order_UI_item);
            if (a != -1)
                OrderPanelInfoWrapPanel.Children.Insert(a + 1, button);
            else
                OrderPanelInfoWrapPanel.Children.Add(button);

            RefreshOrderSum();
        }

        private void UI_Guest(int GuestId, int indexPanel, decimal sum)
        {
            System.Windows.Controls.Button button = new System.Windows.Controls.Button
            {
                Height = 80,
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 10, 0, 10),
                Width = double.NaN,
            };

            Grid grid = new Grid();

            // Добавляем колонки с пропорциональной шириной (*)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(193, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(83, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(122, GridUnitType.Star) });

            TextBlock dishNameTextBlock = new TextBlock
            {
                Text = $"Гость {GuestId}",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                Margin = new Thickness(10, 0, 0, 0)
            };
            Grid.SetColumn(dishNameTextBlock, 0);

            TextBlock quantityTextBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetColumn(quantityTextBlock, 1);

            // Создаем TextBlock для цены (третья колонка)
            TextBlock priceTextBlock = new TextBlock
            {
                Text = $"{sum} руб.",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, 10, 0),

            };
            Grid.SetColumn(priceTextBlock, 2);

            // Добавляем TextBlock'и в Grid
            grid.Children.Add(dishNameTextBlock);
            grid.Children.Add(quantityTextBlock);
            grid.Children.Add(priceTextBlock);

            // Устанавливаем Grid в Content кнопки
            button.Content = grid;
            button.GotFocus += Guests_GotFocus;
            button.LostFocus += Guests_LostFocus;
            button.Tag = GuestId;
            button.Style = (Style)FindResource("ButtonGray");

            TableGuestTopText.Text = $"Стол:{_TableID} Гостей: {_Guest}";

            OrderPanelInfoWrapPanel.Children.Insert(indexPanel, button);
        }

        private void Guests_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedGuest = sender as System.Windows.Controls.Button;
            if (clickedGuest != null)
            {
                int index = (int)clickedGuest.Tag;
                if (index > 0)
                {
                    _now_guest_id = index;
                    _now_guest_UI_item = clickedGuest;
                }            
            }
        }

        private void Guests_LostFocus(object sender, RoutedEventArgs e)
        {
            // Получаем элемент, который получил фокус после потери
            var newFocusedElement = Keyboard.FocusedElement as FrameworkElement;
            // Если новый фокус - это элемент с Focusable = false, игнорируем событие
            if (newFocusedElement != null && !newFocusedElement.Focusable)
            {
                return; // Не меняем стиль, фокус остаётся на текущем элементе
            }

            System.Windows.Controls.Button clickedGuest = sender as System.Windows.Controls.Button;
            if (clickedGuest != null)
            {
                _now_guest_id = -1;
                _now_guest_UI_item = null;
            }
        }

        private void RefreshOrderSum()
        {
            _sumorder = 0;
            using (var context = new RestaurantContext())
            { 
                foreach (var orderitem in _list_order.Items)
                {
                    var menuitem = context.MenuItems.Where(i => i.Id == orderitem.MenuItemId).FirstOrDefault();
                    if (menuitem != null)
                        _sumorder += menuitem.Price * orderitem.Quantity;
                    foreach (var orderitemmod in orderitem.Modifiers)
                    {
                        var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == orderitemmod.MenuItemModifierId).FirstOrDefault();
                        if (menuitemmod != null)
                            _sumorder += menuitemmod.AdditionalCost;
                    }
                }

                var orderitemB = context.OrderItems.Where(i => i.OrderId == _ID).ToList();
                foreach (var item in orderitemB)
                {
                    var menuitem = context.MenuItems.Where(i => i.Id == item.MenuItemId).FirstOrDefault();
                    if (menuitem != null)
                        _sumorder += menuitem.Price * item.Quantity;

                    var orderitemmod = context.OrderItemModifiers.Where(i => i.OrderItemId == item.Id).ToList();
                    foreach (var itemmod in orderitemmod)
                    {
                        var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == itemmod.MenuItemModifierId).FirstOrDefault();
                        if (menuitemmod != null)
                            _sumorder += menuitemmod.AdditionalCost;
                    }
                }
            }
            RefreshGeneralSum();
            ButtonPaymentOrderSum.Text = _sumorder.ToString();
        }

        private decimal RefreshGuestSum(int guestId)
        {
            decimal sumguest = 0.00M;
            using (var context = new RestaurantContext())
            {
                foreach (var orderitem in _list_order.Items)
                {
                    if (orderitem.Guest == guestId)
                    {
                        var menuitem = context.MenuItems.Where(i => i.Id == orderitem.MenuItemId).FirstOrDefault();
                        if (menuitem != null)
                            sumguest += menuitem.Price * orderitem.Quantity;
                        foreach (var orderitemmod in orderitem.Modifiers)
                        {
                            var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == orderitemmod.MenuItemModifierId).FirstOrDefault();
                            if (menuitemmod != null)
                                sumguest += menuitemmod.AdditionalCost;
                        }
                    }
                }

                var orderitemB = context.OrderItems.Where(i => i.OrderId == _ID).ToList();
                foreach (var item in orderitemB)
                {
                    if (item.Guest == guestId)
                    {
                        var menuitem = context.MenuItems.Where(i => i.Id == item.MenuItemId).FirstOrDefault();
                        if (menuitem != null)
                            sumguest += menuitem.Price * item.Quantity;

                        var orderitemmod = context.OrderItemModifiers.Where(i => i.OrderItemId == item.Id).ToList();
                        foreach (var itemmod in orderitemmod)
                        {
                            var menuitemmod = context.MenuItemModifiers.Where(i => i.Id == itemmod.MenuItemModifierId).FirstOrDefault();
                            if (menuitemmod != null)
                                sumguest += menuitemmod.AdditionalCost;
                        }
                    }
                }
            }

            return sumguest;
        }

        private void RefreshGeneralSum()
        {
            var sum = RefreshGuestSum(0);
            ButtonOrderSum.Text = sum.ToString();
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            SaveOrder();
            var context = new RestaurantContext();
            Task a = context.SendOrderAsync(_ID);

            _list_order.Items.Clear();
            NavigationService.GoBack();
            if (_is_new_order == true)
                NavigationService.GoBack();
        }

        private void SaveOrder()
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
                    var a = context.Orders.Where(i => i.Id == _ID).FirstOrDefault();
                    a.IsPaid = _IsPaid;
                    context.Update(a);
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
            }
        }

        private void ButtonDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_is_new_order == true)
            {
                /*var result = MessageBox.Show("Удалить заказ безвозратно?", "Подтверждение",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {*/
                    using (var context = new RestaurantContext())
                    {
                        if (_is_new_order == false)
                        {
                            var orderToDelete = context.Orders.Include(o => o.Items).ThenInclude(i => i.Modifiers).FirstOrDefault(o => o.Id == _ID);
                            if (orderToDelete != null)
                            {
                                foreach (var item in orderToDelete.Items)
                                {
                                    context.OrderItemModifiers.RemoveRange(item.Modifiers);
                                }
                                context.OrderItems.RemoveRange(orderToDelete.Items);

                                context.Orders.Remove(orderToDelete);

                                context.SaveChanges();
                            }
                        }
                        _list_order.Items.Clear();
                        NavigationService.GoBack();
                        if (_is_new_order == true)
                            NavigationService.GoBack();
                    }
                /*}*/
            }
        }

        private void ButtonPaymentOrder_Click(object sender, RoutedEventArgs e)
        {
            _IsPaid = true;
            SaveOrder();
            var context = new RestaurantContext();
            Task a = context.SendPaymentReceiptAsync(_ID);
            _list_order.Items.Clear();
            NavigationService.GoBack();
            if (_is_new_order == true)
                NavigationService.GoBack();
        }

        private void ButtonClosedOrder_Click(object sender, RoutedEventArgs e)
        {
            if (_IsPaid == true)
            {
                using (var context = new RestaurantContext())
                {
                    var a = context.Orders.Where(i => i.Id == _ID).FirstOrDefault();
                    _IsClosed = true;
                    a.IsClosed = _IsClosed;

                    context.SaveChanges();

                    NavigationService.GoBack();
                    if (_is_new_order == true)
                        NavigationService.GoBack();
                }
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

        // Свойства

        public int ID
        {
            //get { return _ID; }
            set { _ID = value; }
        }

        public int Guest
        {
            //get { return _Guest; }
            set { _Guest = value; }
        }

        public int TableID
        {
            //get { return _TableID; }
            set { _TableID = value; }
        }

        public bool Theme
        {
            //get { return _Theme; }
            set { _Theme = value; }
        }

        public bool IsPaid
        {
            get { return _IsPaid; }
            set { _IsPaid = value; }
        }

        
    }
}
