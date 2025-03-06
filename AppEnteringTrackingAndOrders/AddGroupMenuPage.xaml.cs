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

namespace AppEnteringTrackingAndOrders
{
    /// <summary>
    /// Логика взаимодействия для AddPositionMenuPage.xaml
    /// </summary>
    public partial class AddGroupMenuPage : Page
    {
        private bool _langRuENKey = false;
        private bool _shiftKey = false;
        public AddGroupMenuPage()
        {
            InitializeComponent();
        }

        private void BackOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Black;
        }
        // Клавиатура с цифрами
        // ---------------------------------------
        private void TopLeftButtonOne_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "1";
                textBox.Focus();
            }
        }

        private void TopMiddleButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "2";
                textBox.Focus();
            }
        }

        private void TopRightButtonThree_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "3";
                textBox.Focus();
            }
        }

        private void CenterLeftButtonFour_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "4";
                textBox.Focus();
            }
        }

        private void CenterMiddleButtonFive_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "5";
                textBox.Focus();
            }
        }

        private void CenterRightButtonSix_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "6";
                textBox.Focus();
            }
        }

        private void DownLeftButtonSeven_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "7";
                textBox.Focus();
            }
        }

        private void DownMiddleButtonEight_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "8";
                textBox.Focus();
            }
        }

        private void DownRightButtonNine_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "9";
                textBox.Focus();
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
        }

        private void DownButtonZero_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += "0";
                textBox.Focus();
            }
        }
        
        private void DownButtonKeyboard_Click(object sender, RoutedEventArgs e)
        {
            KeyboardNumber.Visibility = Visibility.Hidden;
            KeyboardAbc.Visibility = Visibility.Visible;
        }

        // Клавиатура с буквами русскими
        // ---------------------------------------
        private void Button123_Click(object sender, RoutedEventArgs e)
        {
            KeyboardAbc.Visibility = Visibility.Hidden;
            KeyboardNumber.Visibility = Visibility.Visible;
            
        }

        private void ButtonQ_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "й" : "Й";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "q" : "Q";
                }
                textBox.Focus();
            }
        }

        private void ButtonW_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ц" : "Ц";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "w" : "W";
                }
                textBox.Focus();
            }
        }

        private void ButtonE_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "у" : "У";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "e" : "E";
                }
                textBox.Focus();
            }
        }

        private void ButtonR_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "к" : "К";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "r" : "R";
                }
                textBox.Focus();
            }
        }

        private void ButtonT_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "е" : "Е";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "t" : "T";
                }
                textBox.Focus();
            }
        }

        private void ButtonY_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "н" : "Н";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "y" : "Y";
                }
                textBox.Focus();
            }
        }

        private void ButtonU_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "г" : "Г";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "u" : "U";
                }
                textBox.Focus();
            }
        }

        private void ButtonI_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ш" : "Ш";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "i" : "I";
                }
                textBox.Focus();
            }
        }

        private void ButtonO_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "щ" : "Щ";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "o" : "O";
                }
                textBox.Focus();
            }
        }

        private void ButtonP_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "з" : "З";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "p" : "P";
                }
                textBox.Focus();
            }
        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "х" : "Х";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "[" : "{";
                }
                textBox.Focus();
            }
        }

        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ъ" : "Ъ";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "]" : "}";
                }
                textBox.Focus();
            }
        }

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ф" : "Ф";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "a" : "A";
                }
                textBox.Focus();
            }
        }

        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ы" : "Ы";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "s" : "S";
                }
                textBox.Focus();
            }
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "в" : "В";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "d" : "D";
                }
                textBox.Focus();
            }
        }

        private void ButtonF_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "а" : "А";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "f" : "F";
                }
                textBox.Focus();
            }
        }

        private void ButtonG_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "п" : "П";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "g" : "G";
                }
                textBox.Focus();
            }
        }

        private void ButtonH_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "р" : "Р";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "h" : "H";
                }
                textBox.Focus();
            }
        }

        private void ButtonJ_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "о" : "О";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "j" : "J";
                }
                textBox.Focus();
            }
        }

        private void ButtonK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "л" : "Л";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "k" : "K";
                }
                textBox.Focus();
            }
        }

        private void ButtonL_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "д" : "Д";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "l" : "L";
                }
                textBox.Focus();
            }
        }

        private void Button22_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ж" : "Ж";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? ";" : ":";
                }
                textBox.Focus();
            }
        }

        private void Button23_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "э" : "Э";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "'" : "\"";
                }
                textBox.Focus();
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
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "я" : "Я";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "z" : "Z";
                }
                textBox.Focus();
            }
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ч" : "Ч";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "x" : "X";
                }
                textBox.Focus();
            }
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "с" : "С";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "c" : "C";
                }
                textBox.Focus();
            }
        }

        private void ButtonV_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "м" : "М";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "v" : "V";
                }
                textBox.Focus();
            }
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "и" : "И";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "b" : "B";
                }
                textBox.Focus();
            }
        }

        private void ButtonN_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "т" : "Т";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "n" : "N";
                }
                textBox.Focus();
            }
        }

        private void ButtonM_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ь" : "Ь";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "m" : "M";
                }
                textBox.Focus();
            }
        }

        private void Button32_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "б" : "Б";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? "<" : "<";
                }
                textBox.Focus();
            }
        }

        private void Button33_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                if (_langRuENKey == false)
                {
                    textBox.Text += _shiftKey == false ? "ю" : "Ю";
                }
                else
                {
                    textBox.Text += _shiftKey == false ? ">" : ">";
                }
                textBox.Focus();
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
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += " ";
                textBox.Focus();
            }
        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += ",";
                textBox.Focus();
            }
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.IsKeyboardFocused)
            {
                textBox.Text += ".";
                textBox.Focus();
            }
        }

        // ---------------------------------------
    }
}
