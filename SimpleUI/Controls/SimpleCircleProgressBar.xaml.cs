using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleUI.Controls
{
    /// <summary>
    /// Interaction logic for SimpleCircleProgressBar.xaml
    /// </summary>
    public partial class SimpleCircleProgressBar : UserControl
    {
        public SimpleCircleProgressBar()
        {
            InitializeComponent();
        }

        public int ProgressPercentage
        {
            get { return (int)GetValue(ProgressPercentageProperty); }
            set 
            { 
                SetValue(ProgressPercentageProperty, value);
                ProgressAngle = value * 3.6;
                PercentText = $"{value}%";
            }
        }

        public static readonly DependencyProperty ProgressPercentageProperty =
            DependencyProperty.Register("ProgressPercentage", typeof(int), typeof(SimpleCircleProgressBar), new PropertyMetadata(0));

        public int Thickness
        {
            get { return (int)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(int), typeof(SimpleCircleProgressBar), new PropertyMetadata(20));

        public new int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static new readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(int), typeof(SimpleCircleProgressBar), new PropertyMetadata(20));

        private double ProgressAngle
        {
            get { return (double)GetValue(ProgressAngleProperty); }
            set { SetValue(ProgressAngleProperty, value); }
        }

        private static readonly DependencyProperty ProgressAngleProperty =
            DependencyProperty.Register("ProgressAngle", typeof(double), typeof(SimpleCircleProgressBar), new PropertyMetadata(0.0));

        private string PercentText
        {
            get { return (string)GetValue(PercentTextProperty); }
            set { SetValue(PercentTextProperty, value); }
        }

        private static readonly DependencyProperty PercentTextProperty =
            DependencyProperty.Register("PercentText", typeof(string), typeof(SimpleCircleProgressBar), new PropertyMetadata("0%"));
    }
}
