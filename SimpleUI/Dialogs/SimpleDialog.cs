using SimpleUI.Controls;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Shapes;

namespace SimpleUI.Dialogs
{
    public partial class SimpleDialog : Window
    {
        #region Click events

        protected void RestoreClick(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        protected void CloseClick(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.None;
            Close();
        }

        public virtual void Button1_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Button1;
            Close();
        }

        public virtual void Button2_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Button2;
            Close();
        }

        public virtual void Button3_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Button3;
            Close();
        }

        #endregion

        #region Resizeable Window

        private HwndSource? _hwndSource;

        protected override void OnInitialized(EventArgs e)
        {
            SourceInitialized += OnSourceInitialized;
            base.OnInitialized(e);
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            _hwndSource = (HwndSource)PresentationSource.FromVisual(this);
        }

        protected void ResizeRectangle_MouseMove(Object sender, MouseEventArgs e)
        {
            Rectangle? rectangle = sender as Rectangle;
            switch (rectangle?.Name)
            {
                case "top":
                    Cursor = Cursors.SizeNS;
                    break;
                case "bottom":
                    Cursor = Cursors.SizeNS;
                    break;
                case "left":
                    Cursor = Cursors.SizeWE;
                    break;
                case "right":
                    Cursor = Cursors.SizeWE;
                    break;
                case "topLeft":
                    Cursor = Cursors.SizeNWSE;
                    break;
                case "topRight":
                    Cursor = Cursors.SizeNESW;
                    break;
                case "bottomLeft":
                    Cursor = Cursors.SizeNESW;
                    break;
                case "bottomRight":
                    Cursor = Cursors.SizeNWSE;
                    break;
                default:
                    break;
            }
        }

        protected void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
                Cursor = Cursors.Arrow;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        protected void ResizeRectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle? rectangle = sender as Rectangle;
            switch (rectangle?.Name)
            {
                case "top":
                    Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Top);
                    break;
                case "bottom":
                    Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Bottom);
                    break;
                case "left":
                    Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Left);
                    break;
                case "right":
                    Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Right);
                    break;
                case "topLeft":
                    Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.TopLeft);
                    break;
                case "topRight":
                    Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.TopRight);
                    break;
                case "bottomLeft":
                    Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.BottomLeft);
                    break;
                case "bottomRight":
                    Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.BottomRight);
                    break;
                default:
                    break;
            }
        }

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(_hwndSource.Handle, 0x112, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        #endregion

        #region Movable Window

        private void MoveRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        #endregion

        #region Properties

        private SimpleDialogButton Buttons
        {
            get { return (SimpleDialogButton)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        private static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(SimpleDialogButton), typeof(SimpleDialog), new PropertyMetadata(SimpleDialogButton.None));

        private string[] ButtonNames
        {
            get { return (string[])GetValue(ButtonNamesProperty); }
            set { SetValue(ButtonNamesProperty, value); }
        }

        private static readonly DependencyProperty ButtonNamesProperty =
            DependencyProperty.Register("ButtonNames", typeof(string[]), typeof(SimpleDialog), new PropertyMetadata(new string[3], ButtonNamesProperty_Changed));

        private static void ButtonNamesProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SimpleButton? Button1 = ((SimpleDialog)d).GetTemplateChild("Button1") as SimpleButton;
            if (Button1 != null)
                Button1.Content = ((string[])e.NewValue)[0];

            SimpleButton? Button2 = ((SimpleDialog)d).GetTemplateChild("Button2") as SimpleButton;
            if (Button2 != null)
                Button2.Content = ((string[])e.NewValue)[1];

            SimpleButton? Button3 = ((SimpleDialog)d).GetTemplateChild("Button3") as SimpleButton;
            if (Button3 != null)
                Button3.Content = ((string[])e.NewValue)[2];
        }

        public SimpleDialogResult Result
        {
            get { return (SimpleDialogResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(SimpleDialogResult), typeof(SimpleDialog), new PropertyMetadata(SimpleDialogResult.None));

        #endregion

        #region Constructor

        private void Init(Window Owner, string[] ButtonNames, string Title, SimpleDialogButton Buttons, WindowStartupLocation StartPosition)
        {
            base.Owner = Owner;
            this.ButtonNames = ButtonNames;
            base.Title = Title;
            this.Buttons = Buttons;
            WindowStartupLocation = StartPosition;

            PreviewMouseMove += OnPreviewMouseMove;
        }

        public SimpleDialog(Window Owner, string Button1Name, string Title, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
            : base()
        {
            Init(Owner, new string[] { Button1Name }, Title, SimpleDialogButton.OneButton, StartPosition);
        }

        public SimpleDialog(Window Owner, string Button1Name, string Button2Name, string Title, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
            : base()
        {
            Init(Owner, new string[] { Button1Name, Button2Name }, Title, SimpleDialogButton.TwoButton, StartPosition);
        }

        public SimpleDialog(Window Owner, string Button1Name, string Button2Name, string Button3Name, string Title, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
            : base()
        {
            Init(Owner, new string[] { Button1Name, Button2Name, Button3Name }, Title, SimpleDialogButton.ThreeButton, StartPosition);
        }

        static SimpleDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleDialog), new FrameworkPropertyMetadata(typeof(SimpleDialog)));
        }

        public override void OnApplyTemplate()
        {
            CircleButton? restoreButton = GetTemplateChild("restoreButton") as CircleButton;
            if (restoreButton != null)
                restoreButton.Click += RestoreClick;

            CircleButton? closeButton = GetTemplateChild("closeButton") as CircleButton;
            if (closeButton != null)
                closeButton.Click += CloseClick;

            Rectangle? MoveRectangle = GetTemplateChild("MoveRectangle") as Rectangle;
            if (MoveRectangle != null)
                MoveRectangle.MouseDown += MoveRectangle_MouseDown;

            Grid? resizeGrid = GetTemplateChild("resizeGrid") as Grid;
            if (resizeGrid != null)
            {
                foreach (UIElement element in resizeGrid.Children)
                {
                    Rectangle? resizeRectangle = element as Rectangle;
                    if (resizeRectangle != null)
                    {
                        resizeRectangle.PreviewMouseDown += ResizeRectangle_PreviewMouseDown;
                        resizeRectangle.MouseMove += ResizeRectangle_MouseMove;
                    }
                }
            }

            SimpleButton? Button1 = GetTemplateChild("Button1") as SimpleButton;
            if (Button1 != null)
            {
                if(ButtonNames.Count() > 0)
                    Button1.Content = ButtonNames[0];

                if (Buttons >= SimpleDialogButton.OneButton)
                    Button1.Visibility = Visibility.Visible;
                else
                    Button1.Visibility = Visibility.Collapsed;

                Button1.Click += Button1_Click;
            }

            SimpleButton? Button2 = GetTemplateChild("Button2") as SimpleButton;
            if (Button2 != null)
            {
                if (ButtonNames.Count() > 1)
                    Button2.Content = ButtonNames[1];

                if (Buttons >= SimpleDialogButton.TwoButton)
                    Button2.Visibility = Visibility.Visible;
                else
                    Button2.Visibility = Visibility.Collapsed;

                Button2.Click += Button2_Click;
            }

            SimpleButton? Button3 = GetTemplateChild("Button3") as SimpleButton;
            if (Button3 != null)
            {
                if (ButtonNames.Count() > 2)
                    Button3.Content = ButtonNames[2];

                if (Buttons == SimpleDialogButton.ThreeButton)
                    Button3.Visibility = Visibility.Visible;
                else
                    Button3.Visibility = Visibility.Collapsed;

                Button3.Click += Button3_Click;
            }

            base.OnApplyTemplate();
        }

        #endregion

    }
}
