using System.Windows;

namespace Toolbar
{
    /// <summary>
    /// Edit window class definition.
    /// </summary>
    public partial class EditDialog : Window
    {
        // Note the two "Scout" instance properties below.
        //
        // One of the issues we run into when we start "editing" data is that WPF doesn't provide a
        // way of rolling back changes made to a data context should a user decide to cancel an edit
        // operation. So here we'll set a static instance of "Scout" as the window data context. This
        // static scout instance will act as a proxy initializing itself by copying fields from the
        // originally selected scout, allowing those fields to be edited via data binding, and then
        // only copy the fields back to the original scout if the user selects "Ok" to close the
        // dialog. If "Cancel" is selected, we'll discard the changes in the scout proxy leaving the
        // original scout as it was.

        /// <summary>
        /// The original scout that was selected to edit.
        /// </summary>
        public Scout Scout { get; private set; }

        /// <summary>
        /// The copy of the scout (data context) that will be bound to the window elements.
        /// </summary>
        public Scout ScoutProxy
        {
            get => (Scout)DataContext;
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

            // Set the originally selected scout.
            //
            Scout = scout;

            // Initialize the scout proxy using the properties from the original scout.
            //
            ScoutProxy.Name = Scout.Name;
            ScoutProxy.Sold = Scout.Sold;
            ScoutProxy.GradeLevel = Scout.GradeLevel;
        }

        /// <summary>
        /// Click event handler for the "Ok" button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            // Selecting "Ok" means the user wants to commit any changes made so here we copy the
            // data from the scout proxy (data context) back into the originally selected scout.
            //
            Scout.Name = ScoutProxy.Name;
            Scout.Sold = ScoutProxy.Sold;
            Scout.GradeLevel = ScoutProxy.GradeLevel;

            // Set "DialogResult" to true. This will cause the "ShowDialog" call that originally
            // brought up this window to also return "true".
            //
            // Note also that WPF always checks the "DialogResult" property after any windows event
            // to see if it has changed. If it has, then the window is automatically closed. So in
            // addition to returning true, setting that property also serves to close the window
            // without us having to do it explicitly.
            //
            DialogResult = true;
        }
    }
}
