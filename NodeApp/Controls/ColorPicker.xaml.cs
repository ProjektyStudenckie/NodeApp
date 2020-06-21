using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NodeApp
{
    /// <summary>
    /// Logika interakcji dla klasy ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        private byte ColorR = 32;
        private byte ColorG = 50;
        private byte ColorB = 73;


        public string FinalColorString
        {
            get { return (string)GetValue(FinalColorStringProperty); }
            set { SetValue(FinalColorStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FinalColorString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalColorStringProperty =
            DependencyProperty.Register("FinalColorString", typeof(string), typeof(ColorPicker), new PropertyMetadata(null));


        public ColorPicker()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorR = Convert.ToByte(e.NewValue);
            UpdateFinalColor();
        }

        private void Slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorG = Convert.ToByte(e.NewValue);
            UpdateFinalColor();
        }

        private void Slider_ValueChanged3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ColorB = Convert.ToByte(e.NewValue);
            UpdateFinalColor();
        }

        private void UpdateFinalColor()
        {
            Color newColor = Color.FromRgb(ColorR, ColorG, ColorB);
            FinalColorString = (new StringRGBToBrushConverter().ConvertBack(new SolidColorBrush(newColor), null, null, null) as string).Substring(3);
        }
    }
}
