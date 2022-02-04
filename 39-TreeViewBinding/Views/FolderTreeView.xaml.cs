using System.Windows.Controls;
using TreeViewBinding.ViewModels;

namespace TreeViewBinding.Views
{
    /// <summary>
    /// Interaction logic for FolderTreeView.xaml
    /// </summary>
    public partial class FolderTreeView : UserControl
    {
        /// <summary>
        /// The folder tree view model.
        /// </summary>
        public FolderTreeViewModel ViewModel
        {
            get => (FolderTreeViewModel)DataContext;
        }

        /// <summary>
        /// Folder tree view constructor.
        /// </summary>
        public FolderTreeView()
        {
            InitializeComponent();
        }
    }
}
