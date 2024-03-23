using System.Windows;

namespace DataBinding
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

            // In order for the binding specified in the XAML to work, there needs to be a data
            // context. The data context can be an object of any type so we'll go ahead and set the
            // "scout" object as the data context on the window.
            //
            // NOTE: When WPF looks for a data context, it starts on the element where the data
            //       binding is specified (in our case, the text boxes) and if it doesn't find it,
            //       continues up the tree looking until a data context is found or until we run
            //       out of elements. In this case, we could have just as easily set the scout as
            //       the data context on each of the text boxes individually but by moving up and
            //       setting it on the stack panel or the window, we only have to do it once.
            //
            DataContext = scout;
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleButtonClick(object sender, RoutedEventArgs e)
        {
            // Increment the number of boxes sold. This will cause the scout to send out a
            // notification that the property has changed which will automatically update the
            // text box that is bound to that property.
            //
            scout.Sold++;
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleButtonClick(object sender, RoutedEventArgs e)
        {
            // Decrement the number of boxes sold. This will cause the scout to send out a
            // notification that the property has changed which will automatically update the
            // text box that is bound to that property.
            //
            if (scout.Sold > 0)
            {
                scout.Sold--;
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
