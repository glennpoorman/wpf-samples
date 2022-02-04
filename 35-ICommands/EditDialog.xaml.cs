using System.Windows;
using System.Windows.Input;

namespace ICommands
{
    /// <summary>
    /// Edit window class definition.
    /// </summary>
    public partial class EditDialog : Window
    {
        /// <summary>
        /// The original scout that was selected to edit.
        /// </summary>
        public Scout Scout { get; private set; }

        // Property returns the scout proxy used as the data context.
        //
        public Scout ScoutProxy { get; private set; }

        /// <summary>
        /// Command saves changes to the originally selected scout and closes the edit session.
        /// </summary>
        public ICommand Ok { get; private set; }

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

            // Since the window itself will be its own data context, we need to create the scout
            // proxy right here in the code copy the fields from the original scout. Like previous
            // samples, if the user selects "Ok", any changes to the proxy will be copied back to
            // the original scout on exit.
            //
            ScoutProxy = new Scout()
            {
                Name = Scout.Name,
                Sold = Scout.Sold,
                GradeLevel = Scout.GradeLevel
            };

            // Set this window to be its own data context.
            //
            DataContext = this;

            // Create the "Ok" command using our custom "RelayCommand" class. The execute event
            // handling code copies the data from the scout proxy back into the original scout and
            // then closes the dialog. The event handling code to make sure we can execute simply
            // checks that the data currently in the scout proxy object is valid.
            //
            Ok = new RelayCommand(
                (p) =>
                {
                    Scout.Name = ScoutProxy.Name;
                    Scout.Sold = ScoutProxy.Sold;
                    Scout.GradeLevel = ScoutProxy.GradeLevel;
                    DialogResult = true;
                },
                (p) => ScoutProxy.IsValid
            );
        }
    }
}
