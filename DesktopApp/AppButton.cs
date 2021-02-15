using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    /// <summary>
    /// Reprezentuje zbiór przycisków do interakcji z użytkownikiem
    /// </summary>
    public static class AppButton
    {
        public class MenuButton : Button
        {
            public MenuButton(string content)
            {
                Cursor = Cursors.Hand;
                Background = Brushes.DodgerBlue;
                Foreground = Brushes.Black;
                Height = 50;
                Width = 120;
                FontSize = 11;
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

        public class ActionButton : Button
        {
            public ActionButton(string content)
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

        public class ThemeButton : Button
        {
            public ThemeButton(Brush color)
            {
                Width = 30;
                Height = 30;
                Margin = new Thickness(5);
                Background = color;
                Cursor = Cursors.Hand;
            }
        }
    }
}
