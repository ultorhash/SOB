using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UIAddCustomerDockPanel : DockPanel
    {
        public UIAddCustomerDockPanel(string lblContent, int inputLength)
        {
            Children.Add(new Label
            {
                Content = lblContent,
                Padding = new Thickness(10),
                Background = Brushes.DodgerBlue,
                FontSize = 12,
                Width = 100,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });

            Children.Add(new TextBox
            {
                MaxLength = inputLength,
                Padding = new Thickness(2),
                Background = Brushes.LightGray,
                FontSize = 16,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontWeight = FontWeights.Bold,
            });
        }

        public UIAddCustomerDockPanel(string lblContent, DatePicker dp, int inputLength = 0) : this(lblContent, inputLength)
        {
            Children.RemoveAt(Children.Count - 1);
            Children.Add(new DatePicker
            {
                Background = Brushes.LightGray,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            });
        }
    }
}
