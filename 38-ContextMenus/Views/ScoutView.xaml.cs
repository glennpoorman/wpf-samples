using ContextMenus.ViewModels;
using System.Windows.Controls;

namespace ContextMenus.Views
{
    /// <summary>
    /// Scout view class definition.
    /// </summary>
    public partial class ScoutView : UserControl
    {
        /// <summary>
        /// The scout view model.
        /// </summary>
        public ScoutViewModel ViewModel
        {
            get => (ScoutViewModel)DataContext;
            set { DataContext = value; }
        }

        /// <summary>
        /// Scout view constructor.
        /// </summary>
        public ScoutView() => InitializeComponent();
    }
}
