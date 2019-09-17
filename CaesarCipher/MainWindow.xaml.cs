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
using System.Diagnostics;

namespace CaesarCipher
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

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            string displayString = String.Empty;

            foreach (char x in InputText.Text)
            {
                if (char.IsLetter(x) && (int)Char.ToLower(x) <= 109)
                {
                    displayString += (char)((int)Char.ToLower(x) + 13);
                    displayString = CheckIfUpper(x, displayString);
                }
                else if (char.IsLetter(x) && (int)Char.ToLower(x) > 109)
                {
                    displayString += (char)((int)Char.ToLower(x) - 13);
                    displayString = CheckIfUpper(x, displayString);
                }
                else
                {
                    displayString += x;
                }
            }
            OutputText.Text = displayString;
        }
        private string CheckIfUpper(char upper, string convertedStr)
        {
            if (Char.IsUpper(upper))
            {
                string lastChar = convertedStr[convertedStr.Length - 1].ToString();
                convertedStr = convertedStr.Remove(convertedStr.Length - 1);
                convertedStr += lastChar.ToUpper();
            }

            return convertedStr;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EncodeButton_Click(EncodeButton, null);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
