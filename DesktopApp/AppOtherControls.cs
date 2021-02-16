using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace DesktopApp
{
    /// <summary>
    /// Statyczna klasa reprezentująca inne kontroli służące do interakcji z użytkownikiem
    /// </summary>
    public static class AppOtherControls
    {
        public class PeselTextBox : TextBox
        {
            /// <summary>
            /// Klasa reprezentująca miniformularz przyjmujący dokładnie 1 liczbę
            /// </summary>
            public PeselTextBox()
            {
                MaxLength = 1;
                Width = 25;
                Height = 50;
                Margin = new Thickness(4);
                Background = Brushes.White;
                FontSize = 15;
                FontWeight = FontWeights.Black;
                VerticalContentAlignment = VerticalAlignment.Center;
                HorizontalContentAlignment = HorizontalAlignment.Center;
            }
        }
    }
}
