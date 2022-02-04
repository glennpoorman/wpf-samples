using System.Collections.ObjectModel;
using System.IO;

namespace FileIcons.ViewModels
{
    /// <summary>
    /// Folder view model class.
    /// </summary>
    public class FolderViewModel : BaseViewModel
    {
        /// <summary>
        /// Collection of child view models (files/folders).
        /// </summary>
        public ObservableCollection<BaseViewModel> Children { get; private set; }

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="fullName">The full pathname of the folder.</param>
        public FolderViewModel(string fullName) : base(fullName)
        {
            // Create the child collection for all files and sub-folders within this folder.
            //
            this.Children = new ObservableCollection<BaseViewModel>();

            // Fetch all of the sub-folders within this folder. Create a view model for each one
            // and add that view model to the collection.
            //
            // Note that calling "GetDirectories" can throw all manner of exceptions for things
            // like not having access to certain folders, etc. Here we'll just blindly catch and
            // ignore all exceptions essentially bypassing the bad folders.
            //
            try
            {
                string[] folders = Directory.GetDirectories(FullName);
                foreach (string folder in folders)
                {
                    Children.Add(new FolderViewModel(folder));
                }
            }
            catch
            { }

            // Fetch all of the files within this folder. Create a view model for each one and add
            // that view model to the collection.
            //
            // Note that calling "GetFiles" can throw all manner of exceptions for things like not
            // having access to certain files, etc. Here we'll just blindly catch and ignore all
            // exceptions essentially bypassing the bad folders.
            //
            try
            {
                string[] files = Directory.GetFiles(FullName);
                foreach (string file in files)
                {
                    Children.Add(new FileViewModel(file));
                }
            }
            catch
            { }
        }
    }
}
