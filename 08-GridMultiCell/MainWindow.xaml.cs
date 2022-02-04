using System.Windows;
using System.Windows.Controls;

namespace GridMultiCell
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
        /// Event handler set for the three check boxes in the grid.
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
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Button click event handler puts up a message stating that "Help" has been clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Help!", Title);
        }
    }
}
