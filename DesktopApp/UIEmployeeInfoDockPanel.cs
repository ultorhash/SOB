using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UIEmployeeInfoDockPanel : DockPanel
    {
        public UIEmployeeInfoDockPanel(string lblContent, string data = "Brak informacji")
        {
            Children.Add(new Label
            {
                Content = lblContent,
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                Width = 150,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            Children.Add(new Label
            {
                Content = data,
                Background = Brushes.LightGray,
                Padding = new Thickness(10),
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });
        }
    }
}
