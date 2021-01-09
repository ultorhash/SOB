using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UIButton : Button
    {
        public UIButton(string content)
        {
            Content = content;
            Cursor = Cursors.Hand;
            Background = Brushes.Gray;
            Foreground = Brushes.White;
            Height = 40;
            Width = 80;
            FontSize = 14;
            FontWeight = FontWeights.Bold;
            HorizontalAlignment = HorizontalAlignment.Center;
            Margin = new Thickness(10);
        }
    }
}
