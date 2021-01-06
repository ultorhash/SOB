using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class OperationButton : Button
    {
        public OperationButton(string content)
        {
            Cursor = Cursors.Hand;
            Background = Brushes.CornflowerBlue;
            Foreground = Brushes.Black;
            Height = 60;
            Width = 120;
            FontSize = 10;
            FontWeight = FontWeights.Bold;
            HorizontalAlignment = HorizontalAlignment.Center;
            Content = new TextBlock()
            {
                Text = $"{content}",
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(10),
            };
        }
    }
}
