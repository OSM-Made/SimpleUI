using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleUI.Controls
{
    /// <summary>
    /// Interaction logic for SimpleSwitch.xaml
    /// </summary>
    public partial class SimpleSwitch : UserControl
    {
        private static readonly int _animationTime = 150;

        public SimpleSwitch()
        {
            InitializeComponent();
            SizeChanged += OnControlSizeChanged;
        }

        private void OnControlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Size of the corner radius
            HalfHeight = ActualHeight / 2;

            // Force the control width to always be twice the height.
            Width = ActualHeight * 2;
        }

        public double HalfHeight
        {
            get { return (double)GetValue(HalfHeightProperty); }
            set { SetValue(HalfHeightProperty, value); }
        }

        public static readonly DependencyProperty HalfHeightProperty =
            DependencyProperty.Register("HalfHeight", typeof(double), typeof(SimpleSwitch), new PropertyMetadata(0.0));

        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register("IsToggled", typeof(bool), typeof(SimpleSwitch), new PropertyMetadata(false, IsToggledChangedCallback));

        private static void IsToggledChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            SimpleSwitch? form = obj as SimpleSwitch;
            form?.DoToggleAnim((bool)e.NewValue);
        }

        protected virtual void DoToggleAnim(bool newValue)
        {
            if (newValue)
            {
                var animation = new DoubleAnimation(0, Height, new Duration(TimeSpan.FromMilliseconds(_animationTime)));
                Storyboard.SetTarget(animation, ToggleEllipse);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

                var sb = new Storyboard();
                sb.Children.Add(animation);
                sb.Begin();
            }
            else
            {
                var animation = new DoubleAnimation(Height, 0, new Duration(TimeSpan.FromMilliseconds(_animationTime)));
                Storyboard.SetTarget(animation, ToggleEllipse);
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

                var sb = new Storyboard();
                sb.Children.Add(animation);
                sb.Begin();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsToggled = !IsToggled;
        }
    }
}
