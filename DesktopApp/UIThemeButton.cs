using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public class UIThemeButton : Button
    {
        public UIThemeButton(Brush color)
        {
            Width = 30;
            Height = 30;
            Margin = new Thickness(5);
            Background = color;
            Cursor = Cursors.Hand;
        }
    }
}
