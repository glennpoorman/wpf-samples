using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CommandsXAML
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
        /// "AddScout" command handler adds a new scout to the collection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddScoutHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Scouts.Add(new Scout() { Name = "New Scout" });
            _ = CollectionViewSource.GetDefaultView(Scouts).MoveCurrentToLast();
        }

        /// <summary>
        /// "EditScout" command handler brings up the edit dialog for the currently selected scout.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void EditScoutHandler(object sender, ExecutedRoutedEventArgs e)
        {
            EditDialog editWindow = new EditDialog(this, CurrentScout);
            _ = editWindow.ShowDialog();
        }

        /// <summary>
        /// "DeleteScout" command handler deletes the currently selected scout.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void DeleteScoutHandler(object sender, ExecutedRoutedEventArgs e)
        {
            _ = Scouts.Remove(CurrentScout);
        }

        /// <summary>
        /// "AddSale" command handler adds to the sales tally of the currently selected scout.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AddSaleHandler(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentScout.Sold++;
        }

        /// <summary>
        /// "SubtractSale" command handler subtracts from the tally of the currently selected scout.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void SubtractSaleHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (CurrentScout.Sold > 0)
            {
                CurrentScout.Sold--;
            }
        }

        /// <summary>
        /// "About" command handler brings up the about dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void AboutHandler(object sender, ExecutedRoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog(this);
            _ = aboutDialog.ShowDialog();
        }

        /// <summary>
        /// "Close" command handler shuts down the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CloseHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// "CanExecute" handler makes sure there is at least one scout in the collection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void HasScouts(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (CurrentScout != null && Scouts.Count > 0);
        }

        /// <summary>
        /// "CanExecute" handler for "SubtractSale" makes sure there is a currently selected scout
        /// with at least one sale.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void CanSubtract(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (CurrentScout != null && CurrentScout.Sold > 0);
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
                EditScoutHandler(null, null);
            }
        }
    }
}
