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
        /// <summary>
        /// Displays a message box in front of the specified window. The message box displays a message, title bar caption, and button; and it also returns a result.
        /// </summary>
        /// <param name="Owner">A System.Windows.Window that represents the owner window of the message box.</param>
        /// <param name="MessageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="Caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="Button">A System.Windows.MessageBoxButton value that specifies which button or buttons to display.</param>
        public SimpleMessageBox(object Owner, string MessageBoxText, string Caption, MessageBoxButton Button)
        {
            InitializeComponent();

            base.Owner = (Window)Owner;
            //base.Title = Caption;
        }

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
    }
}
