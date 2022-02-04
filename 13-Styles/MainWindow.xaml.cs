using System.Windows;
using System.Windows.Controls;

namespace Styles
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler set for the three check boxes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            // The sender is a checkbox.
            //
            CheckBox checkBox = (CheckBox)sender;

            // Fetch the check box text.
            //
            string text = (string)checkBox.Content;

            // Use a standard message box to display a message telling the user what just happened.
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
        /// Event handler set for the three radio buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void RadioClick(object sender, RoutedEventArgs e)
        {
            // The sender is a radio button.
            //
            RadioButton radioButton = (RadioButton)sender;

            // Fetch the radio button text.
            //
            string text = (string)radioButton.Content;

            // Use a standard message box to display a message telling the user what just happened.
            //
            _ = MessageBox.Show("You picked radio button \"" + text + "\"", Title);
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
