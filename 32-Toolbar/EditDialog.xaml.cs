using System.Windows;

namespace Toolbar
{
    /// <summary>
    /// Edit window class definition.
    /// </summary>
    public partial class EditDialog : Window
    {
        /// <summary>
        /// The original scout that was selected to edit.
        /// </summary>
        public Scout Scout { get; }

        /// <summary>
        /// The copy of the scout (data context) that will be bound to the window elements.
        /// </summary>
        public Scout ScoutProxy => (Scout)DataContext;

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
        /// Click event handler for the "Ok" button saves the changes and closes the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object containing the event data.</param>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            Scout.Name = ScoutProxy.Name;
            Scout.Sold = ScoutProxy.Sold;
            Scout.GradeLevel = ScoutProxy.GradeLevel;
            DialogResult = true;
        }
    }
}
