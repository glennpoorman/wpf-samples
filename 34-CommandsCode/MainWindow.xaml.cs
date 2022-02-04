using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CommandsCode
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

            // Add a command binding for the "Add Scout" command. Like the XAML sample, the command
            // binding takes an event handler to execute the command as well as an event handler to
            // make sure the command can execute. Here swince our event handlers are relatively lean,
            // we can use lambda expressions to embed the code right into the call to create the
            // binding.
            //
            // The handler code here adds a new scout to the collection.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.AddScout,
                    (s, e) =>
                    {
                        Scouts.Add(new Scout() { Name = "New Scout" });
                        _ = CollectionViewSource.GetDefaultView(Scouts).MoveCurrentToLast();
                    }
                )
            );

            // Add a command binding for the "EditScout" command. The handler code brings up the
            // edit window to allow modification of the currently selected scout. The handler code
            // for "CanExecute" makes sure the collection count is greater than zero and that we
            // have a currently selected scout.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.EditScout,
                    (s, e) =>
                    {
                        _ = new EditDialog(this, CurrentScout).ShowDialog();
                    },
                    (s, e) =>
                    {
                        e.CanExecute = (Scouts.Count > 0 && CurrentScout != null);
                    }
               )
            );

            // Add a command binding for the "DeleteScout" command. The handler code deletes the
            // currently selected scout from the collection. The handler code for "CanExecute" makes
            // sure the collection count is greater than zero and that we have a currently seledcted
            // scout.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.DeleteScout,
                    (s, e) =>
                    {
                        _ = Scouts.Remove(CurrentScout);
                    },
                    (s, e) =>
                    {
                        e.CanExecute = (Scouts.Count > 0 && CurrentScout != null);
                    }
                )
            );

            // Add a command binding for the "AddSale" command. The handler code increments the
            // number of boxes sold by the current scout. The handler code for "CanExecute" makes
            // sure that we have a currently selected scout.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.AddSale,
                    (s, e) =>
                    {
                        CurrentScout.Sold++;
                    },
                    (s, e) =>
                    {
                        e.CanExecute = (CurrentScout != null);
                    }
               )
            );

            // Add a command binding for the "SubtractSale" command. The handler code decrements the
            // number of boxes sold by the current scout. The handler code for "CanExecute" first
            // makes sure there there is a currently selected scout and then makes sure the "Sold"
            // property on the scout is greater than zero.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.SubtractSale,
                    (s, e) =>
                    {
                        if (CurrentScout.Sold > 0)
                        {
                            CurrentScout.Sold--;
                        }
                    },
                    (s, e) =>
                    {
                        e.CanExecute = (CurrentScout != null && CurrentScout.Sold > 0);
                    }
                )
            );

            // Add a command binding for the "About" command. The handler code brings up the about
            // dialog box.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.About,
                    (s, e) =>
                    {
                        _ = new AboutDialog(this).ShowDialog();
                    }
                )
            );

            // Add a command binding for the "Close" command. The handler code closes the window
            // shutting down the application.
            //
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Close,
                    (s, e) =>
                    {
                        Close();
                    }
                )
            );
        }

        /// <summary>
        /// Event handler for a mouse double click in the list view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrentScout != null)
            {
                new EditDialog(this, CurrentScout).ShowDialog();
            }
        }
    }
}
