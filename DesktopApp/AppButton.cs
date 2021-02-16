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
            /// <summary>
            /// Klasa reprezentująca przycisk do obsługi klienta
            /// </summary>
            /// <param name="content">Tekst na przycisku</param>
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
            /// <summary>
            /// Klasa reprezentująca przycisk, który pozwala na poruszanie się w aplikacji jak i potwierdzanie czynności
            /// </summary>
            /// <param name="content">Tekst na przycisku</param>
            public ActionButton(string content)
            {
                Content = content;
                Cursor = Cursors.Hand;
                Background = Brushes.Teal;
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
            /// <summary>
            /// Klasa reprezentująca przycisk wyboru koloru tła aplikacji
            /// </summary>
            /// <param name="color">Kolor przycisku i tła</param>
            public ThemeButton(Brush color)
            {
                Width = 30;
                Height = 30;
                Margin = new Thickness(5);
                Background = color;
                Cursor = Cursors.Hand;
            }
        }

        public class OperationCustomerButton : Button
        {
            /// <summary>
            /// Klasa reprezentująca przycisk operacji dla klienta w menu rozwijanym
            /// </summary>
            /// <param name="content">Tekst na przycisku</param>
            public OperationCustomerButton(string content)
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
}
