using System.Windows;

namespace AboutBox
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
        /// Button click event handler for the "About" button brings up the about dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AboutButtonClick(object sender, RoutedEventArgs e)
        {
            // Create the about dialog window passing this window in as the owner.
            //
            AboutDialog aboutDialog = new AboutDialog(this);

            // Call the "ShowDialog" method to show the window.
            //
            // Note that WPF doesn't distinguish between a window and a dialog. Calling "ShowDialog"
            // instead of "Show", however, brings up the window modally. In other words, no other
            // window in the app can get focus until this window is closed.
            //
            // Note that "ShowDialog" returns a bool stating whether the dialog was ok'd or
            // cancelled. In our case we don't care about the result so we don't save it.
            //
            _ = aboutDialog.ShowDialog();
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
