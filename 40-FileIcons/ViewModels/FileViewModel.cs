using FileIcons.Utilities;
using System.Windows.Media;

namespace FileIcons.ViewModels
{
    /// <summary>
    /// File view model class.
    /// </summary>
    public class FileViewModel : BaseViewModel
    {
        /// <summary>
        /// The file icon.
        /// </summary>
        private ImageSource fileIcon;

        /// <summary>
        /// The file icon.
        /// </summary>
        public ImageSource FileIcon
        {
            get => fileIcon;
            set { fileIcon = value; OnPropertyChanged("FileIcon"); }
        }

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="fullName">The full pathname of the file.</param>
        public FileViewModel(string fullName) : base(fullName)
        {
            // Use the file image manager to get the file image for this type of file.
            //
            FileIcon = FileImageManager.GetImageSource(fullName);
        }
    }
}
