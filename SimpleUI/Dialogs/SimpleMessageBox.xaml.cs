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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleUI.Controls
{
    /// <summary>
    /// Interaction logic for SimpleMessageBox.xaml
    /// </summary>
    public partial class SimpleMessageBox : Window
    {
        #region Constructors

        public SimpleMessageBox(object Owner)
        {
            InitializeComponent();

            base.Owner = (Window)Owner;
        }

        public SimpleMessageBox(object Owner, string Message, string Title, SimpleMessageBoxIcon Icon, SimpleDialogButton Buttons)
            : this(Owner)
        {
            this.Message = Message;
            this.Title = Title;

            IconImage = Icon;
            this.Buttons = Buttons;
        }

        public SimpleMessageBox(object Owner, string Message)
            : this(Owner, Message, string.Empty, SimpleMessageBoxIcon.None, SimpleDialogButton.Ok)
        { }

        public SimpleMessageBox(object Owner, string Message, string Title)
            : this(Owner, Message, Title, SimpleMessageBoxIcon.None, SimpleDialogButton.Ok)
        { }

        public SimpleMessageBox(object Owner, string Message, string Title, SimpleDialogButton Buttons)
            : this(Owner, Message, Title, SimpleMessageBoxIcon.None, Buttons)
        { }

        public SimpleMessageBox(object Owner, string Message, string Title, SimpleMessageBoxIcon Icon)
            : this(Owner, Message, Title, Icon, SimpleDialogButton.Ok)
        { }

        #endregion

        #region Static Methods

        public static SimpleDialogResult ShowInformation(object Owner, string Message, string Title, SimpleDialogButton Buttons = SimpleDialogButton.Ok, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
        {
            return ShowDialog(Owner, Message, Title, SimpleMessageBoxIcon.Information, StartPosition, Buttons);
        }

        public static SimpleDialogResult ShowWarning(object Owner, string Message, string Title, SimpleDialogButton Buttons = SimpleDialogButton.Ok, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
        {
            return ShowDialog(Owner, Message, Title, SimpleMessageBoxIcon.Warning, StartPosition, Buttons);
        }

        public static SimpleDialogResult ShowError(object Owner, string Message, string Title, SimpleDialogButton Buttons = SimpleDialogButton.Ok, WindowStartupLocation StartPosition = WindowStartupLocation.CenterOwner)
        {
            return ShowDialog(Owner, Message, Title, SimpleMessageBoxIcon.Error, StartPosition, Buttons);
        }

        private static SimpleDialogResult ShowDialog(object Owner, string Message, string Title, SimpleMessageBoxIcon Icon, WindowStartupLocation StartPosition, SimpleDialogButton Buttons)
        {
            var dlg = new SimpleMessageBox(Owner, Message, Title, Icon, Buttons);
            dlg.WindowStartupLocation = StartPosition;
            dlg.ShowDialog();
            return dlg.Result;
        }

        #endregion

        #region Click events

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

        #region Properties

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(SimpleMessageBox), new PropertyMetadata(string.Empty));

        public new string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly new DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SimpleMessageBox), new PropertyMetadata(string.Empty));

        public SimpleMessageBoxIcon IconImage
        {
            get { return (SimpleMessageBoxIcon)GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value); }
        }

        public static readonly DependencyProperty IconImageProperty =
            DependencyProperty.Register("IconImage", typeof(SimpleMessageBoxIcon), typeof(SimpleMessageBox), new PropertyMetadata(SimpleMessageBoxIcon.None, IconProperty_Changed));

        private static void IconProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SimpleMessageBox)d).ImageElement.Visibility = Visibility.Visible;
            switch ((SimpleMessageBoxIcon)e.NewValue)
            {
                case SimpleMessageBoxIcon.None:
                    ((SimpleMessageBox)d).ImageElement.Visibility = Visibility.Collapsed;
                    break;

                case SimpleMessageBoxIcon.Information:
                    ((SimpleMessageBox)d).ImageElement.Source = new BitmapImage(new Uri("pack://application:,,,/SimpleUI;component/Resources/MessageBoxIcons/info.png"));
                    break;

                case SimpleMessageBoxIcon.Warning:
                    ((SimpleMessageBox)d).ImageElement.Source = new BitmapImage(new Uri("pack://application:,,,/SimpleUI;component/Resources/MessageBoxIcons/warning.png"));
                    break;

                case SimpleMessageBoxIcon.Error:
                    ((SimpleMessageBox)d).ImageElement.Source = new BitmapImage(new Uri("pack://application:,,,/SimpleUI;component/Resources/MessageBoxIcons/error.png"));
                    break;

                default:
                    break;
            }
        }

        public SimpleDialogButton Buttons
        {
            get { return (SimpleDialogButton)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(SimpleDialogButton), typeof(SimpleMessageBox), new PropertyMetadata(SimpleDialogButton.Ok, ButtonsProperty_Changed));

        private static void ButtonsProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SimpleMessageBox)d).OkButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).CloseButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).YesButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).NoButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).CancelButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).AbortButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).RetryButton.Visibility = Visibility.Collapsed;
            ((SimpleMessageBox)d).IgnoreButton.Visibility = Visibility.Collapsed;

            switch ((SimpleDialogButton)e.NewValue)
            {
                case SimpleDialogButton.Ok:
                    ((SimpleMessageBox)d).OkButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.Close:
                    ((SimpleMessageBox)d).CloseButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.OkCancel:
                    ((SimpleMessageBox)d).OkButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).CancelButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.YesNo:
                    ((SimpleMessageBox)d).YesButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).NoButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.YesNoCancel:
                    ((SimpleMessageBox)d).YesButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).NoButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).CancelButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.AbortRetryIgnore:
                    ((SimpleMessageBox)d).AbortButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).RetryButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).IgnoreButton.Visibility = Visibility.Visible;
                    break;

                case SimpleDialogButton.RetryCancel:
                    ((SimpleMessageBox)d).RetryButton.Visibility = Visibility.Visible;
                    ((SimpleMessageBox)d).CancelButton.Visibility = Visibility.Visible;
                    break;


                default:
                    ((SimpleMessageBox)d).OkButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        public SimpleDialogResult Result
        {
            get { return (SimpleDialogResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(SimpleDialogResult), typeof(SimpleMessageBox), new PropertyMetadata(SimpleDialogResult.None));

        #endregion

        #region Button Results

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.OK;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Cancel;
            Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Yes;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.No;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Cancel;
            Close();
        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Abort;
            Close();
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Retry;
            Close();
        }

        private void IgnoreButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SimpleDialogResult.Ignore;
            Close();
        }

        #endregion
    }
}
