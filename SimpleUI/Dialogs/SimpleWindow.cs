
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SimpleUI.Controls
{
    public partial class SimpleWindow : Window
    {
        #region Click events
        protected void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        protected void RestoreClick(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Movable Window

        private void MoveRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        #endregion

        public string Mode
        {
            get { return (string)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(string), typeof(SimpleWindow), new PropertyMetadata(string.Empty));

        static SimpleWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleWindow), new FrameworkPropertyMetadata(typeof(SimpleWindow)));
        }

        public override void OnApplyTemplate()
        {
            CircleButton? minimizeButton = GetTemplateChild("minimizeButton") as CircleButton;
            if (minimizeButton != null)
                minimizeButton.Click += MinimizeClick;

            CircleButton? restoreButton = GetTemplateChild("restoreButton") as CircleButton;
            if (restoreButton != null)
                restoreButton.Click += RestoreClick;

            CircleButton? closeButton = GetTemplateChild("closeButton") as CircleButton;
            if (closeButton != null)
                closeButton.Click += CloseClick;

            Rectangle? MoveRectangle = GetTemplateChild("MoveRectangle") as Rectangle;
            if (MoveRectangle != null)
                MoveRectangle.MouseDown += MoveRectangle_MouseDown;

            base.OnApplyTemplate();
        }
    }
}
