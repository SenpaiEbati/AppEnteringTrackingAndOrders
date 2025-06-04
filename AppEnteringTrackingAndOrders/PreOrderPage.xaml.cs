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
using static MaterialDesignThemes.Wpf.Theme;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для AddModifierItemPage.xaml
    /// </summary>
    public partial class PreOrderPage : Page
    {
        private OrdersPage _ordersPage;

        public PreOrderPage(OrdersPage ordersPage)
        {
            InitializeComponent();
            _ordersPage = ordersPage;

            using (var context = new RestaurantContext())
            {
                var existingTables = context.Orders
                    .Select(o => o.TableID)
                    .Distinct()
                    .ToList();

                int nextTableId = 1;
                while (existingTables.Contains(nextTableId))
                {
                    nextTableId++;
                }

                NumericTableID.Value = nextTableId;
            }
        }

        private void BackOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Клавиатура с цифрами
        // ---------------------------------------
        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "1";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "1";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;

                NumericTableID.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "2";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "2";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "3";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "3";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "4";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "4";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "5";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "5";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "6";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "6";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "7";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "7";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "8";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "8";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "9";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "9";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string currentValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture);
                if (currentValue.Length > 0)
                {
                    string newValue = currentValue.Substring(0, currentValue.Length - 1);
                    if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                        NumericGuestCount.Value = result;
                    else
                        NumericGuestCount.Value = 0; // Если строка пустая, сбрасываем на 0
                }
                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string currentValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture);
                if (currentValue.Length > 0)
                {
                    string newValue = currentValue.Substring(0, currentValue.Length - 1);
                    if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                        NumericTableID.Value = result;
                    else
                        NumericTableID.Value = 0; // Если строка пустая, сбрасываем на 0
                }
                NumericTableID.Focus();
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (NumericGuestCount.IsFocused)
            {
                string newValue = NumericGuestCount.Value.ToString(CultureInfo.InvariantCulture) + "1";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericGuestCount.Value = result;

                NumericGuestCount.Focus();
            }
            else if (NumericTableID.IsFocused)
            {
                string newValue = NumericTableID.Value.ToString(CultureInfo.InvariantCulture) + "0";
                if (int.TryParse(newValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    NumericTableID.Value = result;
                NumericTableID.Focus();
            }
        }

        private void СontinuationItemButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                var check = context.Orders.Where(i => i.TableID == Convert.ToInt32(NumericTableID.Value)).FirstOrDefault();
                if (check == null)
                {
                    List<Order> orders = context.Orders.AsNoTracking().ToList();
                    if (orders.LastOrDefault() != null)
                        _ordersPage.ID = orders.LastOrDefault().Id + 1;
                    else
                        _ordersPage.ID = 1;
                    _ordersPage.TableID = Convert.ToInt32(NumericTableID.Value);
                    _ordersPage.Guest = Convert.ToInt32(NumericGuestCount.Value);
                    NavigationService.Navigate(_ordersPage);
                }
                else
                    ShowError(NumericTableID, "Заказ с данным столом уже открыт!");
            }
        }

        private void ShowError(Control control, string hintMessage)
        {
            if (control == NumericGuestCount) NumericGuestCount.Foreground = Brushes.Red;
            if (control == NumericTableID) NumericTableID.Foreground = Brushes.Red;

            HintAssist.SetHint(control, hintMessage);
        }

        private void NumericGuestCount_GotFocus(object sender, RoutedEventArgs e)
        {
            NumericGuestCount.Foreground = Brushes.Black;
        }

        private void NumericTableID_GotFocus(object sender, RoutedEventArgs e)
        {
            NumericTableID.Foreground = Brushes.Black;
        }
    }
}

