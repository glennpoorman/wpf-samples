using System.Windows;

namespace ViewModels
{
    /// <summary>
    /// Edit window class definition.
    /// </summary>
    public partial class EditDialog : Window
    {
        /// <summary>
        /// The view model used as the data context on the window.
        /// </summary>
        public ScoutViewModel ViewModel
        {
            get => (ScoutViewModel)DataContext;
        }
 
        /// <summary>
        /// Edit dialog window constructor.
        /// </summary>
        /// <param name="owner">The owning window.</param>
        /// <param name="scout">The scout selected to edit.</param>
        public EditDialog(Window owner, Scout scout)
        {
            InitializeComponent();

            // Set the window owner.
            //
            Owner = owner;

            // Set the scout we're editing on the view model.
            //
            ViewModel.Scout = scout;

            // We want to avoid any UI specific code in the view model so the view model fires
            // an event when it wants to close. Here in the window we register a handler for
            // that event that sets "DialogResult" to true essentially closing the window.
            //
            ViewModel.CloseRequested += () =>
            {
                DialogResult = true;
            };
        }
    }
}
