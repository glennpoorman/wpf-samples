using System.Windows;
using System.Windows.Forms;

namespace TreeViewBinding
{
    /// <summary>
    /// The application main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window class constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Register a handler for when the view model wants to put up UI to browser for a
            // a folder specifying our browser utility (implemented below).
            //
            folderTreeView.ViewModel.BrowseRequested += BrowseFolder;

            // Register a handler for when the view model wants to display application information.
            // The handler code puts up the about dialog.
            //
            folderTreeView.ViewModel.AboutRequested += () => { _ = new AboutDialog(this).ShowDialog(); };

            // Register a handler for when the view model wants to close. The handler code will
            // shut down the application.
            //
            folderTreeView.ViewModel.CloseRequested += () => { Close(); }; 
        }

        /// <summary>
        /// Utility puts up the Windows Forms folder browser dialog allowing the user to select a
        /// specific folder.
        /// </summary>
        /// <param name="currentPath">The currently selected folder (in/out).</param>
        /// <returns>True if a folder was selected. False if cancelled.</returns>
        private bool BrowseFolder(ref string currentPath)
        {
            // Create the Windows Forms folder browser dialog an initialize the selected path.
            //
            FolderBrowserDialog browseDialog = new FolderBrowserDialog() { SelectedPath = currentPath };

            // Put up the browser dialog and return false if the user cancels.
            //
            if (browseDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return false;
            }

            // The user did not cancel. Save the selected path and return true.
            //
            currentPath = browseDialog.SelectedPath;
            return true;
        }
    }
}
