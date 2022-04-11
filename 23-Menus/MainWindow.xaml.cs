using System.Windows;

namespace Menus
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Single instance of the custom scout class.
        /// </summary>
        public Scout Scout
        {
            get => (Scout)DataContext;
        }

        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the name of the scout.
            //
            Scout.Name = "Susie Jones";
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleClick(object sender, RoutedEventArgs e)
        {
            Scout.Sold++;
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleClick(object sender, RoutedEventArgs e)
        {
            if (Scout.Sold > 0)
            {
                Scout.Sold--;
            }
        }

        /// <summary>
        /// Button click event handler for the "About" button brings up the about dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new(this);
            _ = aboutDialog.ShowDialog();
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
