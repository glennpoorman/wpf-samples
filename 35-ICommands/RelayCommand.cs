using System;
using System.Windows.Input;

namespace ICommands
{
    /// <summary>
    /// Custom command class definition.
    /// </summary>
    /// <remarks>
    /// This class (including the class name) was almost entirely lifted from Josh Smith's article
    /// on the MVVM design pattern. In previous samples, we used WPF routed commands to assign
    /// commands to our UI elements. This isn't a requirement though. The only requirement for
    /// commands to work is that whatever you specify as the command must implement the "ICommand"
    /// interface. We can make our own command class that implements "ICommand" and can be instanced
    /// and bound to directly instead of having to create a command object and then create a command
    /// binding object.
    /// </remarks>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The delegate called to execute the command.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// The delegate called to see if the command can be executed.
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// Command constructor.
        /// </summary>
        /// <param name="execute">The delegate to be called when the command executes.</param>
        /// <remarks>
        /// Leaving the "CanExecute" delegate null means that it is always ok to execute this command.
        /// </remarks>
        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        /// <summary>
        /// Command constructor.
        /// </summary>
        /// <param name="execute">The delegate to be called when the command executes.</param>
        /// <param name="canExecute">The delegate to call to see if the command can be executed.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns>True if this command can be executed; otherwise false.</returns>
        public bool CanExecute(object parameter)
        {
            return (canExecute == null) ? true : canExecute(parameter);
        }

        /// <summary>
        /// Called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <remarks>
        /// This particular item is a little black magic that pinched off the web and appears to be
        /// very common in command discussions. WPF routed commands, as we've seen already, are
        /// really good at automatically enabling/disabling the UI elements hooked to them when the
        /// state of whether or not they can execute changes. When you implement your own commands
        /// though, this essentially stops working as WPF doesn't know about your commands. By
        /// overriding this event and simply implementing the subscribe and unsubscribe handlers up
        /// to the CommandManager "RequerySuggested" event, all of that enabling and disabling comes
        /// back to life.
        /// </remarks>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
