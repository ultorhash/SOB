using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UINumberTextBox : TextBox
    {
        public UINumberTextBox()
        {
            MaxLength = 1;
            Width = 25;
            Height = 50;
            Margin = new Thickness(4);
            Background = Brushes.White;
            FontSize = 15;
            FontWeight = FontWeights.Black;
            VerticalContentAlignment = VerticalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Center;
        }
    }
}
