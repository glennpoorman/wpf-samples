using System;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Scout view model class.
    /// </summary>
    /// <remarks>
    /// This view model class serves as the layer of abstraction between an individual scout and the
    /// UI. The scout selected for editing is contained in thsi view model in addition to copies of
    /// the editable fields and all of the commands designed to operate on that scout.
    /// </remarks>
    public class ScoutViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The original scout selected for editing.
        /// </summary>
        private Scout scout;

        /// <summary>
        /// The original scout selected for editing.
        /// </summary>
        /// <remarks>
        /// The original scout is set when the edit window is first created. Note that the method
        /// called to load the scout data into the invidual view model properties will result in
        /// property changed events firing for the various properties.
        /// </remarks>
        public Scout Scout
        {
            get => scout;
            set { scout = value; Name = scout.Name; Sold = scout.Sold; GradeLevel = scout.GradeLevel; }
        }

        /// <summary>
        /// Scout name property.
        /// </summary>
        private string name;

        /// <summary>
        /// Scout name property.
        /// </summary>
        /// <remarks>
        /// This is the property that will be bound to the textbox in the edit dialog and will act
        /// as a proxy between the dialog and the original scout to be edited. Only when changes
        /// are saved will the values be copied back to the original scout.
        /// </remarks>
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
        /// <remarks>
        /// This is the property that will be bound to the textbox in the edit dialog and will act
        /// as a proxy between the dialog and the original scout to be edited. Only when changes
        /// are saved will the values be copied back to the original scout.
        /// </remarks>
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
        /// <remarks>
        /// This is the property that will be bound to the combobox in the edit dialog and will act
        /// as a proxy between the dialog and the original scout to be edited. Only when changes
        /// are saved will the values be copied back to the original scout.
        /// </remarks>
        public GradeLevel GradeLevel
        {
            get => gradeLevel;
            set { gradeLevel = value; OnPropertyChanged("GradeLevel"); }
        }

        /// <summary>
        /// Command saves changes to the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Ok { get; private set; }

        // Like the main window, we want to keep UI-specific code out of the view model. To that
        // end, instead of having the "Ok" command close the edit window, we define an event that
        // we can fire when edits are done and we're ready to close. The owning window can then
        // register a handler for that event that will close the dialog.

        /// <summary>
        /// Event will be fired that requests the edit session to close.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        public ScoutViewModel()
        {
            // Create the "Ok" command. The handler code copies the data from the editable fields
            // in this view model back to the original scout that was selected for edit. Afterward
            // the view model fires and event that it is read to close assuming that the owning
            // window will catch the event and close. The handler code for "CanExecute" makes sure
            // that a valid name has been specified.
            //
            Ok = new RelayCommand(
                (p) =>
                {
                    Scout.Name = this.Name;
                    Scout.Sold = this.Sold;
                    Scout.GradeLevel = this.GradeLevel;
                    CloseRequested?.Invoke();
                },
                (p) => !string.IsNullOrWhiteSpace(Name)
            );
        }
    }
}
