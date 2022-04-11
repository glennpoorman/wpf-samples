using ContextMenus.Models;
using ContextMenus.Utilities;
using System;
using System.Windows.Input;

namespace ContextMenus.ViewModels
{
    /// <summary>
    /// Scout view model class.
    /// </summary>
    public class ScoutViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The original scout selected for editing.
        /// </summary>
        public Scout Scout { get; init; }

        /// <summary>
        /// The scout proxy used as the data context.
        /// </summary>
        private readonly Scout scoutProxy = new();

        /// <summary>
        /// Scout name property.
        /// </summary>
        public string Name
        {
            get => scoutProxy.Name;
            set { scoutProxy.Name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Number of cookie boxes sold property.
        /// </summary>
        public uint Sold
        {
            get => scoutProxy.Sold;
            set { scoutProxy.Sold = value; OnPropertyChanged("Sold"); }
        }

        public GradeLevel GradeLevel
        {
            get => scoutProxy.GradeLevel;
            set { scoutProxy.GradeLevel = value; OnPropertyChanged("GradeLevel"); }
        }

        /// <summary>
        /// Command saves changes to the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Ok { get; init; }

        /// <summary>
        /// Command restores the data from the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Cancel { get; init; }

        /// <summary>
        /// Event will be fired that requests the edit session to close.
        /// </summary>
        public event Action<bool> CloseRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="scout">The scout that this view model represents.</param>
        public ScoutViewModel(Scout scout)
        {
            // Save the scout that this view model represents.
            //
            this.Scout = scout;

            // Initialize the properties using the corresponding properties from the incoming scout.
            //
            Name = scout.Name;
            Sold = scout.Sold;
            GradeLevel = scout.GradeLevel;

            // Create the "Ok" command to save the data from the view model back to the originally
            // selected scout and to fire off an event stating that we're ready to close.
            //
            Ok = new RelayCommand(
                (p) =>
                {
                    Scout.Name = Name;
                    Scout.Sold = Sold;
                    Scout.GradeLevel = GradeLevel;
                    CloseRequested?.Invoke(true);
                },
                (p) => !string.IsNullOrWhiteSpace(Name)
            );

            // Create the "Cancel" command to restore the data from the originally selected scout
            // back to the view model and fire off an event stating that we're ready to close.
            //
            Cancel = new RelayCommand(
                (p) =>
                {
                    Name = Scout.Name;
                    Sold = Scout.Sold;
                    GradeLevel = Scout.GradeLevel;
                    CloseRequested?.Invoke(false);
                }
            );
        }
    }
}
