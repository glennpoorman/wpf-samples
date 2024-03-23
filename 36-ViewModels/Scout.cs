namespace ViewModels
{
    /// <summary>
    /// Scout class.
    /// </summary>
    /// <remarks>
    /// Note that in this sample we are deriving from our own "NotifyPropertyChanged" class
    /// instead of the interface. Since that new class now defines the event itself and the
    /// utility to fire the event, we have removed those items from this class. Also note
    /// that the task of determining if a scout is valid has moved to the view model so we've
    /// also removed the "IsValid" property from this class.
    /// </remarks>
    public class Scout : NotifyPropertyChanged
    {
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
            set { name = value; OnPropertyChanged("Name"); OnPropertyChanged("IsValid"); }
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
    }
}