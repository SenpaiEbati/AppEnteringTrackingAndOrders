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
    public partial class SettingUsersPage : Page
    {
        private List<string> _rolesbuttonchangeadmin;
        private List<string> _rolesbuttonadd;

        public SettingUsersPage()
        {
            InitializeComponent();

            _rolesbuttonchangeadmin = _roles.SkipLast(2).ToList();
            _rolesbuttonadd = _roles.Skip(1).ToList();
            ComboBoxRoles.ItemsSource = _rolesbuttonadd;
        }

        // Кнопки справа для ввода цифр и символов
        // ---------------------------------------
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
        // ---------------------------------------

        private void ShowError(Control control, string hintMessage)
        {
            if (control is System.Windows.Controls.TextBox textBox) textBox.Foreground = Brushes.Red;
            if (control is System.Windows.Controls.PasswordBox passwordBox) passwordBox.Foreground = Brushes.Red;
            if (control is System.Windows.Controls.ComboBox comboBox) comboBox.Foreground = Brushes.Red;

            HintAssist.SetHint(control, hintMessage);
        }

        private void ResetForm()
        {
            passwordBoxOne.Password = "";
            passwordBoxTwo.Password = "";
            ComboBoxRoles.Text = "";

            BorderPasswordBoxOne.Visibility = Visibility.Hidden;
            BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
            BorderComboBoxRoles.Visibility = Visibility.Hidden;

            textBox.Foreground = Brushes.Black;
            passwordBoxOne.Foreground = Brushes.Black;
            passwordBoxTwo.Foreground = Brushes.Black;
            ComboBoxRoles.Foreground = Brushes.Black;
        }

        private void UpdateRolesBasedOnUser(string userText)
        {
            ComboBoxRoles.ItemsSource = userText == "1" ? _rolesbuttonchangeadmin : _rolesbuttonadd;
        }

        // Реализация кнопки добавление нового пользователя и обработка ошибок при вводе
        // ---------------------------------------
        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0 && !FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && ComboBoxRoles.Text.Length != 0)
            {
                AddNewUser();
            }
            else if (textBox.Text.Length > 0 && !FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                ShowRoleErrorAddUser();
            }
            else if (textBox.Text.Length > 0 && !FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                ShowPasswordErrorAddUser();
            }
            else if (textBox.Text.Length > 0 && !FindUser(textBox.Text)
                    && passwordBoxOne.Password.Length == 0 && BorderPasswordBoxOne.Visibility == Visibility.Visible
                    && ComboBoxRoles.Text.Length == 0 && BorderComboBoxRoles.Visibility == Visibility.Visible
                    && BorderPasswordBoxTwo.Visibility != Visibility.Visible)
            {
                ShowRoleAndPasswordErrorAddUser();
            }
            else if (textBox.Text.Length > 0 && !FindUser(textBox.Text))
            {
                OpenFormAddUser();
            }
            else if (textBox.Text.Length > 0 && FindUser(textBox.Text))
            {
                HandleExistingAddUser();
            }
            else
            {
                HandleInvalidInputAddUser();
            }
        }
        // Добавление нового пользователя
        private void AddNewUser()
        {
            AddUserWithRoles(textBox.Text, passwordBoxOne.Password, ComboBoxRoles.Text);

            //ADD USER

            ResetForm();
            UpdateHintsAddUser("Добавлен новый пользователь", Brushes.Green);
        }

        // Отображение ошибки роли
        private void ShowRoleErrorAddUser()
        {
            ShowError(ComboBoxRoles, "Не выбрана роль!");

            passwordBoxOne.Foreground = Brushes.Black;
            HintAssist.SetHint(passwordBoxOne, "Введите пароль");

            //ERROR ADD USER NO ComboBoxRoles
        }

        // Отображение ошибки пароля
        private void ShowPasswordErrorAddUser()
        {
            ShowError(passwordBoxOne, "Не введен пароль!");

            ComboBoxRoles.Foreground = Brushes.Black;

            //ERROR ADD USER NO passwordBoxOne
        }

        // Отображение ошибки роли и пароля
        private void ShowRoleAndPasswordErrorAddUser()
        {
            ShowError(ComboBoxRoles, "Не выбрана роль!");
            ShowError(passwordBoxOne, "Не введен пароль!");
            //ERROR ADD USER NO ComboBoxRoles AND passwordBoxOne
        }

        // Обработка существующего пользователя
        private void HandleExistingAddUser()
        {
            ResetForm();
            UpdateHintsAddUser("Данный пользователь уже существует!", Brushes.Red);
        }

        // Обработка некорректного ввода
        private void HandleInvalidInputAddUser()
        {
            ResetForm();
            UpdateHintsAddUser("Неверно введен логин!", Brushes.Red);
        }

        // Открытие полей для заполнения
        private void OpenFormAddUser()
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

        // Обновление подсказок
        private void UpdateHintsAddUser(string textBoxHint, Brush textBoxColor)
        {
            textBox.Foreground = textBoxColor;
            HintAssist.SetHint(textBox, textBoxHint);
            HintAssist.SetHint(passwordBoxOne, "Введите пароль");
            HintAssist.SetHint(ComboBoxRoles, "Выберите роль");
        }

        // ---------------------------------------

        // Реализация кнопки изменения пользователя и обработка ошибок при вводе
        // ---------------------------------------
        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 
                && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length != 0)
            {
                ProcessEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length != 0)
            {
                ShowPasswordOneErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                ShowPasswordTwoErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                ShowRoleErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length != 0)
            {
                ShowBothPasswordsErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length == 0)
            {
                ShowPasswordTwoAndRoleErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length != 0 && ComboBoxRoles.Text.Length == 0)
            {
                ShowPasswordOneAndRoleErrorEditUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0 && ComboBoxRoles.Text.Length == 0
                && BorderPasswordBoxOne.Visibility == Visibility.Visible && BorderPasswordBoxTwo.Visibility == Visibility.Visible
                && BorderComboBoxRoles.Visibility == Visibility.Visible)
            {
                ShowAllFieldsErrorEditUser();
            }
            else if (FindUser(textBox.Text))
            {
                PrepareEditFormEditUser();
            }
            else
            {
                HandleInvalidUserEditUser();
            }
        }
        
        // Обработка изменения пользователя
        private void ProcessEditUser()
        {
            if (AuthenticateUser(textBox.Text, passwordBoxOne.Password) != null)
            {
                EditUserWithRoles(textBox.Text, passwordBoxTwo.Password, ComboBoxRoles.Text);

                //EDIT USER
                ResetForm();
                UpdateHintsEditUser("Изменения приняты", Brushes.Green);
            }
            else
            {
                UpdateRolesBasedOnUserEditUser();
                ShowError(passwordBoxOne, "Неправильный пароль!");
                ShowError(passwordBoxTwo, "Неправильный пароль!");
            }
        }

        // Отображение ошибки первого пароля
        private void ShowPasswordOneErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxOne, "Не введен пароль!");
            //ERROR EDIT USER NO passwordBoxOne
        }

        // Отображение ошибки второго пароля
        private void ShowPasswordTwoErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxTwo, "Не введен пароль!");
            //ERROR EDIT USER NO passwordBoxTwo
        }

        // Отображение ошибки роли
        private void ShowRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(ComboBoxRoles, "Не выбрана роль!");
            //ERROR EDIT USER NO ComboBoxRoles
        }

        // Отображение ошибки обоих паролей
        private void ShowBothPasswordsErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxOne, "Не введен пароль!");
            ShowError(passwordBoxTwo, "Не введен пароль!");
            //ERROR EDIT USER NO passwordBoxOne AND passwordBoxTwo
        }

        // Отображение ошибки второго пароля и роли
        private void ShowPasswordTwoAndRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxTwo, "Не введен пароль!");
            ShowError(ComboBoxRoles, "Не выбрана роль!");
            //ERROR EDIT USER NO ComboBoxRoles AND passwordBoxTwo
        }

        // Отображение ошибки первого пароля и роли
        private void ShowPasswordOneAndRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxOne, "Не введен пароль!");
            ShowError(ComboBoxRoles, "Не выбрана роль!");
            //ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne
        }

        // Отображение ошибки всех полей
        private void ShowAllFieldsErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ShowError(passwordBoxOne, "Не введен пароль!");
            ShowError(passwordBoxTwo, "Не введен пароль!");
            ShowError(ComboBoxRoles, "Не выбрана роль!");
            //ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne AND passwordBoxTwo
        }

        // Подготовка формы для редактирования
        private void PrepareEditFormEditUser()
        {
            ResetForm();
            UpdateRolesBasedOnUser(textBox.Text);

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
            HintAssist.SetHint(ComboBoxRoles, "Выберите роль");
        }

        // Обработка ошибки при отсутствии пользователя
        private void HandleInvalidUserEditUser()
        {
            ResetForm();
            UpdateHintsEditUser("Не найден логин для изменения", Brushes.Red);
        }

        // Обновление списка ролей в зависимости от пользователя
        private void UpdateRolesBasedOnUserEditUser()
        {
            UpdateRolesBasedOnUser(textBox.Text);
            UpdateHintsEditUser("Введите логин", Brushes.Black);
        }

        // Обновление подсказок
        private void UpdateHintsEditUser(string textBoxHint, Brush textBoxColor)
        {
            textBox.Foreground = textBoxColor;
            HintAssist.SetHint(textBox, textBoxHint);
            HintAssist.SetHint(passwordBoxOne, "Введите старый пароль");
            HintAssist.SetHint(passwordBoxTwo, "Введите новый пароль");
            HintAssist.SetHint(ComboBoxRoles, "Выберите роль");
        }
        // ---------------------------------------


        // Реализация кнопки удаления пользователя и обработка ошибок при вводе
        // ---------------------------------------
        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length != 0)
            {
                ProcessDeleteUser();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0 && passwordBoxTwo.Password.Length != 0)
            {
                ShowPasswordOneMissingError();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length != 0 && passwordBoxTwo.Password.Length == 0)
            {
                ShowPasswordTwoMissingError();
            }
            else if (FindUser(textBox.Text) && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0 && BorderPasswordBoxOne.Visibility == Visibility.Visible
                && BorderPasswordBoxTwo.Visibility == Visibility.Visible && BorderComboBoxRoles.Visibility != Visibility.Visible)
            {
                ShowBothPasswordsMissingError();
            }
            else if (FindUser(textBox.Text) && textBox.Text == "1")
            {
                ShowDeletionRestrictedError();
            }
            else if (FindUser(textBox.Text))
            {
                PrepareDeletionForm();
            }
            else
            {
                HandleInvalidUserForDeletion();
            }
        }

        // Обработка удаления пользователя
        private void ProcessDeleteUser()
        {
            if (AuthenticateUser(textBox.Text, passwordBoxOne.Password) != null)
            {
                HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");
                passwordBoxOne.Foreground = Brushes.Black;

                if (AuthenticateUser(textBox.Text, passwordBoxTwo.Password) != null)
                {
                    DeleteUserWithRoles(textBox.Text);

                    //DELETE USER
                    ResetForm();
                    UpdateDeletionHints("Пользователь удален", Brushes.Green);
                }
                else
                {
                    ShowPasswordInvalidError();
                }
            }
            else
            {
                ShowPasswordInvalidError();
            }
        }

        // Отображение ошибки: отсутствует первый пароль
        private void ShowPasswordOneMissingError()
        {
            passwordBoxTwo.Foreground = Brushes.Black;
            HintAssist.SetHint(passwordBoxTwo, "Повторите старый пароль пользователя");

            ShowError(passwordBoxOne, "Не введен пароль!");
            //ERROR DELETE USER NO passwordBoxOne
        }

        // Отображение ошибки: отсутствует второй пароль
        private void ShowPasswordTwoMissingError()
        {
            passwordBoxOne.Foreground = Brushes.Black;
            HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");

            ShowError(passwordBoxTwo, "Не введен пароль!");
            //ERROR DELETE USER NO passwordBoxTwo
        }

        // Отображение ошибки: отсутствуют оба пароля
        private void ShowBothPasswordsMissingError()
        {
            ShowError(passwordBoxOne, "Не введен пароль!");
            ShowError(passwordBoxTwo, "Не введен пароль!");
            //ERROR DELETE USER NO passwordBoxOne AND passwordBoxTwo
        }

        // Отображение ошибки: удаление недоступно
        private void ShowDeletionRestrictedError()
        {
            ResetForm();
            ShowError(textBox, "Данный логин недоступен к удалению!");
        }

        // Подготовка формы для удаления
        private void PrepareDeletionForm()
        {
            ResetForm();

            BorderPasswordBoxTwo.Visibility = Visibility.Visible;
            BorderPasswordBoxOne.Visibility = Visibility.Visible;
            BorderComboBoxRoles.Visibility = Visibility.Hidden;

            textBox.Foreground = Brushes.Black;
            passwordBoxOne.Foreground = Brushes.Black;
            passwordBoxTwo.Foreground = Brushes.Black;

            UpdateDeletionHints("Введите логин", Brushes.Black);
        }

        // Обработка случая, когда пользователь не найден
        private void HandleInvalidUserForDeletion()
        {
            ResetForm();
            ShowError(textBox, "Не найден логин для удаления!");
        }

        // Отображение ошибки: неправильный первый пароль
        private void ShowPasswordInvalidError()
        {
            ShowError(passwordBoxOne, "Неверный пароль!");
            ShowError(passwordBoxTwo, "Неверный пароль!");
        }

        // Обновление подсказок для удаления
        private void UpdateDeletionHints(string textBoxHint, Brush textBoxColor)
        {
            textBox.Foreground = textBoxColor;
            HintAssist.SetHint(textBox, textBoxHint);
            HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");
            HintAssist.SetHint(passwordBoxTwo, "Повторите старый пароль пользователя");
        }
        // ---------------------------------------

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
