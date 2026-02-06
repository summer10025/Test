using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _firstOperand;
        private string _operator = "";
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Number(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_isNewEntry)
                {
                    Display.Text = "";
                    _isNewEntry = false;
                }
                
                if (Display.Text == "0" && button.Content.ToString() != "0")
                {
                     Display.Text = "";
                }

                Display.Text += button.Content.ToString();
            }
        }

        private void Button_Click_Operator(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                _firstOperand = double.Parse(Display.Text);
                _operator = button.Content.ToString()!;
                _isNewEntry = true;
            }
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_operator))
            {
                double secondOperand = double.Parse(Display.Text);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstOperand + secondOperand;
                        break;
                    case "-":
                        result = _firstOperand - secondOperand;
                        break;
                    case "*":
                        result = _firstOperand * secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                            result = _firstOperand / secondOperand;
                        else
                            MessageBox.Show("Cannot divide by zero");
                        break;
                }

                Display.Text = result.ToString();
                _operator = "";
                _isNewEntry = true;
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _firstOperand = 0;
            _operator = "";
            _isNewEntry = true;
        }

        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _isNewEntry = true;
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                if (Display.Text.Length == 0)
                {
                    Display.Text = "0";
                    _isNewEntry = true;
                }
            }
        }

        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                if (_isNewEntry)
                {
                     Display.Text = "0";
                     _isNewEntry = false;
                }
                Display.Text += ".";
            }
        }
    }
}
