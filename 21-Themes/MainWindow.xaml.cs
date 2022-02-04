using System.Windows;
using System.Windows.Controls;

namespace Themes
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
        /// Event handler set for all of the main window buttons except for the "Close" buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // The sender is an image button.
            // 
            ImageButton button = (ImageButton)sender;

            // We're going to create a string to display that contains the information we have.
            //
            string infoString = string.Empty;

            // If the image source was set, append that information to the string.
            //
            if (button.Source != null)
            {
                infoString += ("\nButton image: " + button.Source.ToString());
            }

            // If the image content was set, append that information to the string.
            //
            if (button.Content != null)
            {
                infoString += ("\nButton content: " + button.Content.ToString());
            }

            // Display the information in a message box.
            //
            _ = MessageBox.Show(infoString);
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
        /// Called when any of the items in the menu button are clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            // The sender is a menu item.
            //
            MenuItem menuItem = (MenuItem)sender;

            // Display the text from the menu item in a message box..
            //
            _ = MessageBox.Show(menuItem.Header.ToString());
        }
    }
}
