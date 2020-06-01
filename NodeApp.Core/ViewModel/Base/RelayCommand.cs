using System;
using System.Windows.Input;

namespace NodeApp.Core
{
    public class RelayCommand : ICommand
    {
        #region Prywatne pola

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Konstruktor

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region Składowe ICommand

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
