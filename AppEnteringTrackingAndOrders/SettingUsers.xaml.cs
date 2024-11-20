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
using static MaterialDesignThemes.Wpf.Theme;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static AppEnteringTrackingAndOrders.ConstantsInitialValuesMethodsDb;

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для SettingUsers.xaml
    /// </summary>
    public partial class SettingUsers : Page
    {
        private List<string> _rolesbuttonchangeadmin;
        private List<string> _rolesbuttonadd;

        public SettingUsers()
        {
            InitializeComponent();

            _rolesbuttonchangeadmin = _roles.SkipLast(2).ToList();
            _rolesbuttonadd = _roles.Skip(1).ToList();
            ComboBoxRoles.ItemsSource = _rolesbuttonadd;
        }

        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "1";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "1";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "2";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "2";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "3";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "3";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "4";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "4";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "5";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "5";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "6";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "6";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "7";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "7";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "8";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "8";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "9";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "9";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (textBox.Text.Length > 0)
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                if (passwordBoxOne.Password.Length > 0)
                    passwordBoxOne.Password = passwordBoxOne.Password.Substring(0, passwordBoxOne.Password.Length - 1);
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void CenterButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += ".";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += ".";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "0";
                textBox.Focus();
            }
            else if (passwordBoxOne.IsKeyboardFocused)
            {
                passwordBoxOne.Password += "0";
                passwordBoxOne.Focus();
            }
            else if (passwordBoxTwo.IsKeyboardFocused)
            {
                passwordBoxTwo.Password += "0";
                passwordBoxTwo.Focus();
            }
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (!FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && ComboBoxRoles.Text.Length != 0)
            {   
                AddUserWithRoles(textBox.Text, passwordBoxOne.Password, ComboBoxRoles.Text);

                MessageBox.Show("ADD USER");

                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                textBox.Foreground = Brushes.Green;
                HintAssist.SetHint(textBox, "Добавлен новый пользователь");
            }
            else if (!FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                MessageBox.Show("ERROR ADD USER NO ComboBoxRoles");
            }
            else if (!FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                MessageBox.Show("ERROR ADD USER NO passwordBoxOne");
            }
            else if (!FindUser(textBox.Text) &&
                (passwordBoxOne.Password.Length == 0 && BorderPasswordBoxOne.Visibility == Visibility.Visible) &&
                (ComboBoxRoles.Text.Length == 0 && BorderComboBoxRoles.Visibility == Visibility.Visible) &&
                (BorderPasswordBoxTwo.Visibility != Visibility.Visible))
            {
                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                MessageBox.Show("ERROR ADD USER NO ComboBoxRoles AND passwordBoxOne");
            }
            else if (!FindUser(textBox.Text))
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Visible;
                BorderComboBoxRoles.Visibility = Visibility.Visible;

                textBox.Foreground = Brushes.Black;
                passwordBoxOne.Foreground = Brushes.Black;
                passwordBoxTwo.Foreground = Brushes.Black;
                ComboBoxRoles.Foreground = Brushes.Black;

                HintAssist.SetHint(textBox, "Введите логин");
                HintAssist.SetHint(passwordBoxOne, "Введите пароль");
                HintAssist.SetHint(ComboBoxRoles, "Выберите роль");
            }
            else if (FindUser(textBox.Text))
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                textBox.Foreground = Brushes.Red;
                HintAssist.SetHint(textBox, "Данный пользователь уже существует!");
            }
            else 
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                textBox.Foreground = Brushes.Red;
                HintAssist.SetHint(textBox, "Неверно введен логин!");
            }

        }

        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length != 0) 
            {
                if (AuthenticateUser(textBox.Text, passwordBoxOne.Password) != null)
                {
                    EditUserWithRoles(textBox.Text, passwordBoxTwo.Password,ComboBoxRoles.Text);

                    MessageBox.Show("EDIT USER");

                    BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                    BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                    BorderComboBoxRoles.Visibility = Visibility.Hidden;

                    passwordBoxOne.Password = "";
                    passwordBoxTwo.Password = "";
                    ComboBoxRoles.Text = "";

                    textBox.Foreground = Brushes.Green;
                    HintAssist.SetHint(textBox, "Изменения приняты");
                }
                else
                {
                    if (textBox.Text == "1")
                        ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                    else
                        ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                    passwordBoxOne.Foreground = Brushes.Red;
                    HintAssist.SetHint(passwordBoxOne, "Неправильный пароль!");
                }
                
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length != 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                MessageBox.Show("ERROR EDIT USER NO passwordBoxOne");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxTwo.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
                MessageBox.Show("ERROR EDIT USER NO passwordBoxTwo");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                passwordBoxTwo.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
                MessageBox.Show("ERROR EDIT USER NO passwordBoxOne AND passwordBoxTwo");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length == 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxTwo.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxTwo");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!"); 
                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne");
            }
            else if (FindUser(textBox.Text) && 
                (passwordBoxOne.Password.Length == 0 && BorderPasswordBoxOne.Visibility == Visibility.Visible) && 
                (passwordBoxTwo.Password.Length == 0 && BorderPasswordBoxTwo.Visibility == Visibility.Visible ) && 
                (ComboBoxRoles.Text.Length == 0 && BorderComboBoxRoles.Visibility == Visibility.Visible))
            {
                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                passwordBoxTwo.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
                ComboBoxRoles.Foreground = Brushes.Red;
                HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
                MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne AND passwordBoxTwo");
            }
            else if (FindUser(textBox.Text))
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                if (textBox.Text == "1")
                    ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
                else
                    ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                BorderPasswordBoxTwo.Visibility = Visibility.Visible;
                BorderPasswordBoxOne.Visibility = Visibility.Visible;
                BorderComboBoxRoles.Visibility = Visibility.Visible;

                textBox.Foreground = Brushes.Black;
                passwordBoxOne.Foreground = Brushes.Black;
                passwordBoxTwo.Foreground = Brushes.Black;
                ComboBoxRoles.Foreground = Brushes.Black;

                HintAssist.SetHint(textBox, "Введите логин");
                HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");
                HintAssist.SetHint(passwordBoxTwo, "Введите новый пароль");
            }
            else
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;
                textBox.Foreground = Brushes.Red;
                HintAssist.SetHint(textBox, "Не найден логин для изменения");
            }
        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length != 0)
            {
                if (AuthenticateUser(textBox.Text, passwordBoxOne.Password) != null)
                {
                    HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");
                    passwordBoxOne.Foreground = Brushes.Black;

                    if (AuthenticateUser(textBox.Text, passwordBoxTwo.Password) != null)
                    {
                        DeleteUserWithRoles(textBox.Text);

                        MessageBox.Show("DELETE USER");

                        passwordBoxOne.Password = "";
                        passwordBoxTwo.Password = "";
                        ComboBoxRoles.Text = "";

                        BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                        BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                        BorderComboBoxRoles.Visibility = Visibility.Hidden;

                        textBox.Foreground = Brushes.Green;

                        HintAssist.SetHint(textBox, "Пользователь удален");
                    }
                    else
                    {
                        passwordBoxTwo.Foreground = Brushes.Red;
                        HintAssist.SetHint(passwordBoxTwo, "Неправильный пароль!");
                    }

                }
                else
                {
                    passwordBoxOne.Foreground = Brushes.Red;
                    HintAssist.SetHint(passwordBoxOne, "Неправильный пароль!");
                }
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && passwordBoxTwo.Password.Length != 0)
            {
                passwordBoxOne.Foreground = Brushes.Red;

                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
                MessageBox.Show("ERROR DELETE USER NO passwordBoxOne");
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length == 0)
            {
                passwordBoxTwo.Foreground = Brushes.Red;

                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
                MessageBox.Show("ERROR DELETE USERNO passwordBoxTwo");
            }
            else if ((FindUser(textBox.Text) &&
                (passwordBoxOne.Password.Length == 0 && BorderPasswordBoxOne.Visibility == Visibility.Visible) &&
                (passwordBoxTwo.Password.Length == 0 && BorderPasswordBoxTwo.Visibility == Visibility.Visible)) &&
                (BorderComboBoxRoles.Visibility != Visibility.Visible))
            {
                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");

                passwordBoxTwo.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");

                MessageBox.Show("ERROR DELETE USER NO passwordBoxOne AND passwordBoxTwo");
            }
            else if (FindUser(textBox.Text) && textBox.Text == "1")
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                textBox.Foreground = Brushes.Red;
                HintAssist.SetHint(textBox, "Данный логин недоступен к удалению!");
            }
            else if (FindUser(textBox.Text))
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                ComboBoxRoles.ItemsSource = _rolesbuttonadd;

                BorderPasswordBoxTwo.Visibility = Visibility.Visible;
                BorderPasswordBoxOne.Visibility = Visibility.Visible;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                textBox.Foreground = Brushes.Black;
                passwordBoxOne.Foreground = Brushes.Black;
                passwordBoxTwo.Foreground = Brushes.Black;
                ComboBoxRoles.Foreground = Brushes.Black;

                HintAssist.SetHint(textBox, "Введите логин");
                HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");
                HintAssist.SetHint(passwordBoxTwo, "Повторите старый пароль пользователя");
            }
            else
            {
                passwordBoxOne.Password = "";
                passwordBoxTwo.Password = "";
                ComboBoxRoles.Text = "";

                BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
                BorderPasswordBoxOne.Visibility = Visibility.Hidden;
                BorderComboBoxRoles.Visibility = Visibility.Hidden;

                textBox.Foreground = Brushes.Red;
                HintAssist.SetHint(textBox, "Не найден логин для удаления!");
            }
        }

        private void passwordBoxOne_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBoxOne.Foreground = Brushes.Black;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Black;
        }

        private void passwordBoxTwo_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBoxTwo.Foreground = Brushes.Black;
        }

        private void ComboBoxRoles_DropDownOpened(object sender, EventArgs e)
        {
            ComboBoxRoles.Foreground = Brushes.White;
        }

        private void ComboBoxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxRoles.Foreground = Brushes.Black;
        }

        private void ComboBoxRoles_DropDownClosed(object sender, EventArgs e)
        {
            ComboBoxRoles.Foreground = Brushes.Black;
        }

        private void BackMainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
