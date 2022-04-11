using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ICommands
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The collection of scouts to operate on.
        /// </summary>
        /// <remarks>
        /// Note that this collection is no longer the data context. We will be setting the window
        /// itself as its own data context so we'll need to expose the collection through this public
        /// "Scouts" property so it can be bound to in the XAML.
        /// </remarks>
        public Scouts Scouts { get; } = new Scouts();

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

        // In this sample, we removed the "CustomCommands" class that create instances of the WPF
        // "RoutedCommand". Here we create instances of our custom "RelayCommand" class instead.
        // Those instances implement the "ICommand" interface and are exposed as properties. That
        // means those properties can be bound to the "Command" property on the toolbar and menu
        // items in the XAML.
        //
        // Below we create all of the properties for the commands we want to expose. The commands
        // themselves will be created in the window constructor very similar to the way we created
        // command bindings in the previous samples.

        /// <summary>
        /// Command adds a new scout to the collection.
        /// </summary>
        public ICommand AddScout { get; init; }

        /// <summary>
        /// Command interacts with the user to allow editing of the currently selected scout.
        /// </summary>
        public ICommand EditScout { get; init; }

        /// <summary>
        /// Command deletes the currently selected scout.
        /// </summary>
        public ICommand DeleteScout { get; init; }

        /// <summary>
        /// Command adds one sale to the tally of the currently selected scout.
        /// </summary>
        public ICommand AddSale { get; init; }

        /// <summary>
        /// Command subtracts one sale from the tally of the currently selected scout.
        /// </summary>
        public ICommand SubtractSale { get; init; }

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public ICommand About { get; init; }

        /// <summary>
        /// Command shuts down the application.
        /// </summary>
        public ICommand Exit { get; init; }

        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Set the window to be its own data context.
            //
            // This is equivalent to the "{RelativeSource Self}" syntax we used right in the XAML
            // of the about dialog. For this particular sample, that syntax doesn't work though and
            // I'm not sure why. I believe it's probably a timing issue between the setting of the
            // context and the creation of the scouts collection. Regardless though, we can do it
            // directly right here.
            //
            DataContext = this;

            // Below we create all of the command objects. These are instances of our "RelayCommand"
            // class but are exposed as "ICommand". The "ICommand" interface is a WPF interface and
            // our custom class implements that interface. That means these command properties can
            // be bound to the "Command" properties on various items in the XAML.
            //
            // Note that the "RelayCommand", like the command bindings before, takes an event handler
            // that executes the command and optionally takes an event handler to return whether or
            // not the command can execute.

            // Create the "Add Scout" command using our custom "RelayCommand" class. Like the routed
            // commands, our custom class takes an event handler to execute the command as well as
            // an optional event handler to to say whether or not the command can execute. Here we
            // specify event handling code to add a new scout to the collection.
            //
            AddScout = new RelayCommand(
                (p) =>
                {
                    Scouts.Add(new Scout() { Name = "New Scout" });
                    _ = CollectionViewSource.GetDefaultView(Scouts).MoveCurrentToLast();
                }
            );

            // Create the "EditScout" command. The handler code brings up the edit window to allow
            // modification of the currently selected scout. The handler code or "CanExecute" makes
            // sure the collection count is greater than zero and that we have a currently selected
            // scout.
            //
            EditScout = new RelayCommand(
                (p) =>
                {
                    _ = new EditDialog(this, CurrentScout).ShowDialog();
                },
                (p) => Scouts.Count > 0 && CurrentScout != null
            );

            // Create the "DeleteScout" command. The handler code deletes the currently selected
            // scout from the collection. The handler code for "CanExecute" makes sure the
            // collection count is greater than zero and that we have a currently selected scout.
            //
            DeleteScout = new RelayCommand(
                (p) =>
                {
                    _ = Scouts.Remove(CurrentScout);
                },
                (p) => Scouts.Count > 0 && CurrentScout != null
            );

            // Create the "AddSale" command. The handler code increments the number of boxes sold
            // by the current scout. The handler code for "CanExecute" makes sure that we have a
            // currently selected scout.
            //
            AddSale = new RelayCommand(
                (p) =>
                {
                    CurrentScout.Sold++;
                },
                (p) => CurrentScout != null
            );

            // Create the "SubtractSale" command. The handler code decrements the number of boxes
            // sold by the current scout. The handler code for "CanExecute" first makes sure there
            // there is a currently selected scout and then makes sure the "Sold" property on the
            // scout is greater than zero.
            //
            SubtractSale = new RelayCommand(
                (p) =>
                {
                    if (CurrentScout.Sold > 0)
                    {
                        CurrentScout.Sold--;
                    }
                },
                (p) => CurrentScout != null && CurrentScout.Sold > 0
            );

            // Create the "About" command. The handler code brings up the about dialog box.
            //
            About = new RelayCommand(
                (p) =>
                {
                    _ = new AboutDialog(this).ShowDialog();
                }
            );

            // Create the "Close" command. The handler code closes the window shutting down the
            // application.
            //
            Exit = new RelayCommand(
                (p) =>
                {
                    Close();
                }
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
                _ = new EditDialog(this, CurrentScout).ShowDialog();
            }
        }
    }
}
