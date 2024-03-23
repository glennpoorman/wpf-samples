using System.ComponentModel;

namespace ViewModels
{
    /// <summary>
    /// Base class for any class that needs to implement "INotifyPropertyChanged"
    /// </summary>
    /// <remarks>
    /// In this sample we have more than once class that needs to implement "INotifyPropertyChanged"
    /// so we're creating a base class that contains the "PropertyChanged" event and the utility
    /// method to fire the event.
    /// </remarks>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Utility used to fire off a property changed event.
        /// </summary>
        /// <param name="property">The name of the property that has changed.</param>
        protected void OnPropertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}