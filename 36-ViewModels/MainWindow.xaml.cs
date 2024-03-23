using System.Collections.Specialized;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The view model used as the data context on the window.
        /// </summary>
        public ScoutsViewModel ViewModel => (ScoutsViewModel)DataContext;

        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // We want to avoid any UI specified code on the view model so for several operations,
            // the view model fires events. We can register handlers for those events here for the
            // UI specific code needed.

            // First, in the previous samples we've always tried to automatically select/highlight
            // the newest scout added to the scouts collection. The utilities used to do this are
            // UI utilities that we'd prefer to avoid referencing in the view model. There was no
            // need to add a specialized event for this on the view model though as the collection
            // itself fires events whenever the collection changes. So here we add an event handler
            // for the "CollectionChanged" event. The handler code checks to see if the action that
            // caused the event as an "Add". If it was, we use the same code from the previous
            // samples to select/highlight the last item in the collection.
            //
            ViewModel.Scouts.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    _ = CollectionViewSource.GetDefaultView(ViewModel.Scouts).MoveCurrentToLast();
                }
            };

            // Register a handler for when the view model wants to close. The handler code will
            // shut down the application.
            //
            ViewModel.CloseRequested += () => Close();

            // Register a handler for when the view model wants to display application information.
            // The handler code puts up the about dialog.
            //
            ViewModel.AboutRequested += () =>
                _ = new AboutDialog(this).ShowDialog();

            // Register a handler for when the view model wants to put up UI to edit the selected
            // scout. The handler code takes the scout as a parameter and puts up the edit dialog
            // for editing of the scout.
            //
            ViewModel.EditRequested += (s) =>
                _ = new EditDialog(this, s).ShowDialog();
        }

        /// <summary>
        /// Event handler for a mouse double click in the list view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ListDoubleClick(object sender, MouseButtonEventArgs e) =>
            ViewModel.EditScout.Execute(null);
    }
}
