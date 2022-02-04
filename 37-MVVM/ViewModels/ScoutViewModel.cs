using MVVM.Models;
using MVVM.Utilities;
using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    /// <summary>
    /// Scout view model class.
    /// </summary>
    public class ScoutViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The original scout selected for editing.
        /// </summary>
        /// <remarks>
        /// Note that the scout is now an auto-property and the set accessor is private making the
        /// constructor the only way that the scout can be set. See the constructor remarks.
        /// </remarks>
        public Scout Scout { get; private set; }

        /// <summary>
        /// Scout name property.
        /// </summary>
        private string name;

        /// <summary>
        /// Scout name property.
        /// </summary>
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Number of cookie boxes sold property.
        /// </summary>
        private uint sold;

        /// <summary>
        /// Number of cookie boxes sold property.
        /// </summary>
        public uint Sold
        {
            get => sold;
            set { sold = value; OnPropertyChanged("Sold"); }
        }

        /// <summary>
        /// Grade level property.
        /// </summary>
        private GradeLevel gradeLevel;

        /// <summary>
        /// Grade level property.
        /// </summary>
        public GradeLevel GradeLevel
        {
            get => gradeLevel;
            set { gradeLevel = value; OnPropertyChanged("GradeLevel"); }
        }

        /// <summary>
        /// Command saves changes to the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Ok { get; private set; }

        /// <summary>
        /// Command restores the data from the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Cancel { get; private set; }

        /// <summary>
        /// Event will be fired that requests the edit session to close.
        /// </summary>
        public event Action<bool> CloseRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="scout">The scout that this view model represents.</param>
        /// <remarks>
        /// The scout passed into the constructor is a somewhat big change. Previously, the view
        /// model class was designed to be a static resource in the edit dialog. Here we change the
        /// paradigm in that a scout view model object will exist for every scout in the main scout
        /// collection. So when a scout is created, we will automatically create a corresponding
        /// view model right then. The main collection will be wrapped by an observable collection
        /// of scout view models then.
        /// </remarks>
        public ScoutViewModel(Scout scout)
        {
            // Save the scout that this view model represents.
            //
            this.Scout = scout;

            // Initialize the properties using the corresponding properties from the incoming scout.
            //
            this.Name = scout.Name;
            this.Sold = scout.Sold;
            this.GradeLevel = scout.GradeLevel;

            // Create the "Ok" command to save the data from the view model back to the originally
            // selected scout and to fire off an event stating that we're ready to close.
            //
            Ok = new RelayCommand(
                (p) =>
                {
                    Scout.Name = this.Name;
                    Scout.Sold = this.Sold;
                    Scout.GradeLevel = this.GradeLevel;
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
                    this.Name = Scout.Name;
                    this.Sold = Scout.Sold;
                    this.GradeLevel = Scout.GradeLevel;
                    CloseRequested?.Invoke(false);
                }
            );
        }
    }
}
