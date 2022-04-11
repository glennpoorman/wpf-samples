using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace ListBinding
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
                // Get the default UI view of the scouts collection. This view acts as a layer on
                // top of the bound collection.
                //
                ICollectionView view = CollectionViewSource.GetDefaultView(Scouts);

                // Return the current item from the view. We know the only items are scouts so it's
                // safe to cast.
                //
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
            // Add the new scout. The collection will send out a notification that it has changed
            // causing the listbox to update.
            //
            Scouts.Add(new Scout() { Name = "New Scout" });

            // Get the default UI view of the scouts collection. This view acts as a layer on top
            // of the bound collection. Use the view to move the current selection to the newly
            // added item.
            //
            _ = CollectionViewSource.GetDefaultView(Scouts).MoveCurrentToLast();
        }

        /// <summary>
        /// Click event handler for the "Delete Scout" menu item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void DeleteScoutClick(object sender, RoutedEventArgs e)
        {
            // Fetch the currently selected scout from the collection and then delete that scout
            // from the collection. The collection will send out a notification that it has changed
            // causing the listbox to update.
            //
            _ = Scouts.Remove(CurrentScout);
        }

        /// <summary>
        /// Button click event handler for the "Add Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleClick(object sender, RoutedEventArgs e)
        {
            // Add a sale to the currently selected scout's tally.
            //
            CurrentScout.Sold++;
        }

        /// <summary>
        /// Button click event handler for the "Subtract Sale" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleClick(object sender, RoutedEventArgs e)
        {
            // Subtract a sale from the currently selected scout's tally.
            //
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
