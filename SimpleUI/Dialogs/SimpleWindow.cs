using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

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
            {
                // Allows the window to be dragged while maximized. This will make the window normal and place it at the location of the cursor.
                if (WindowState == WindowState.Maximized)
                {
                    // Store the cursor position relative to the current window
                    Point cursorPosition = e.GetPosition(this);

                    // Restore window to normal state before dragging
                    WindowState = WindowState.Normal;

                    // Calculate the scaling factors based on the original fullscreen size and new window size
                    double xScalingFactor = cursorPosition.X / SystemParameters.PrimaryScreenWidth;
                    double yScalingFactor = cursorPosition.Y / SystemParameters.PrimaryScreenHeight;

                    // Adjust the window position to match the scaled cursor position
                    Left = (SystemParameters.PrimaryScreenWidth - ActualWidth) * xScalingFactor;
                    Top = (SystemParameters.PrimaryScreenHeight - ActualHeight) * yScalingFactor - 10; // Adjust the offset as needed
                }

                // Window moving action.
                DragMove();
            }
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
