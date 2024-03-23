using System.Windows;
using System.Windows.Controls;

namespace ControlTemplates
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
        /// Event handler set for all of the main window buttons except for the "Close" buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // The sender is a button.
            // 
            Button button = (Button)sender;

            // Depending on the button, we know the content for this application can only be an
            // image or a text string. For an image, put up a message box displaying the source
            // of the image (name of the image file). For a text string, simply display the string.
            //
            if (button.Content is Image)
            {
                _ = MessageBox.Show(((Image)button.Content).Source.ToString());
            }
            else
            {
                _ = MessageBox.Show(button.Content.ToString());
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
