using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Dialogs
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The data context is a single instance of the scouts collection.
        /// </summary>
        public Scouts Scouts
        {
            get => (Scouts)DataContext;
        }

        /// <summary>
        /// The currently selected scout in the UI view of the collection.
        /// </summary>
        public Scout CurrentScout
        {
            get
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(Scouts);
                return (Scout)view.CurrentItem;
            }
        }

        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event handler for the "Add Scout" menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddScoutClick(object sender, RoutedEventArgs e)
        {
            Scouts.Add(new Scout() { Name = "New Scout" });
            _ = CollectionViewSource.GetDefaultView(Scouts).MoveCurrentToLast();
        }

        /// <summary>
        /// Click event handler for the "Edit Scout" menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void EditScoutClick(object sender, RoutedEventArgs e)
        {
            // Create the edit window for the selected scout passing in the scout itself along
            // with the parent window (this).
            //
            EditDialog editWindow = new EditDialog(this, CurrentScout);

            // Call "ShowDialog" to display the window as a modal dialog.
            //
            _ = editWindow.ShowDialog();
        }

        /// <summary>
        /// Click event handler for the "Delete Scout" menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void DeleteScoutClick(object sender, RoutedEventArgs e)
        {
            _ = Scouts.Remove(CurrentScout);
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleClick(object sender, RoutedEventArgs e)
        {
            CurrentScout.Sold++;
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleClick(object sender, RoutedEventArgs e)
        {
            if (CurrentScout.Sold > 0)
            {
                CurrentScout.Sold--;
            }
        }

        /// <summary>
        /// Button click event handler for the "About" button brings up the about dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog(this);
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

        /// <summary>
        /// Event handler for a mouse double click in the list view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Keeping in mind that a mouse double click will still fire if the user double clicks
            // an empty list, make sure we have a currently selected scout. If we do, go ahead and
            // call the event handler directly that we set on the "Edit Scout" menu item.
            //
            if (CurrentScout != null)
            {
                EditScoutClick(null, null);
            }
        }
    }
}
