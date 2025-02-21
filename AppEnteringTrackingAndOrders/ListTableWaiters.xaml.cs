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
        private int countbutton = 0;
        public ListTableWaiters(User user)
        {
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
                    BorderButtonLeftTopMenu.Width += 5;
                    ButtonLeftTopMenu.Visibility = Visibility.Hidden;
                    ButtonRightTopMenu.Visibility = Visibility.Hidden;
                    TextBlockBorderCenterTopMenu.Text = "Все заказы";
                }
            }
        }

        private void AddButtonsToWrapPanel(object sender, RoutedEventArgs e)
        {
            Button button = new Button
            {
                Width = 365,
                Height = 175,
                Margin = new Thickness(0,0,10,10)
            };
            button.Style = (Style)FindResource("ButtonStyleFull");
            WrapPanelOrders.Children.Add(button);
            
        }

        private void ButtonLeftTopMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRightTopMenu_Click(object sender, RoutedEventArgs e)
        {

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
