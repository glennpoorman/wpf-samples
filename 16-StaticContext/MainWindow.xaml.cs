using System.Windows;

namespace StaticContext
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Single instance of the custom scout class.
        /// </summary>
        /// <remarks>
        /// With the static scout instance created in the XAML, we don't need to create it here in
        /// the window class anymore. We still need to be able to reference it though. We can easily
        /// do that by simply calling the "DataContext" property on the window and casting the
        /// result. Doing that repeatedly in the code looks a little ugly though so create a "Scout"
        /// property here to do that for us.
        /// </remarks>
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

            // Initialize the name of the scout here using the property we just defined to
            // reference the data context directly.
            //
            Scout.Name = "Susie Jones";
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleButtonClick(object sender, RoutedEventArgs e)
        {
            Scout.Sold++;
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleButtonClick(object sender, RoutedEventArgs e)
        {
            if (Scout.Sold > 0)
            {
                Scout.Sold--;
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
    }
}
