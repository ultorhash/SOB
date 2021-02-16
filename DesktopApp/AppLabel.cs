using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesktopApp
{
    public static class AppLabel
    {
        public class DescriptionLabel : Label
        {
            /// <summary>
            /// Klasa reprezentująca element opisujący
            /// </summary>
            /// <param name="content">Zawartość tekstu opisującego</param>
            public DescriptionLabel(string content)
            {
                VerticalContentAlignment = VerticalAlignment.Center;
                HorizontalContentAlignment = HorizontalAlignment.Center;
                Background = Brushes.LightSteelBlue;

                AddChild(new TextBlock
                {
                    Text = content,
                    FontSize = 15,
                    FontWeight = FontWeights.Bold,                 
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                });
            }
        }
    }
}
