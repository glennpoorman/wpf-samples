using ContextMenus.ViewModels;
using System.Windows;

namespace ContextMenus
{
    /// <summary>
    /// Edit window class definition.
    /// </summary>
    public partial class EditDialog : Window
    {
        /// <summary>
        /// Edit dialog window constructor.
        /// </summary>
        /// <param name="owner">The owning window.</param>
        /// <param name="scout">The view model for the scout selected to edit.</param>
        public EditDialog(Window owner, ScoutViewModel scout)
        {
            InitializeComponent();

            // Set the window owner.
            //
            Owner = owner;

            // Set the data context on the scout view and set the action to take when the view
            // requests that we close.
            //
            scoutView.ViewModel = scout;
            scoutView.ViewModel.CloseRequested += CloseDialog;
        }

        /// <summary>
        /// Called when the view requests that this dialog be closed.
        /// </summary>
        /// <param name="result">True if changes were accepted. Otherwise false.</param>
        private void CloseDialog(bool result)
        {
            // Set the dialog result instructing the window to close.
            //
            DialogResult = result;

            // Remove this handler from the scout view model.
            //
            scoutView.ViewModel.CloseRequested -= CloseDialog;
        }
    }
}
