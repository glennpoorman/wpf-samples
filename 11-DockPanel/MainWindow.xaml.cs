using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DockPanel
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
        /// Event handler set for all of the buttons in the dock panel except for the "Clear" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // The sender is a button.
            //            
            Button button = sender as Button;

            // Create a new list box item using the content of the button that was clicked and add
            // that to the list.
            //
            _ = listBox.Items.Add(button.Content);
        }

        /// <summary>
        /// Event handler set fo the "Clear" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            // Remove all of the items from the list.
            //
            listBox.Items.Clear();
        }

        /// <summary>
        /// Button click event handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e) => Close();

        /// <summary>
        /// Event handler set to handle "MouseDoubleClick" events in the list box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the even data.</param>
        private void ListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Fetch the index of the selected item in the list.
            //
            int selection = listBox.SelectedIndex;

            // Make sure the selection is 0 or greater. The double click event will still fire
            // with a selected index of -1 if the list is empty or if there is no selection.
            // If the selection is valid, display the item number that was selected (making it
            // 1-based for display purposes).
            //
            if (selection >= 0)
            {
                _ = MessageBox.Show("Double clicked on item #" + (selection + 1), Title);
            }
        }
    }
}
