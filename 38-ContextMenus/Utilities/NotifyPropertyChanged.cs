using System.ComponentModel;

namespace ContextMenus.Utilities
{
    /// <summary>
    /// Base class for any class that needs to implement "INotifyPropertyChanged"
    /// </summary>
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