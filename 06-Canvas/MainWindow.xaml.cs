using System.Windows;
using System.Windows.Controls;

namespace Canvas
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow() => InitializeComponent();

        /// <summary>
        /// Event handler set for the three check boxes in the canvas.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            // The sender can be anything but we know we only set this event handler on check boxes
            // so it's safe to assume that the sender is a check box.
            //
            CheckBox checkBox = (CheckBox)sender;

            // Fetch the check box content. Like the "sender" parameter, the box's "Content"
            // property can contain a number of different types of elements. In this sample we
            // know that the content is text so we can take the lazy approach and simply cast the
            // content into a string.
            //
            string text = (string)checkBox.Content;

            // Use a standard message box to display a message telling the user what just happened.
            // Use the "IsChecked" property on the check box to determine if the box was just
            // checked or unchecked.
            //
            if (checkBox.IsChecked == true)
            {
                _ = MessageBox.Show("You checked box \"" + text + "\"", Title);
            }
            else
            {
                _ = MessageBox.Show("You unchecked box \"" + text + "\"", Title);
            }
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e) => Close();
    }
}
