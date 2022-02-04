using System.Windows;
using System.Windows.Input;

namespace CommandsCode
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

            // Add the command binding for the "Ok" command. Like the XAML sample, the command
            // binding takes an event handler to execute the command as well as an event handler to
            // make sure the command can execute. Here since our event handlers are relatively lean,
            // we can use lambda expressions to embed the code right into the call to create the
            // binding.
            //
            CommandBindings.Add(
                new CommandBinding(CustomCommands.Ok,
                    (s, e) =>
                    {
                        Scout.Name = ScoutProxy.Name;
                        Scout.Sold = ScoutProxy.Sold;
                        Scout.GradeLevel = ScoutProxy.GradeLevel;
                        DialogResult = true;
                    },
                    (s, e) =>
                    {
                        e.CanExecute = ScoutProxy.IsValid;
                    }
                )
            );

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
    }
}
