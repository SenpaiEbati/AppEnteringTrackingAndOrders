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

        // Реализация кнопки добавление нового пользователя и обработка ошибок при вводе
        // ---------------------------------------
        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (IsInputValidAddUser())
            {
                AddNewUser();
            }
            else if (IsRoleMissingAddUser())
            {
                ShowRoleErrorAddUser();
            }
            else if (IsPasswordMissingAddUser())
            {
                ShowPasswordErrorAddUser();
            }
            else if (IsRoleAndPasswordMissingAddUser())
            {
                ShowRoleAndPasswordErrorAddUser();
            }
            else if (IsUserNoExistsAddUser())
            {
                OpenFormAddUser();
            }
            else if (IsUserExistsAddUser())
            {
                HandleExistingAddUser();
            }
            else
            {
                HandleInvalidInputAddUser();
            }
        }

        // Проверка валидности ввода
        private bool IsInputValidAddUser()
        {
            return textBox.Text.Length > 0 
                && !FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Проверка на отсутствие роли
        private bool IsRoleMissingAddUser()
        {
            return textBox.Text.Length > 0
                && !FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && ComboBoxRoles.Text.Length == 0;
        }

        // Проверка на отсутствие пароля
        private bool IsPasswordMissingAddUser()
        {
            return textBox.Text.Length > 0
                && !FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Проверка на отсутствие роли и пароля
        private bool IsRoleAndPasswordMissingAddUser()
        {
            return textBox.Text.Length > 0
                && !FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && BorderPasswordBoxOne.Visibility == Visibility.Visible
                && ComboBoxRoles.Text.Length == 0
                && BorderComboBoxRoles.Visibility == Visibility.Visible
                && BorderPasswordBoxTwo.Visibility != Visibility.Visible;
        }

        // Проверка на существование пользователя
        private bool IsUserExistsAddUser()
        {
            return textBox.Text.Length > 0
                && FindUser(textBox.Text);
        }

        private bool IsUserNoExistsAddUser()
        {
            return textBox.Text.Length > 0
                && !FindUser(textBox.Text);
        }

        // Добавление нового пользователя
        private void AddNewUser()
        {
            AddUserWithRoles(textBox.Text, passwordBoxOne.Password, ComboBoxRoles.Text);

            MessageBox.Show("ADD USER");

            ResetFormAddUser();
            UpdateHintsAddUser("Добавлен новый пользователь", Brushes.Green);
        }

        // Отображение ошибки роли
        private void ShowRoleErrorAddUser()
        {
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            MessageBox.Show("ERROR ADD USER NO ComboBoxRoles");
        }

        // Отображение ошибки пароля
        private void ShowPasswordErrorAddUser()
        {
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            MessageBox.Show("ERROR ADD USER NO passwordBoxOne");
        }

        // Отображение ошибки роли и пароля
        private void ShowRoleAndPasswordErrorAddUser()
        {
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            MessageBox.Show("ERROR ADD USER NO ComboBoxRoles AND passwordBoxOne");
        }

        // Обработка существующего пользователя
        private void HandleExistingAddUser()
        {
            ResetFormAddUser();
            UpdateHintsAddUser("Данный пользователь уже существует!", Brushes.Red);
        }

        // Обработка некорректного ввода
        private void HandleInvalidInputAddUser()
        {
            ResetFormAddUser();
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

        // Сброс формы
        private void ResetFormAddUser()
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
            if (IsInputValidForEditUser())
            {
                ProcessEditUser();
            }
            else if (IsPasswordOneMissingEditUser())
            {
                ShowPasswordOneErrorEditUser();
            }
            else if (IsPasswordTwoMissingEditUser())
            {
                ShowPasswordTwoErrorEditUser();
            }
            else if (IsRoleMissingEditUser())
            {
                ShowRoleErrorEditUser();
            }
            else if (AreBothPasswordsMissingEditUser())
            {
                ShowBothPasswordsErrorEditUser();
            }
            else if (ArePasswordTwoAndRoleMissingEditUser())
            {
                ShowPasswordTwoAndRoleErrorEditUser();
            }
            else if (ArePasswordOneAndRoleMissingEditUser())
            {
                ShowPasswordOneAndRoleErrorEditUser();
            }
            else if (AreAllFieldsMissingEditUser())
            {
                ShowAllFieldsErrorEditUser();
            }
            else if (IsUserFoundEditUser())
            {
                PrepareEditFormEditUser();
            }
            else
            {
                HandleInvalidUserEditUser();
            }
        }

        // Проверка валидности данных для редактирования
        private bool IsInputValidForEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length != 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Обработка изменения пользователя
        private void ProcessEditUser()
        {
            if (AuthenticateUser(textBox.Text, passwordBoxOne.Password) != null)
            {
                EditUserWithRoles(textBox.Text, passwordBoxTwo.Password, ComboBoxRoles.Text);

                MessageBox.Show("EDIT USER");
                ResetFormEditUser();
                UpdateHintsEditUser("Изменения приняты", Brushes.Green);
            }
            else
            {
                UpdateRolesBasedOnUserEditUser();
                passwordBoxOne.Foreground = Brushes.Red;
                HintAssist.SetHint(passwordBoxOne, "Неправильный пароль!");
            }
        }

        // Проверка на отсутствие первого пароля
        private bool IsPasswordOneMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length != 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Проверка на отсутствие второго пароля
        private bool IsPasswordTwoMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length == 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Проверка на отсутствие роли
        private bool IsRoleMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length != 0
                && ComboBoxRoles.Text.Length == 0;
        }

        // Проверка на отсутствие обоих паролей
        private bool AreBothPasswordsMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0
                && ComboBoxRoles.Text.Length != 0;
        }

        // Проверка на отсутствие второго пароля и роли
        private bool ArePasswordTwoAndRoleMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length == 0
                && ComboBoxRoles.Text.Length == 0;
        }

        // Проверка на отсутствие первого пароля и роли
        private bool ArePasswordOneAndRoleMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length != 0
                && ComboBoxRoles.Text.Length == 0;
        }

        // Проверка на отсутствие всех полей
        private bool AreAllFieldsMissingEditUser()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0
                && ComboBoxRoles.Text.Length == 0
                && BorderPasswordBoxOne.Visibility == Visibility.Visible
                && BorderPasswordBoxTwo.Visibility == Visibility.Visible
                && BorderComboBoxRoles.Visibility == Visibility.Visible;
        }

        // Проверка, найден ли пользователь
        private bool IsUserFoundEditUser()
        {
            return FindUser(textBox.Text);
        }

        // Отображение ошибки первого пароля
        private void ShowPasswordOneErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            MessageBox.Show("ERROR EDIT USER NO passwordBoxOne");
        }

        // Отображение ошибки второго пароля
        private void ShowPasswordTwoErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            MessageBox.Show("ERROR EDIT USER NO passwordBoxTwo");
        }

        // Отображение ошибки роли
        private void ShowRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles");
        }

        // Отображение ошибки обоих паролей
        private void ShowBothPasswordsErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            MessageBox.Show("ERROR EDIT USER NO passwordBoxOne AND passwordBoxTwo");
        }

        // Отображение ошибки второго пароля и роли
        private void ShowPasswordTwoAndRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxTwo");
        }

        // Отображение ошибки первого пароля и роли
        private void ShowPasswordOneAndRoleErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne");
        }

        // Отображение ошибки всех полей
        private void ShowAllFieldsErrorEditUser()
        {
            UpdateRolesBasedOnUserEditUser();
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            ComboBoxRoles.Foreground = Brushes.Red;
            HintAssist.SetHint(ComboBoxRoles, "Не выбрана роль!");
            MessageBox.Show("ERROR EDIT USER NO ComboBoxRoles AND passwordBoxOne AND passwordBoxTwo");
        }

        // Подготовка формы для редактирования
        private void PrepareEditFormEditUser()
        {
            ResetFormEditUser();

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

        // Обработка ошибки при отсутствии пользователя
        private void HandleInvalidUserEditUser()
        {
            ResetFormEditUser();
            UpdateHintsEditUser("Не найден логин для изменения", Brushes.Red);
        }

        // Обновление списка ролей в зависимости от пользователя
        private void UpdateRolesBasedOnUserEditUser()
        {
            if (textBox.Text == "1")
                ComboBoxRoles.ItemsSource = _rolesbuttonchangeadmin;
            else
                ComboBoxRoles.ItemsSource = _rolesbuttonadd;

            UpdateHintsEditUser("Введите логин", Brushes.Black);
        }

        // Сброс формы
        private void ResetFormEditUser()
        {
            passwordBoxOne.Password = "";
            passwordBoxTwo.Password = "";
            ComboBoxRoles.Text = "";

            BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
            BorderPasswordBoxOne.Visibility = Visibility.Hidden;
            BorderComboBoxRoles.Visibility = Visibility.Hidden;

            textBox.Foreground = Brushes.Black;
            passwordBoxOne.Foreground = Brushes.Black;
            passwordBoxTwo.Foreground = Brushes.Black;
            ComboBoxRoles.Foreground = Brushes.Black;
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
            if (IsInputValidForDeletion())
            {
                ProcessDeleteUser();
            }
            else if (IsPasswordOneMissingForDeletion())
            {
                ShowPasswordOneMissingError();
            }
            else if (IsPasswordTwoMissingForDeletion())
            {
                ShowPasswordTwoMissingError();
            }
            else if (AreBothPasswordsMissingForDeletion())
            {
                ShowBothPasswordsMissingError();
            }
            else if (IsDeletionRestricted())
            {
                ShowDeletionRestrictedError();
            }
            else if (IsUserFoundForDeletion())
            {
                PrepareDeletionForm();
            }
            else
            {
                HandleInvalidUserForDeletion();
            }
        }

        // Проверка валидности ввода для удаления
        private bool IsInputValidForDeletion()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length != 0;
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

                    MessageBox.Show("DELETE USER");
                    ResetDeletionForm();
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

        // Проверка на отсутствие первого пароля
        private bool IsPasswordOneMissingForDeletion()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length != 0;
        }

        // Проверка на отсутствие второго пароля
        private bool IsPasswordTwoMissingForDeletion()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length != 0
                && passwordBoxTwo.Password.Length == 0;
        }

        // Проверка на отсутствие обоих паролей
        private bool AreBothPasswordsMissingForDeletion()
        {
            return FindUser(textBox.Text)
                && passwordBoxOne.Password.Length == 0
                && passwordBoxTwo.Password.Length == 0
                && BorderPasswordBoxOne.Visibility == Visibility.Visible
                && BorderPasswordBoxTwo.Visibility == Visibility.Visible
                && BorderComboBoxRoles.Visibility != Visibility.Visible;
        }

        // Проверка на ограничения удаления
        private bool IsDeletionRestricted()
        {
            return FindUser(textBox.Text) && textBox.Text == "1";
        }

        // Проверка, найден ли пользователь
        private bool IsUserFoundForDeletion()
        {
            return FindUser(textBox.Text);
        }

        // Отображение ошибки: отсутствует первый пароль
        private void ShowPasswordOneMissingError()
        {
            passwordBoxTwo.Foreground = Brushes.Black;
            HintAssist.SetHint(passwordBoxTwo, "Повторите старый пароль пользователя");

            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            MessageBox.Show("ERROR DELETE USER NO passwordBoxOne");
        }

        // Отображение ошибки: отсутствует второй пароль
        private void ShowPasswordTwoMissingError()
        {
            passwordBoxOne.Foreground = Brushes.Black;
            HintAssist.SetHint(passwordBoxOne, "Введите старый пароль пользователя");

            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            MessageBox.Show("ERROR DELETE USER NO passwordBoxTwo");
        }

        // Отображение ошибки: отсутствуют оба пароля
        private void ShowBothPasswordsMissingError()
        {
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Не введен пароль!");
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Не введен пароль!");
            MessageBox.Show("ERROR DELETE USER NO passwordBoxOne AND passwordBoxTwo");
        }

        // Отображение ошибки: удаление недоступно
        private void ShowDeletionRestrictedError()
        {
            ResetDeletionForm();
            textBox.Foreground = Brushes.Red;
            HintAssist.SetHint(textBox, "Данный логин недоступен к удалению!");
        }

        // Подготовка формы для удаления
        private void PrepareDeletionForm()
        {
            ResetDeletionForm();

            ComboBoxRoles.ItemsSource = _rolesbuttonadd;

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
            ResetDeletionForm();
            textBox.Foreground = Brushes.Red;
            HintAssist.SetHint(textBox, "Не найден логин для удаления!");
        }

        // Отображение ошибки: неправильный первый пароль
        private void ShowPasswordInvalidError()
        {
            passwordBoxOne.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxOne, "Неверный пароль!");
            passwordBoxTwo.Foreground = Brushes.Red;
            HintAssist.SetHint(passwordBoxTwo, "Неверный пароль!");
        }

        // Сброс формы
        private void ResetDeletionForm()
        {
            passwordBoxOne.Password = "";
            passwordBoxTwo.Password = "";
            ComboBoxRoles.Text = "";

            BorderPasswordBoxTwo.Visibility = Visibility.Hidden;
            BorderPasswordBoxOne.Visibility = Visibility.Hidden;
            BorderComboBoxRoles.Visibility = Visibility.Hidden;

            textBox.Foreground = Brushes.Black;
            passwordBoxOne.Foreground = Brushes.Black;
            passwordBoxTwo.Foreground = Brushes.Black;
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
