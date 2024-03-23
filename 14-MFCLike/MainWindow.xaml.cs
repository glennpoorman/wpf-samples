using System.Windows;

namespace MFCLike
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Single instance of the custom scout class for this application to operate on.
        /// </summary>
        private readonly Scout scout = new() { Name = "Susie Jones" };

        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the text in the text boxes using the data from our instance of the
            // scout class.
            //
            nameBox.Text = scout.Name;
            soldBox.Text = scout.Sold.ToString();
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleButtonClick(object sender, RoutedEventArgs e)
        {
            // The "Sold" property on the scout instance is incremented by one.
            //
            scout.Sold++;

            // The result is copied into the corresponding text box.
            //
            soldBox.Text = scout.Sold.ToString();

            // If this is the first sale, the "Subtract Sale" button is enabled.
            //
            if (scout.Sold == 1)
            {
                subtractSaleButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleButtonClick(object sender, RoutedEventArgs e)
        {
            // We should only do something if there are sales to subtract.
            //
            if (scout.Sold > 0)
            {
                // The "Sold" property on the scout instance is decremented by one.
                //
                scout.Sold--;

                // The result is copied into the corresponding text box.
                //
                soldBox.Text = scout.Sold.ToString();

                // If the number of boxes sold has gone back to none, then the "Subtract Sale"
                // button is disabled.
                //
                if (scout.Sold == 0)
                {
                    subtractSaleButton.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Event handler for "LostFocus" events on the scout name text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void OnNameLostFocus(object sender, RoutedEventArgs e)
        {
            // As long as the string is not empty, copy the text from the text box into the name
            // property on our scout instance.
            //
            if (!string.IsNullOrEmpty(nameBox.Text))
            {
                scout.Name = nameBox.Text;
            }
        }

        /// <summary>
        /// Event handler for "LostFocus" events on the number of boxes sold text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void OnSoldLostFocus(object sender, RoutedEventArgs e)
        {
            // First parse the text as we're only interested in unsigned integers. If the format
            // is incorrect or the number is out of range, the parse will fail.
            //
            if (uint.TryParse(soldBox.Text, out uint newValue))
            {
                // If the new value is zero, disable the "Subtract" button. Otherwise, enable it.
                //
                subtractSaleButton.IsEnabled = newValue > 0;

                // Copy the new value into the scout instance.
                //
                scout.Sold = newValue;
            }

            // The parse failed. Copy the old value back into the text box.
            //
            else
            {
                soldBox.Text = scout.Sold.ToString();
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
