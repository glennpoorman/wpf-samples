using System.ComponentModel;

namespace CommandsXAML
{
    /// <summary>
    /// Scout class.
    /// </summary>
    public class Scout : INotifyPropertyChanged
    {
        /// <summary>
        /// "PropertyChanged" event is part of the "INotifyPropertyChanged" implementation.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Utility used to fire off a property changed event.
        /// </summary>
        /// <param name="property">The name of the property that has changed.</param>
        private void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

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
            set { name = value;  OnPropertyChanged("Name"); OnPropertyChanged("IsValid"); }
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
            set { sold = value;  OnPropertyChanged("Sold"); }
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
        /// Validity property returns false if the scout name is empty.
        /// </summary>
        public bool IsValid => !string.IsNullOrWhiteSpace(name);
    }
}