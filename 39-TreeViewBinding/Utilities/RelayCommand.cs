using System;
using System.Windows.Input;

namespace TreeViewBinding.Utilities
{
    /// <summary>
    /// Custom command class definition.
    /// </summary>
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
        public RelayCommand(Action<object> execute) => this.execute = execute;

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
        public bool CanExecute(object parameter) =>
            (canExecute == null) ? true : canExecute(parameter); 

        /// <summary>
        /// Called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object parameter) => execute?.Invoke(parameter);

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
