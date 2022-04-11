using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TreeViewBinding.Utilities;

namespace TreeViewBinding.ViewModels
{
    /// <summary>
    /// Delegate for folder browsing.
    /// </summary>
    /// <param name="selectedPath">The currently selected path (in/out).</param>
    /// <returns>True if a folder was selected. False if cancelled.</returns>
    /// <remarks>
    /// Note that the pre-defined "Action" and "Func" delegates don't work for methods that take
    /// "out" or "ref" parameters so we had to define our own. Also note that when using such a
    /// delegate, lambda expressions don't work.
    /// </remarks>
    public delegate bool BrowseDelegate(ref string selectedPath);

    /// <summary>
    /// Main view model for the entire folder tree.
    /// </summary>
    public class FolderTreeViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// Currently selected path to browse.
        /// </summary>
        private string currentPath;

        /// <summary>
        /// Currently selected path to browse.
        /// </summary>
        /// <remarks>
        /// Note that as soon as the path is set, we fire off a property changed notification and
        /// immediately rebuild the child list.
        /// </remarks>
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                OnPropertyChanged("CurrentPath");
                RebuildChildList();
            }
        }

        /// <summary>
        /// Collection of child view models (files/folders).
        /// </summary>
        public ObservableCollection<FileViewModel> Children { get; private set; }

        /// <summary>
        /// Command puts up UI to browse for a folder.
        /// </summary>
        public ICommand Browse { get; private set; }

        /// <summary>
        /// Command displays information about this application.
        /// </summary>
        public ICommand About { get; private set; }

        /// <summary>
        /// Command shuts down the application.
        /// </summary>
        public ICommand Exit { get; private set; }

        /// <summary>
        /// Event will be fired requesting that UI be presented for browsing a folder.
        /// </summary>
        public event BrowseDelegate BrowseRequested;

        /// <summary>
        /// Event will be fired requesting that the UI display application information.
        /// </summary>
        public event Action AboutRequested;

        /// <summary>
        /// Event will be fired requesting the application to close.
        /// </summary>
        public event Action CloseRequested;

        /// <summary>
        /// View model constructor.
        /// </summary>
        public FolderTreeViewModel()
        {
            // Create the child collection for all files and sub-folders within the selected folder.
            //
            this.Children = new ObservableCollection<FileViewModel>();

            // Create the "Browse" command. The handler code fires an event requesting that UI be
            // be presented to allow for browsing a folder and returns the resulting selection.
            //
            this.Browse = new RelayCommand(
                (p) =>
                {
                    string selectedPath = CurrentPath;
                    if (BrowseRequested?.Invoke(ref selectedPath) == true)
                    {
                        CurrentPath = selectedPath;
                    }
                }
            );

            // Create the "About" command. The handler code fires an event that application info
            // was requested and allows the event handlers to display this information accordingly.
            //
            this.About = new RelayCommand((p) => { AboutRequested?.Invoke(); });

            // Create the "Exit" command. The handler code fires an event that a close was
            // requested and allows the event handlers to shut down the application accordingly.
            //
            this.Exit = new RelayCommand((p) => { CloseRequested?.Invoke(); });
        }

        /// <summary>
        /// Rebuilds the child tree based on the currently selected path.
        /// </summary>
        private void RebuildChildList()
        {
            // Put up a wait cursor as high level folder could take a while.
            //
            using (WaitCursor waitCursor = new())
            {
                // Clear out the old child list.
                //
                Children.Clear();

                // Create a single folder view model representing the selected path. The rest of
                // the traversal will happen inside of any child folders that we come upon.
                //
                // Note that by default, the folders will all be closed in the tree display. We
                // want the very top folder to be opened/expanded though so we set "IsOpen" to true
                // which will cause the top node in the tree view to appear expanded.
                //
                Children.Add(new FolderViewModel(CurrentPath) { IsOpen = true });
            }
        }
    }
}
