using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UILabel : Label
    {
        public UILabel()
        {
            Background = Brushes.DeepSkyBlue;
            Foreground = Brushes.White;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            FontSize = 14;
            Content = new TextBlock()
            {
                Text = "Czas",
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(10),
            };
        }
    }
}
