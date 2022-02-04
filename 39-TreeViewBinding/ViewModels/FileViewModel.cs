using System.IO;
using TreeViewBinding.Utilities;

namespace TreeViewBinding.ViewModels
{
    /// <summary>
    /// File/base view model class.
    /// </summary>
    /// <remarks>
    /// Operating under the assumption that all folders are files but all files are not folders,
    /// this class serves as the view model for files but also serves as the base view model for
    /// everything else (i.e. folders too).
    /// </remarks>
    public class FileViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The full path name of the file.
        /// </summary>
        private string fullName;

        /// <summary>
        /// The full path name of the file.
        /// </summary>
        public string FullName
        {
            get => fullName;
            set { fullName = value;  OnPropertyChanged("Name"); }
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
        /// <param name="fullName">The full pathname of the file.</param>
        public FileViewModel(string fullName)
        {
            FullName = fullName;
        }
    }
}
