using System;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Scouts view model class.
    /// </summary>
    /// <remarks>
    /// This view model class serves as the layer of abstraction between the scouts collection and
    /// the UI. The underlying scouts collection is contained in this view model in addition to all
    /// of the commands designed to operate on that collection.
    /// </remarks>
    public class ScoutsViewModel
    {
        /// <summary>
        /// The collection of scouts to operate on.
        /// </summary>
        public Scouts Scouts { get; private set; }

        /// <summary>
        /// The currently selected item.
        /// </summary>
        /// <remarks>
        /// In the previous samples, we used ICollectionSource to get views of the bound collection
        /// and find out which item is currently selected. This is a very UI-centric approach though
        /// and we'd like to remove any UI-specific code from the view model. So here we add a
        /// property to keep track of the selected item in our scouts collection and bind it to the
        /// list box in the XAML.
        /// </remarks>
        public Scout SelectedItem { get; set; }

        /// <summary>
        /// Command adds a new scout to the collection.
        /// </summary>
        public ICommand AddScout { get; private set; }

        /// <summary>
        /// Command interacts with the user to allow editing of the currently selected scout.
        /// </summary>
        public ICommand EditScout { get; private set; }

        /// <summary>
        /// Command deletes the currently selected scout.
        /// </summary>
        public ICommand DeleteScout { get; private set; }

        /// <summary>
        /// Command adds one sale to the tally of the currently selected scout.
        /// </summary>
        public ICommand AddSale { get; private set; }

        /// <summary>
        /// Command subtracts one sale from the tally of the currently selected scout.
        /// </summary>
        public ICommand SubtractSale { get; private set; }

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public ICommand About { get; private set; }

        /// <summary>
        /// Command shuts down the application.
        /// </summary>
        public ICommand Exit { get; private set; }

        // We'd really like to keep UI-specific code out of the view model thus keeping the view
        // model UI neutral. To that end, for items that will require UI (edit, about, close), we
        // create events. The commands here in the view model, instead of bringing up windows or
        // closing windows, will fire events that these operations have been requested. The UI can
        // register handlers for these events and handle the requests accordingly when the events
        // are fired. That means that the code-behinds for the windows can still do the UI-specific
        // stuff.

        /// <summary>
        /// Event will be fired that requests the application to close.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// Event will be fired that requests that UI be used to edit the given scout object.
        /// </summary>
        public event Action<Scout> EditRequested;

        /// <summary>
        /// Event will be fired that requests that the UI display application information.
        /// </summary>
        public event Action AboutRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        public ScoutsViewModel()
        {
            // Create the scouts collection.
            //
            this.Scouts = new Scouts();

            // Create the "Add Scout" command. The handler code adds a new scout to the collection.
            //
            AddScout = new RelayCommand(
                (p) =>
                {
                    Scouts.Add(new Scout() { Name = "New Scout" });
                }
            );

            // Create the "EditScout" command. The handler code fires an event that an edit of the
            // scout was requested and allows any registered event handlers to have the UI provide
            // the user with an interface to edit the scout. The handler code or "CanExecute" makes
            // sure that we have a currently selected item.
            //
            EditScout = new RelayCommand(
                (p) =>
                {
                    if (EditRequested != null && SelectedItem != null)
                    {
                        EditRequested(SelectedItem);
                    }
                },
                (p) => SelectedItem != null
            );

            // Create the "DeleteScout" command. The handler code deletes the currently selected
            // scout from the collection. The handler code for "CanExecute" makes sure that we have
            // a currently selected item.
            //
            DeleteScout = new RelayCommand(
                (p) =>
                {
                    _ = Scouts.Remove(SelectedItem);
                },
                (p) => SelectedItem != null
            );

            // Create the "AddSale" command. The handler code increments the number of boxes sold
            // by the current scout. The handler code for "CanExecute" makes sure that we have a
            // currently selected item.
            //
            AddSale = new RelayCommand(
                (p) =>
                {
                    SelectedItem.Sold++;
                },
                (p) => SelectedItem != null
            );

            // Create the "SubtractSale" command. The handler code decrements the number of boxes
            // sold by the current scout. The handler code for "CanExecute" first makes sure there
            // there is a currently selected scout and then makes sure the "Sold" property on the
            // scout is greater than zero.
            //
            SubtractSale = new RelayCommand(
                (p) =>
                {
                    if (SelectedItem.Sold > 0)
                    {
                        SelectedItem.Sold--;
                    }
                },
                (p) => SelectedItem != null && SelectedItem.Sold > 0
            );

            // Create the "About" command. The handler code fires an event that application info
            // was requested and allows the event handlers to display this information accordingly.
            //
            About = new RelayCommand(
                (p) =>
                {
                    AboutRequested?.Invoke();
                }
            );

            // Create the "Close" command. The handler code fires an event that a close was
            // requested and allows the event handlers to shut down the application accordingly.
            //
            Exit = new RelayCommand(
                (p) =>
                {
                    CloseRequested?.Invoke();
                }
            );
        }
    }
}