using FileIcons.Utilities;
using System.IO;

namespace FileIcons.ViewModels
{
    /// <summary>
    /// Base view model class.
    /// </summary>
    public class BaseViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The full path name of the item.
        /// </summary>
        private string fullName;

        /// <summary>
        /// The full path name of the item.
        /// </summary>
        public string FullName
        {
            get => fullName;
            set { fullName = value; OnPropertyChanged("FullName"); OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// The filename only portion of the path name.
        /// </summary>
        public string Name { get => Path.GetFileName(FullName); }

        /// <summary>
        /// Whether or not the current item is expanded in the browser.
        /// </summary>
        private bool isOpen;

        /// <summary>
        /// Whether or not the current item is expanded in the browser.
        /// </summary>
        /// <remarks>
        /// Note that this is only applicable to folders.
        /// </remarks>
        public bool IsOpen
        {
            get => isOpen;
            set { isOpen = value; OnPropertyChanged("IsOpen"); }
        }

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="fullName">The full pathname of the item.</param>
        public BaseViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}
