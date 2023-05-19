using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace CSharpCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        String num1;
        String num2;
        String func;
        float mem = 0;
        bool end = false;
        bool periodenabled = true;

        private void Button_Press(object sender, RoutedEventArgs e)
        {
            if (!end)
            {
                if ((sender as Button).Content.ToString() == "." && !periodenabled)
                {
                    return;
                }
                if ((sender as Button).Content.ToString() == "." && periodenabled)
                {
                    if (num1 == null)
                    {
                        num1 = "0";
                    }
                    if (func != null && num2 == null)
                    {
                        num2 = "0";
                    }
                    periodenabled = false;
                }
                if (func != null)
                {
                    if (num1 == null)
                    {
                        num1 = "0";
                    }
                    if ((sender as Button).Content.ToString() != "." && num2 == "0")
                    {
                        num2 = null;
                    }
                    num2 += (sender as Button).Content.ToString();
                    number.Text = num2;
                }
                else
                {
                    if ((sender as Button).Content.ToString() != "." && num1 == "0")
                    {
                        num1 = null;
                    }
                    num1 += (sender as Button).Content.ToString();
                    number.Text = num1;
                }
            }
        }

        private void Negative_Press(object sender, RoutedEventArgs e)
        {
            if (func != null)
            {
                if (num2 == null)
                {
                    num2 = "0";
                    number.Text = num2;
                }
                if (num2.Contains("-"))
                {
                    num2 = num2.Substring(1, num2.Length - 1);
                    number.Text = num2;
                }
                else
                {
                    num2 = "-" + number.Text;
                    number.Text = num2;
                }
            }
            else
            {
                if (num1 == null)
                {
                    num1 = "0";
                    number.Text = num1;
                }
                if (num1.Contains("-"))
                {
                    num1 = num1.Substring(1, num1.Length - 1);
                    number.Text = num1;
                }
                else
                {
                    num1 = "-" + number.Text;
                    number.Text = num1;
                }
            }
        }
        private void Function_Press(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "C")
            {
                num1 = null;
                num2 = null;
                func = null;
                end = false;
                periodenabled = true;
                number.Text = "0";
                return;
            }
            else if (!end)
            {
                func = (sender as Button).Content.ToString();
            }
            if (num2 == null)
            {
                periodenabled = true;
            }
        }

        private void Calculate_Press(object sender, RoutedEventArgs e)
        {
            if (!end && func != null && num2 != null)
            {
                float inum1 = float.Parse(num1);
                float inum2 = float.Parse(num2);
                float finalnum = 0;
                if (func == "+")
                {
                    finalnum = inum1 + inum2;
                }
                else if (func == "-")
                {
                    finalnum = inum1 - inum2;
                }
                else if (func == "x")
                {
                    finalnum = inum1 * inum2;
                }
                else if (func == "÷")
                {
                    finalnum = inum1 / inum2;
                }
                else if (func == "%")
                {
                    finalnum = inum1 % inum2;
                }
                number.Text = finalnum.ToString();
                end = true;
            }
        }
        private void Memory_Press(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "M+")
            {
                mem += float.Parse(number.Text);
            }
            else if ((sender as Button).Content.ToString() == "MC")
            {
                mem = 0;
            }
            else
            {
                if (func != null)
                {
                    num2 = mem.ToString();
                    number.Text = num2;
                }
                else
                {
                    num1 = mem.ToString();
                    number.Text = num1;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "D1")
            {
                one.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D2")
            {
                two.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D3")
            {
                three.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D4")
            {
                four.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D5" && (Keyboard.Modifiers & ModifierKeys.Shift) == 0)
            {
                five.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D6")
            {
                six.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D7")
            {
                seven.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D8" && (Keyboard.Modifiers & ModifierKeys.Shift) == 0)
            {
                eight.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D9")
            {
                nine.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D0")
            {
                zero.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "C" || e.Key.ToString() == "Escape")
            {
                clear.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "Return")
            {
                equals.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "OemPlus" && (Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                plus.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "OemPlus" && (Keyboard.Modifiers & ModifierKeys.Shift) == 0)
            {
                equals.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "OemMinus")
            {
                minus.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "OemPeriod")
            {
                period.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D8" && (Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                multiply.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "D5" && (Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                mod.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            else if (e.Key.ToString() == "OemQuestion")
            {
                divide.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
