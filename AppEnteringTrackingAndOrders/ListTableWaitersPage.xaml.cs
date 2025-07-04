﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для ListTableWaiters.xaml
    /// </summary>
    public partial class ListTableWaitersPage : Page
    {
        private int? _IDYourUserRoles;
        private User _user;
        private bool _theme = true;
        private bool _tableoruser = true;
        private List<User> _users;
        private int numview = -1;

        public ListTableWaitersPage(User user)
        {
            _user = user;
            
            InitializeComponent();
            // Подписка на события
            myScrollViewer.PreviewMouseLeftButtonDown += ScrollViewer_PreviewMouseLeftButtonDown;
            myScrollViewer.PreviewMouseMove += ScrollViewer_PreviewMouseMove;
            myScrollViewer.PreviewMouseLeftButtonUp += ScrollViewer_PreviewMouseLeftButtonUp;

            // Отключаем обработку сенсорного Press & Hold
            Stylus.SetIsPressAndHoldEnabled(myScrollViewer, false);

            _IDYourUserRoles = GetRoleIdForUser(user);
            if (_IDYourUserRoles != null)
            {
                if (_IDYourUserRoles == 3)
                {
                    ButtonLeftTopMenu.IsEnabled = false;
                    ButtonRightTopMenu.IsEnabled = false;
                    ButtonChangeViewTableOrUser.IsEnabled = false;
                    ButtonCenterTopMenu.IsEnabled = false;
                    ButtonCenterTopMenu.Content = $"Все заказы {_user.Username}";
                }
            }
            RefreshMenuDataDefault();

            using (var context = new RestaurantContext())
            {
                _users = context.Users.ToList();
            }
        }

        private void AddButtonsToWrapPanel(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                OrdersPage orderpage;
                List<Order> orders = context.Orders.AsNoTracking().ToList();
                if (orders.LastOrDefault() != null)
                    orderpage = new OrdersPage(_user, orders.LastOrDefault().Id + 1);
                else
                    orderpage = new OrdersPage(_user, 1);
                PreOrderPage preOrderPage = new PreOrderPage(orderpage);
                orderpage.Unloaded += (s, args) => RefreshMenuDataDefault();
                if (_theme == false)
                    orderpage.Theme = true;
                else
                    orderpage.Theme = false;
                NavigationService.Navigate(preOrderPage);
            }
        }

        private void EditButtonsToWrapPanel(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                OrdersPage orderPage = (OrdersPage)clickedButton.Tag;
                if (orderPage != null)
                {
                    if (orderPage.IsPaid == false)
                    {
                        if (_theme == false)
                            orderPage.Theme = true;
                        else
                            orderPage.Theme = false;

                        NavigationService.Navigate(orderPage);
                    }
                    else
                    {
                        if (_IDYourUserRoles != 3)
                        {
                            if (_theme == false)
                                orderPage.Theme = true;
                            else
                                orderPage.Theme = false;

                            NavigationService.Navigate(orderPage);
                        }
                    }
                }
            }
        }

        private void RefreshMenuDataDefault()
        {
            WrapPanelOrders.Children.Clear();
            WrapPanelOrders.Children.Add(AddOrderButton);
            using (var context = new RestaurantContext())
            {
                List<Order> orders;

                if (_IDYourUserRoles != 3)
                {
                    if (numview == -1)
                        if (_tableoruser == true)
                            orders = context.Orders.Where(i => i.IsClosed == false).OrderBy(i => i.TableID).AsNoTracking().ToList();
                        else
                            orders = context.Orders.Where(i => i.IsClosed == false).OrderBy(i => i.User.Username).ThenBy(i => i.TableID).AsNoTracking().ToList();
                    else
                        if (_tableoruser == true)
                            orders = context.Orders.Where(i => i.UserId == _users[numview].UserId && i.IsClosed == false).OrderBy(i => i.TableID).AsNoTracking().ToList();
                        else
                            orders = context.Orders.Where(i => i.UserId == _users[numview].UserId && i.IsClosed == false).OrderBy(i => i.User.Username).ThenBy(i => i.TableID).AsNoTracking().ToList();
                }
                else
                    orders = context.Orders.Where(i => i.UserId == _user.UserId && i.IsClosed == false).OrderBy(i => i.TableID).AsNoTracking().ToList();

                foreach (var order in orders)
                {
                    OrdersPage orderpage = new OrdersPage(_user, order.Id);
                    orderpage.Unloaded += (s, args) => RefreshMenuDataDefault();
                    orderpage.ID = order.Id;

                    Button button = new Button()
                    {
                        Width = 365,
                        Height = 175,
                        Margin = new Thickness(0, 0, 10, 10),
                        FontSize = 24
                    };

                    decimal orderprise = 0.00M;
                    List<OrderItem> countItem = context.OrderItems.Where(i => i.OrderId == order.Id).ToList();
                    if (countItem != null)
                        foreach (var item in countItem)
                        {
                            var price = context.MenuItems.Where(i => i.Id == item.MenuItemId).FirstOrDefault();
                            if (price != null)
                                orderprise += price.Price * item.Quantity;
                        }

                    var user = context.Users.Where(i => i.UserId == order.UserId).FirstOrDefault();
                    button.Style = (Style)FindResource("ButtonStyleFull");

                    if (user == null)
                        MessageBox.Show("Не найден ни один пользователь !!! ", "Критическая ошибка!");
                    if (order.IsPaid == false)
                        button.Content = $"Стол №{order.TableID}" + $"                   {orderprise}₽\n\n{user.Username}\n{order.OrderDate.DateTime.ToString("HH:mm")} • Зал • Общий";
                    else
                    {
                        button.Style = (Style)FindResource("ButtonStyleFullRed");
                        button.Content = $"Стол №{order.TableID}" + $"                   {orderprise}₽\nОПЛАЧЕН!!!\n{user.Username}\n{order.OrderDate.DateTime.ToString("HH:mm")} • Зал • Общий";
                    }

                    orderpage.IsPaid = order.IsPaid;
                    button.Tag = orderpage;
                    button.Click += EditButtonsToWrapPanel;
                    WrapPanelOrders.Children.Add(button);
                }
            }
        }

        private void ButtonChangeViewTableOrUser_Click(object sender, RoutedEventArgs e)
        {
            if (_tableoruser == false)
            {
                _tableoruser = true;
                ButtonChangeViewTableOrUser.Content = "По столам";
                RefreshMenuDataDefault();
            }
            else if (_tableoruser == true)
            {
                _tableoruser = false;
                ButtonChangeViewTableOrUser.Content = "По официантам";
                RefreshMenuDataDefault();
            }
        }

        private void ButtonLeftTopMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_users.Count == 0) return;
            numview = (numview <= 0) ? _users.Count - 1 : numview - 1;
            UpdateButtonCenterTopMenu();

        }

        private void ButtonRightTopMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_users.Count == 0) return;
            numview = (numview >= _users.Count - 1) ? 0 : numview + 1;
            UpdateButtonCenterTopMenu();
        }

        private void ButtonCenterTopMenu_Click(object sender, RoutedEventArgs e)
        {
            numview = -1;
            UpdateButtonCenterTopMenu();
        }

        private void UpdateButtonCenterTopMenu()
        {
            ButtonCenterTopMenu.Content = (numview == -1) ? "Все официанты" : _users[numview].Username;
            RefreshMenuDataDefault();
        }

        private void ButtonLightDarkTheme_Click(object sender, RoutedEventArgs e)
        {
            Uri uri;
            // определяем путь к файлу ресурсов
            if (_theme == true)
            {
                uri = new Uri("light.xaml", UriKind.Relative);
                ImageLeftButton.Source = new BitmapImage(new Uri("/Image/buttonleft.png", UriKind.Relative));
                ImageRightButton.Source = new BitmapImage(new Uri("/Image/buttonleft.png", UriKind.Relative));
                ImageLightDarkTheme.Source = new BitmapImage(new Uri("/Image/moonblack.png", UriKind.Relative));
                ImageLogOut.Source = new BitmapImage(new Uri("/Image/logoutblack.png", UriKind.Relative));
                _theme = false;
            }
            else
            {
                uri = new Uri("dark.xaml", UriKind.Relative);
                ImageLeftButton.Source = new BitmapImage(new Uri("/Image/buttonleftwhite.png", UriKind.Relative));
                ImageRightButton.Source = new BitmapImage(new Uri("/Image/buttonleftwhite.png", UriKind.Relative));
                ImageLightDarkTheme.Source = new BitmapImage(new Uri("/Image/lightmode.png", UriKind.Relative));
                ImageLogOut.Source = new BitmapImage(new Uri("/Image/logout.png", UriKind.Relative));
                _theme = true;
            }

            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = System.Windows.Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            System.Windows.Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            RefreshMenuDataDefault();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private Point _scrollMousePoint;
        private double _hOffset, _vOffset;
        private bool _isDragging = false;
        private const double DragThreshold = 5;

        private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _scrollMousePoint = e.GetPosition(myScrollViewer);
            _hOffset = myScrollViewer.HorizontalOffset;
            _vOffset = myScrollViewer.VerticalOffset;
            _isDragging = false; // Сбрасываем флаг перетаскивания
        }

        private void ScrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            Point pos = e.GetPosition(myScrollViewer);
            double deltaX = Math.Abs(pos.X - _scrollMousePoint.X);
            double deltaY = Math.Abs(pos.Y - _scrollMousePoint.Y);

            // Если движение больше порога, включаем скроллинг
            if (deltaX > DragThreshold || deltaY > DragThreshold)
            {
                _isDragging = true;
                myScrollViewer.ScrollToHorizontalOffset(_hOffset + (_scrollMousePoint.X - pos.X));
                myScrollViewer.ScrollToVerticalOffset(_vOffset + (_scrollMousePoint.Y - pos.Y));
            }
        }

        private void ScrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Если мы двигали, блокируем клик
            if (_isDragging)
            {
                e.Handled = true;
            }
        }
    }
}
