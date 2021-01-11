using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UIButtonsDockPanel : DockPanel
    {
        public UIButtonsDockPanel(params Button[] buttons)
        {
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;

            foreach (var item in buttons)
            {
                Children.Add(item);
            }
        }
    }
}
