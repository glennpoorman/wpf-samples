﻿using ContextMenus.Models;
using ContextMenus.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContextMenus.ViewModels
{
    /// <summary>
    /// Scouts view model class.
    /// </summary>
    public class ScoutsViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The private main collection of scouts (models).
        /// </summary>
        private readonly Scouts scouts = new();

        /// <summary>
        /// The public main collection of scouts (view models);
        /// </summary>
        public ObservableCollection<ScoutViewModel> Scouts { get; } = new ObservableCollection<ScoutViewModel>();

        /// <summary>
        /// The currently selected item.
        /// </summary>
        public ScoutViewModel SelectedItem { get; set; }

        /// <summary>
        /// Command adds a new scout to the collection.
        /// </summary>
        public ICommand AddScout { get; }

        /// <summary>
        /// Command interacts with the user to allow editing of the currently selected scout.
        /// </summary>
        public ICommand EditScout { get; }

        /// <summary>
        /// Command deletes the currently selected scout.
        /// </summary>
        public ICommand DeleteScout { get; }

        /// <summary>
        /// Command adds one sale to the tally of the currently selected scout.
        /// </summary>
        public ICommand AddSale { get; }

        /// <summary>
        /// Command subtracts one sale from the tally of the currently selected scout.
        /// </summary>
        public ICommand SubtractSale { get; }

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public ICommand About { get; }

        /// <summary>
        /// Command shuts down the application.
        /// </summary>
        public ICommand Exit { get; }

        /// <summary>
        /// Event will be fired that requests the application to close.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// Event will be fired that requests that UI be used to edit the given scout object.
        /// </summary>
        public event Action<ScoutViewModel> EditRequested;

        /// <summary>
        /// Event will be fired that requests that the UI display application information.
        /// </summary>
        public event Action AboutRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        public ScoutsViewModel()
        {
            // Create the "Add Scout" command. The handler code adds a new scout to the private
            // collection. A new view model representing that scout is also created and added to
            // the public collection of scout view models.
            //
            AddScout = new RelayCommand(
                (p) =>
                {
                    Scout scout = new() { Name = "New Scout" };
                    scouts.Add(scout);
                    Scouts.Add(new ScoutViewModel(scout));
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
            // scout from the private collection and also deletes its view model from the public
            // collection of view models. The handler code for "CanExecute" makes sure that we have
            // a currently selected item.
            //
            DeleteScout = new RelayCommand(
                (p) =>
                {
                    _ = scouts.Remove(SelectedItem.Scout);
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
                    SelectedItem.Ok.Execute(null);
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
                        SelectedItem.Ok.Execute(null);
                    }
                },
                (p) => SelectedItem != null && SelectedItem.Sold > 0
            );

            // Create the "About" command. The handler code fires an event that application info
            // was requested and allows the event handlers to display this information accordingly.
            //
            About = new RelayCommand(
                (p) => AboutRequested?.Invoke()
            );

            // Create the "Close" command. The handler code fires an event that a close was
            // requested and allows the event handlers to shut down the application accordingly.
            //
            Exit = new RelayCommand(
                (p) => CloseRequested?.Invoke()
            );
        }
    }
}