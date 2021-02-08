using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class DropDownButton : Button
    {
        public DropDownButton(string content)
        {
            Content = content;
            Background = Brushes.DodgerBlue;
            Width = 120;
            FontWeight = FontWeights.Bold;
            Padding = new Thickness(10);
            FontSize = 10;
        }
    }
}
