using MaterialDesignThemes.Wpf;
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

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для AddMenuItemPage.xaml
    /// </summary>
    public partial class AddMenuItemPage : Page
    {
        private bool _langRuENKey = false;
        private bool _shiftKey = false;

        private Group _group;

        public AddMenuItemPage(Group group)
        {
            _group = group;
            InitializeComponent();
            List<string> location = new List<string> { "Кухня", "Бар" };
            ComboBoxItemKitchOrBar.ItemsSource = location;
        }

        private void BackOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Клавиатура с цифрами
        // ---------------------------------------
        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "1";
                TextBoxNameItem.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "2";
                TextBoxNameItem.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "3";
                TextBoxNameItem.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "4";
                TextBoxNameItem.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "5";
                TextBoxNameItem.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "6";
                TextBoxNameItem.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "7";
                TextBoxNameItem.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "8";
                TextBoxNameItem.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "9";
                TextBoxNameItem.Focus();
            }
        }

        private void TopButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (TextBoxNameItem.Text.Length > 0)
                    TextBoxNameItem.Text = TextBoxNameItem.Text.Substring(0, TextBoxNameItem.Text.Length - 1);
                TextBoxNameItem.Focus();
            }
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += "0";
                TextBoxNameItem.Focus();
            }
        }

        private void DownButtonKeyboard_Click(object sender, RoutedEventArgs e)
        {
            KeyboardNumber.Visibility = Visibility.Hidden;
            KeyboardAbc.Visibility = Visibility.Visible;
            GridCenter.ColumnDefinitions.Clear();
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(313, GridUnitType.Star) });
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(590, GridUnitType.Star) });

            if (WindowHeight < 1080 || WindowWidth < 1920)
            {
                SizeKeyboardButtonSmall();
            }
            else
            {
                SizeKeyboardButtonBig();
            }
        }
        // ---------------------------------------

        // Клавиатура с буквами
        // ---------------------------------------
        private void Button123_Click(object sender, RoutedEventArgs e)
        {
            KeyboardAbc.Visibility = Visibility.Hidden;
            KeyboardNumber.Visibility = Visibility.Visible;
            GridCenter.ColumnDefinitions.Clear();
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(236, GridUnitType.Star) });
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
            GridCenter.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(237, GridUnitType.Star) });

        }

        private void ButtonQ_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "й" : "Й";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "q" : "Q";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonW_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ц" : "Ц";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "w" : "W";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonE_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "у" : "У";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "e" : "E";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonR_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "к" : "К";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "r" : "R";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonT_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "е" : "Е";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "t" : "T";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonY_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "н" : "Н";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "y" : "Y";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonU_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "г" : "Г";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "u" : "U";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonI_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ш" : "Ш";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "i" : "I";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonO_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "щ" : "Щ";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "o" : "O";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonP_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "з" : "З";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "p" : "P";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "х" : "Х";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "[" : "{";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ъ" : "Ъ";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "]" : "}";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ф" : "Ф";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "a" : "A";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ы" : "Ы";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "s" : "S";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "в" : "В";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "d" : "D";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonF_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "а" : "А";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "f" : "F";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonG_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "п" : "П";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "g" : "G";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonH_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "р" : "Р";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "h" : "H";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonJ_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "о" : "О";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "j" : "J";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonK_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "л" : "Л";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "k" : "K";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonL_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "д" : "Д";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "l" : "L";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button22_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ж" : "Ж";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? ";" : ":";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button23_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "э" : "Э";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "'" : "\"";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonShift_Click(object sender, RoutedEventArgs e)
        {
            if (_shiftKey == false)
            {
                _shiftKey = true;

                ButtonQ.Content = _langRuENKey == true ? "Q" : "Й";
                ButtonW.Content = _langRuENKey == true ? "W" : "Ц";
                ButtonE.Content = _langRuENKey == true ? "E" : "У";
                ButtonR.Content = _langRuENKey == true ? "R" : "К";
                ButtonT.Content = _langRuENKey == true ? "T" : "Е";
                ButtonY.Content = _langRuENKey == true ? "Y" : "Н";
                ButtonU.Content = _langRuENKey == true ? "U" : "Г";
                ButtonI.Content = _langRuENKey == true ? "I" : "Ш";
                ButtonO.Content = _langRuENKey == true ? "O" : "Щ";
                ButtonP.Content = _langRuENKey == true ? "P" : "З";
                Button11.Content = _langRuENKey == true ? "{" : "Х";
                Button12.Content = _langRuENKey == true ? "}" : "Ъ";

                ButtonA.Content = _langRuENKey == true ? "A" : "Ф";
                ButtonS.Content = _langRuENKey == true ? "S" : "Ы";
                ButtonD.Content = _langRuENKey == true ? "D" : "В";
                ButtonF.Content = _langRuENKey == true ? "F" : "А";
                ButtonG.Content = _langRuENKey == true ? "G" : "П";
                ButtonH.Content = _langRuENKey == true ? "H" : "Р";
                ButtonJ.Content = _langRuENKey == true ? "J" : "О";
                ButtonK.Content = _langRuENKey == true ? "K" : "Л";
                ButtonL.Content = _langRuENKey == true ? "L" : "Д";
                Button22.Content = _langRuENKey == true ? ":" : "Ж";
                Button23.Content = _langRuENKey == true ? "\"" : "Э";

                ButtonZ.Content = _langRuENKey == true ? "Z" : "Я";
                ButtonX.Content = _langRuENKey == true ? "X" : "Ч";
                ButtonC.Content = _langRuENKey == true ? "C" : "С";
                ButtonV.Content = _langRuENKey == true ? "V" : "М";
                ButtonB.Content = _langRuENKey == true ? "B" : "И";
                ButtonN.Content = _langRuENKey == true ? "N" : "Т";
                ButtonM.Content = _langRuENKey == true ? "M" : "Ь";
                Button32.Content = _langRuENKey == true ? "<" : "Б";
                Button33.Content = _langRuENKey == true ? ">" : "Ю";
            }
            else if (_shiftKey == true)
            {
                _shiftKey = false;

                ButtonQ.Content = _langRuENKey == true ? "q" : "й";
                ButtonW.Content = _langRuENKey == true ? "w" : "ц";
                ButtonE.Content = _langRuENKey == true ? "e" : "у";
                ButtonR.Content = _langRuENKey == true ? "r" : "к";
                ButtonT.Content = _langRuENKey == true ? "t" : "е";
                ButtonY.Content = _langRuENKey == true ? "y" : "н";
                ButtonU.Content = _langRuENKey == true ? "u" : "г";
                ButtonI.Content = _langRuENKey == true ? "i" : "ш";
                ButtonO.Content = _langRuENKey == true ? "o" : "щ";
                ButtonP.Content = _langRuENKey == true ? "p" : "з";
                Button11.Content = _langRuENKey == true ? "[" : "х";
                Button12.Content = _langRuENKey == true ? "]" : "ъ";

                ButtonA.Content = _langRuENKey == true ? "a" : "ф";
                ButtonS.Content = _langRuENKey == true ? "s" : "ы";
                ButtonD.Content = _langRuENKey == true ? "d" : "в";
                ButtonF.Content = _langRuENKey == true ? "f" : "а";
                ButtonG.Content = _langRuENKey == true ? "g" : "п";
                ButtonH.Content = _langRuENKey == true ? "h" : "р";
                ButtonJ.Content = _langRuENKey == true ? "q" : "о";
                ButtonK.Content = _langRuENKey == true ? "q" : "л";
                ButtonL.Content = _langRuENKey == true ? "q" : "д";
                Button22.Content = _langRuENKey == true ? ";" : "ж";
                Button23.Content = _langRuENKey == true ? "'" : "э";

                ButtonZ.Content = _langRuENKey == true ? "z" : "я";
                ButtonX.Content = _langRuENKey == true ? "x" : "ч";
                ButtonC.Content = _langRuENKey == true ? "c" : "с";
                ButtonV.Content = _langRuENKey == true ? "v" : "м";
                ButtonB.Content = _langRuENKey == true ? "b" : "и";
                ButtonN.Content = _langRuENKey == true ? "n" : "т";
                ButtonM.Content = _langRuENKey == true ? "m" : "ь";
                Button32.Content = _langRuENKey == true ? "<" : "б";
                Button33.Content = _langRuENKey == true ? ">" : "ю";
            }
        }

        private void ButtonZ_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "я" : "Я";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "z" : "Z";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ч" : "Ч";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "x" : "X";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "с" : "С";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "c" : "C";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonV_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "м" : "М";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "v" : "V";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "и" : "И";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "b" : "B";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonN_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "т" : "Т";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "n" : "N";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonM_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ь" : "Ь";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "m" : "M";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button32_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "б" : "Б";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "<" : "<";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void Button33_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    TextBoxNameItem.Text += _shiftKey == false ? "ю" : "Ю";
                }
                else
                {
                    TextBoxNameItem.Text += _shiftKey == false ? ">" : ">";
                }
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonLang_Click(object sender, RoutedEventArgs e)
        {
            if (_langRuENKey == false)
            {
                _langRuENKey = true;
                ButtonQ.Content = _shiftKey == false ? "q" : "Q";
                ButtonW.Content = _shiftKey == false ? "w" : "W";
                ButtonE.Content = _shiftKey == false ? "e" : "E";
                ButtonR.Content = _shiftKey == false ? "r" : "R";
                ButtonT.Content = _shiftKey == false ? "t" : "T";
                ButtonY.Content = _shiftKey == false ? "y" : "Y";
                ButtonU.Content = _shiftKey == false ? "u" : "U";
                ButtonI.Content = _shiftKey == false ? "i" : "I";
                ButtonO.Content = _shiftKey == false ? "o" : "O";
                ButtonP.Content = _shiftKey == false ? "p" : "P";
                Button11.Content = _shiftKey == false ? "[" : "{";
                Button12.Content = _shiftKey == false ? "]" : "}";

                ButtonA.Content = _shiftKey == false ? "a" : "A";
                ButtonS.Content = _shiftKey == false ? "s" : "S";
                ButtonD.Content = _shiftKey == false ? "d" : "D";
                ButtonF.Content = _shiftKey == false ? "f" : "F";
                ButtonG.Content = _shiftKey == false ? "g" : "G";
                ButtonH.Content = _shiftKey == false ? "h" : "H";
                ButtonJ.Content = _shiftKey == false ? "q" : "J";
                ButtonK.Content = _shiftKey == false ? "q" : "K";
                ButtonL.Content = _shiftKey == false ? "q" : "L";
                Button22.Content = _shiftKey == false ? ";" : ":";
                Button23.Content = _shiftKey == false ? "'" : "\"";

                ButtonZ.Content = _shiftKey == false ? "z" : "Z";
                ButtonX.Content = _shiftKey == false ? "x" : "X";
                ButtonC.Content = _shiftKey == false ? "c" : "C";
                ButtonV.Content = _shiftKey == false ? "v" : "V";
                ButtonB.Content = _shiftKey == false ? "b" : "B";
                ButtonN.Content = _shiftKey == false ? "n" : "N";
                ButtonM.Content = _shiftKey == false ? "m" : "M";
                Button32.Content = _shiftKey == false ? "<" : "<";
                Button33.Content = _shiftKey == false ? ">" : ">";
            }
            else if (_langRuENKey == true)
            {
                _langRuENKey = false;
                ButtonQ.Content = _shiftKey == false ? "й" : "Й";
                ButtonW.Content = _shiftKey == false ? "ц" : "Ц";
                ButtonE.Content = _shiftKey == false ? "у" : "У";
                ButtonR.Content = _shiftKey == false ? "к" : "К";
                ButtonT.Content = _shiftKey == false ? "е" : "Е";
                ButtonY.Content = _shiftKey == false ? "н" : "Н";
                ButtonU.Content = _shiftKey == false ? "г" : "Г";
                ButtonI.Content = _shiftKey == false ? "ш" : "Ш";
                ButtonO.Content = _shiftKey == false ? "щ" : "Щ";
                ButtonP.Content = _shiftKey == false ? "з" : "З";
                Button11.Content = _shiftKey == false ? "х" : "Х";
                Button12.Content = _shiftKey == false ? "ъ" : "Ъ";

                ButtonA.Content = _shiftKey == false ? "ф" : "Ф";
                ButtonS.Content = _shiftKey == false ? "ы" : "Ы";
                ButtonD.Content = _shiftKey == false ? "в" : "В";
                ButtonF.Content = _shiftKey == false ? "а" : "А";
                ButtonG.Content = _shiftKey == false ? "п" : "П";
                ButtonH.Content = _shiftKey == false ? "р" : "Р";
                ButtonJ.Content = _shiftKey == false ? "о" : "О";
                ButtonK.Content = _shiftKey == false ? "л" : "Л";
                ButtonL.Content = _shiftKey == false ? "д" : "Д";
                Button22.Content = _shiftKey == false ? "ж" : "Ж";
                Button23.Content = _shiftKey == false ? "э" : "Э";

                ButtonZ.Content = _shiftKey == false ? "я" : "Я";
                ButtonX.Content = _shiftKey == false ? "ч" : "Ч";
                ButtonC.Content = _shiftKey == false ? "с" : "С";
                ButtonV.Content = _shiftKey == false ? "м" : "М";
                ButtonB.Content = _shiftKey == false ? "и" : "И";
                ButtonN.Content = _shiftKey == false ? "т" : "Т";
                ButtonM.Content = _shiftKey == false ? "ь" : "Ь";
                Button32.Content = _shiftKey == false ? "б" : "Б";
                Button33.Content = _shiftKey == false ? "ю" : "Ю";
            }

        }

        private void ButtonSpace_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += " ";
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += ",";
                TextBoxNameItem.Focus();
            }
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameItem.IsKeyboardFocused)
            {
                TextBoxNameItem.Text += ".";
                TextBoxNameItem.Focus();
            }
        }

        // ---------------------------------------

        private void SizeKeyboardButtonBig()
        {
            int sizebutton = 90;

            int i = 0;
            ButtonQ.Width = ButtonQ.Height = sizebutton; i += 1;
            ButtonW.Width = ButtonW.Height = sizebutton; ButtonW.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonE.Width = ButtonE.Height = sizebutton; ButtonE.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonR.Width = ButtonR.Height = sizebutton; ButtonR.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonT.Width = ButtonT.Height = sizebutton; ButtonT.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonY.Width = ButtonY.Height = sizebutton; ButtonY.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonU.Width = ButtonU.Height = sizebutton; ButtonU.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonI.Width = ButtonI.Height = sizebutton; ButtonI.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonO.Width = ButtonO.Height = sizebutton; ButtonO.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonP.Width = ButtonP.Height = sizebutton; ButtonP.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            Button11.Width = Button11.Height = sizebutton; Button11.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            Button12.Width = Button12.Height = sizebutton; Button12.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0);

            i = 0;
            ButtonA.Width = ButtonA.Height = sizebutton; ButtonA.Margin = new Thickness(45, sizebutton + 5, 0, 0); i += 1;
            ButtonS.Width = ButtonS.Height = sizebutton; ButtonS.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonD.Width = ButtonD.Height = sizebutton; ButtonD.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonF.Width = ButtonF.Height = sizebutton; ButtonF.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonG.Width = ButtonG.Height = sizebutton; ButtonG.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonH.Width = ButtonH.Height = sizebutton; ButtonH.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonJ.Width = ButtonJ.Height = sizebutton; ButtonJ.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonK.Width = ButtonK.Height = sizebutton; ButtonK.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            ButtonL.Width = ButtonL.Height = sizebutton; ButtonL.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            Button22.Width = Button22.Height = sizebutton; Button22.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0); i += 1;
            Button23.Width = Button23.Height = sizebutton; Button23.Margin = new Thickness(45 + 5 * i + sizebutton * i, sizebutton + 5, 0, 0);

            i = 0;
            ButtonShift.Width = ButtonShift.Height = sizebutton; ButtonShift.Margin = new Thickness(0, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonZ.Width = ButtonZ.Height = sizebutton; ButtonZ.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonX.Width = ButtonX.Height = sizebutton; ButtonX.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonC.Width = ButtonC.Height = sizebutton; ButtonC.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonV.Width = ButtonV.Height = sizebutton; ButtonV.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonB.Width = ButtonB.Height = sizebutton; ButtonB.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonN.Width = ButtonN.Height = sizebutton; ButtonN.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonM.Width = ButtonM.Height = sizebutton; ButtonM.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            Button32.Width = Button32.Height = sizebutton; Button32.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            Button33.Width = Button33.Height = sizebutton; Button33.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0); i += 1;
            ButtonBackSpace.Width = 145; ButtonBackSpace.Height = sizebutton; ButtonBackSpace.Margin = new Thickness(5 * i + sizebutton * i, (sizebutton + 5) * 2, 0, 0);

            Button123.Width = 140; Button123.Height = sizebutton; Button123.Margin = new Thickness(0, (sizebutton + 5) * 3, 0, 0);
            ButtonLang.Width = ButtonLang.Height = sizebutton; ButtonLang.Margin = new Thickness(145, (sizebutton + 5) * 3, 0, 0);
            ButtonSpace.Width = 705; ButtonSpace.Height = sizebutton; ButtonSpace.Margin = new Thickness(240, (sizebutton + 5) * 3, 0, 0);
            ButtonComma.Width = ButtonComma.Height = sizebutton; ButtonComma.Margin = new Thickness(950, (sizebutton + 5) * 3, 0, 0);
            ButtonPoint.Width = ButtonPoint.Height = sizebutton; ButtonPoint.Margin = new Thickness(1045, (sizebutton + 5) * 3, 0, 0);

            KeyboardAbc.Width = 1140; KeyboardAbc.Height = 378;
            BorderTextBoxNameItem.Width = 598; TextBoxNameItem.Margin = new Thickness(39, 3, 39, 3);
        }

        private void SizeKeyboardButtonSmall()
        {
            int sizebutton = 70;

            int i = 0;
            ButtonQ.Width = ButtonQ.Height = sizebutton; i += 1;
            ButtonW.Width = ButtonW.Height = sizebutton; ButtonW.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonE.Width = ButtonE.Height = sizebutton; ButtonE.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonR.Width = ButtonR.Height = sizebutton; ButtonR.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonT.Width = ButtonT.Height = sizebutton; ButtonT.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonY.Width = ButtonY.Height = sizebutton; ButtonY.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonU.Width = ButtonU.Height = sizebutton; ButtonU.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonI.Width = ButtonI.Height = sizebutton; ButtonI.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonO.Width = ButtonO.Height = sizebutton; ButtonO.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            ButtonP.Width = ButtonP.Height = sizebutton; ButtonP.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            Button11.Width = Button11.Height = sizebutton; Button11.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0); i += 1;
            Button12.Width = Button12.Height = sizebutton; Button12.Margin = new Thickness(5 * i + sizebutton * i, 0, 0, 0);

            i = 0;
            ButtonA.Width = ButtonA.Height = sizebutton; ButtonA.Margin = new Thickness(45, 75, 0, 0); i += 1;
            ButtonS.Width = ButtonS.Height = sizebutton; ButtonS.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonD.Width = ButtonD.Height = sizebutton; ButtonD.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonF.Width = ButtonF.Height = sizebutton; ButtonF.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonG.Width = ButtonG.Height = sizebutton; ButtonG.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonH.Width = ButtonH.Height = sizebutton; ButtonH.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonJ.Width = ButtonJ.Height = sizebutton; ButtonJ.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonK.Width = ButtonK.Height = sizebutton; ButtonK.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            ButtonL.Width = ButtonL.Height = sizebutton; ButtonL.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            Button22.Width = Button22.Height = sizebutton; Button22.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0); i += 1;
            Button23.Width = Button23.Height = sizebutton; Button23.Margin = new Thickness(45 + 5 * i + sizebutton * i, 75, 0, 0);

            i = 0;
            ButtonShift.Width = ButtonShift.Height = sizebutton; ButtonShift.Margin = new Thickness(0, 150, 0, 0); i += 1;
            ButtonZ.Width = ButtonZ.Height = sizebutton; ButtonZ.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonX.Width = ButtonX.Height = sizebutton; ButtonX.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonC.Width = ButtonC.Height = sizebutton; ButtonC.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonV.Width = ButtonV.Height = sizebutton; ButtonV.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonB.Width = ButtonB.Height = sizebutton; ButtonB.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonN.Width = ButtonN.Height = sizebutton; ButtonN.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonM.Width = ButtonM.Height = sizebutton; ButtonM.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            Button32.Width = Button32.Height = sizebutton; Button32.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            Button33.Width = Button33.Height = sizebutton; Button33.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0); i += 1;
            ButtonBackSpace.Width = 145; ButtonBackSpace.Height = sizebutton; ButtonBackSpace.Margin = new Thickness(5 * i + sizebutton * i, 150, 0, 0);

            Button123.Width = 110; Button123.Height = sizebutton; Button123.Margin = new Thickness(0, 225, 0, 0);
            ButtonLang.Width = ButtonLang.Height = sizebutton; ButtonLang.Margin = new Thickness(115, 225, 0, 0);
            ButtonSpace.Width = 550; ButtonSpace.Height = sizebutton; ButtonSpace.Margin = new Thickness(190, 225, 0, 0);
            ButtonComma.Width = ButtonComma.Height = sizebutton; ButtonComma.Margin = new Thickness(750, 225, 0, 0);
            ButtonPoint.Width = ButtonPoint.Height = sizebutton; ButtonPoint.Margin = new Thickness(825, 225, 0, 0);

            KeyboardAbc.Width = 900; KeyboardAbc.Height = 296;
            BorderTextBoxNameItem.Width = 448; TextBoxNameItem.Margin = new Thickness(39, 3, 39, 3);
        }

        private void SaveItemButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
                var menu = context.Menus.FirstOrDefault();
                if (menu != null)
                {
                    if (string.IsNullOrWhiteSpace(TextBoxNameItem.Text))
                    {
                        ShowError(TextBoxNameItem, "Некорректное название");
                    }
                    else if (string.IsNullOrWhiteSpace(TextBoxDescItem.Text))
                    {
                        ShowError(TextBoxDescItem, "Некорректное описание");
                    }
                    else if (DecimalPriceItem.Value != Math.Round(DecimalPriceItem.Value,2))
                    {
                        ShowError(DecimalPriceItem, "Уменьшете разрядность цены до 0.00");
                    }
                    else if (string.IsNullOrWhiteSpace(ComboBoxItemKitchOrBar.Text))
                    {
                        ShowError(ComboBoxItemKitchOrBar, "Выберите место приготовления");
                    }
                    else 
                    {
                        // Присоединяем Group к контексту
                        context.Attach(_group);

                        var item = new MenuItem
                        {
                            Name = Convert.ToString(TextBoxNameItem.Text),
                            Description = Convert.ToString(TextBoxDescItem.Text),
                            Price = Convert.ToDecimal(Math.Round(DecimalPriceItem.Value,2)),
                            Destination = Convert.ToString(ComboBoxItemKitchOrBar.Text),
                            GroupId = _group.Id,
                        };
                        context.MenuItems.Add(item);
                        context.SaveChanges();
                        NavigationService.GoBack();
                    }
                }
            }
        }

        private void ShowError(Control control, string hintMessage)
        {
            if (control == TextBoxNameItem) TextBoxNameItem.Foreground = Brushes.Red;
            if (control == TextBoxDescItem) TextBoxDescItem.Foreground = Brushes.Red;
            if (control == DecimalPriceItem) DecimalPriceItem.Foreground = Brushes.Red;
            if (control == ComboBoxItemKitchOrBar) ComboBoxItemKitchOrBar.Foreground = Brushes.Red;

            HintAssist.SetHint(control, hintMessage);
        }

        private void TextBoxNameItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameItem.Foreground = Brushes.Black;
        }

        private void TextBoxPriceItem_GotFocus(object sender, RoutedEventArgs e)
        {
            DecimalPriceItem.Foreground = Brushes.Black;
        }

        private void TextBoxDescItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescItem.Foreground = Brushes.Black; 
        }

        private void ComboBoxItemKitchOrBar_DropDownOpened(object sender, EventArgs e)
        {
            ComboBoxItemKitchOrBar.Foreground = Brushes.White;
        }

        private void ComboBoxItemKitchOrBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemKitchOrBar.Foreground = Brushes.Black;
        }

        private void ComboBoxItemKitchOrBar_DropDownClosed(object sender, EventArgs e)
        {
            ComboBoxItemKitchOrBar.Foreground = Brushes.Black;
        }
    }
}
