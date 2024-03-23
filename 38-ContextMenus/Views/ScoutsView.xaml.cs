using ContextMenus.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace ContextMenus.Views
{
    /// <summary>
    /// Interaction logic for ScoutsView.xaml
    /// </summary>
    public partial class ScoutsView : UserControl
    {
        /// <summary>
        /// The scouts view model.
        /// </summary>
        public ScoutsViewModel ViewModel => (ScoutsViewModel)DataContext;

        /// <summary>
        /// Scouts view constructor.
        /// </summary>
        public ScoutsView() => InitializeComponent();

        /// <summary>
        /// Event handler for a mouse double click in the list view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void ListDoubleClick(object sender, MouseButtonEventArgs e) =>
            ViewModel.EditScout.Execute(null);
    }
}
