using MVVM.ViewModels;
using System.Windows.Controls;

namespace MVVM.Views
{
    /// <summary>
    /// Scout view class definition.
    /// </summary>
    public partial class ScoutView : UserControl
    {
        /// <summary>
        /// The scout view model.
        /// </summary>
        /// <remarks>
        /// Note that this property now has both "set" and "get" accessors. The view model is no
        /// longer a static resource but is now set when the view comes to life. That is because
        /// the view models for the scouts are now managed external to this control.
        /// </remarks>
        public ScoutViewModel ViewModel
        {
            get => (ScoutViewModel)DataContext;
            set { DataContext = value; }
        }

        /// <summary>
        /// Scout view constructor.
        /// </summary>
        public ScoutView()
        {
            InitializeComponent();
        }
    }
}
