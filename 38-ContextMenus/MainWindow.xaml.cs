using System.Collections.Specialized;
using System.Windows;
using System.Windows.Data;

namespace ContextMenus
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

            // Set a collection changed event handler on the view's collection of scouts so that we
            // can make sure we always move the current selection to the last item in the collection
            // when a new item is added.
            //
            scoutsView.ViewModel.Scouts.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    _ = CollectionViewSource.GetDefaultView(scoutsView.ViewModel.Scouts).MoveCurrentToLast();
                }
            };

            // Register a handler for when the view model wants to close. The handler code will
            // shut down the application.
            //
            scoutsView.ViewModel.CloseRequested += () => Close();

            // Register a handler for when the view model wants to display application information.
            // The handler code puts up the about dialog.
            //
            scoutsView.ViewModel.AboutRequested += () =>
                _ = new AboutDialog(this).ShowDialog();

            // Register a handler for when the view model wants to put up UI to edit the selected
            // scout. The handler code takes the scout as a parameter and puts up the edit dialog
            // for editing of the scout.
            //
            scoutsView.ViewModel.EditRequested += (s) =>
                _ = new EditDialog(this, s).ShowDialog();
        }
    }
}
