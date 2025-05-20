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
                    BorderCenterTopMenu.Width += 5;
                    ButtonLeftTopMenu.Visibility = Visibility.Hidden;
                    ButtonRightTopMenu.Visibility = Visibility.Hidden;
                    TextBlockBorderCenterTopMenu.Text = "Все заказы";
                }
            }
            RefreshMenuData();
        }

        private void AddButtonsToWrapPanel(object sender, RoutedEventArgs e)
        {
            OrdersPage orderpage = new OrdersPage(_user);
            PreOrderPage preOrderPage = new PreOrderPage(orderpage);
            orderpage.Unloaded += (s, args) => RefreshMenuData();
            if (_theme == false)
                orderpage._theme = true;
            else
                orderpage._theme = false;
            NavigationService.Navigate(preOrderPage);

        }

        private void EditButtonsToWrapPanel(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                OrdersPage orderPage = (OrdersPage)clickedButton.Tag;
                if (orderPage != null)
                {
                    if (_theme == false)
                        orderPage._theme = true;
                    else
                        orderPage._theme = false;

                    NavigationService.Navigate(orderPage);
                }
            }
        }

        private void RefreshMenuData()
        {
            WrapPanelOrders.Children.Clear();
            WrapPanelOrders.Children.Add(AddOrderButton);
            using (var context = new RestaurantContext())
            {
                List<Order> orders = context.Orders.AsNoTracking().ToList();
                foreach (var order in orders)
                {
                    OrdersPage orderpage = new OrdersPage(_user);
                    orderpage._ID = order.Id;
                    Button button = new Button()
                    {
                        Width = 365,
                        Height = 175,
                        Margin = new Thickness(0, 0, 10, 10),
                        FontSize = 24
                    };
                    decimal orderprise = 0.00M;
                    for (int i = 0; i < order.Items.Count; i++)
                    {
                        orderprise += order.Items[i].MenuItem.Price;
                    }
                    button.Content = $"{order.Id}".ToUpper() + $"                                  {orderprise}₽\n\nИванов\n{order.OrderDate.Hour}:{order.OrderDate.Minute} • Зал • Общий";
                    button.Style = (Style)FindResource("ButtonStyleFull");
                    button.Tag = orderpage;
                    button.Click += EditButtonsToWrapPanel;
                    WrapPanelOrders.Children.Add(button);
                }
            }
        }

        private void ButtonLeftTopMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRightTopMenu_Click(object sender, RoutedEventArgs e)
        {

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
            RefreshMenuData();
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
