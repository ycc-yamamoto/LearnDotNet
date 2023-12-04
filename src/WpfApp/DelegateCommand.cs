using System;
using System.Windows.Input;

namespace WpfApp;

public class DelegateCommand : ICommand
{
    private readonly Action? action;
    
    private readonly Func<bool>? canExecute;
    
    public DelegateCommand(Action? action, Func<bool>? canExecute = default)
    {
        this.action = action;
        this.canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;
    
    public bool CanExecute(object? parameter)
    {
        return this.canExecute?.Invoke() ?? true;
    }

    public void Execute(object? parameter)
    {
        this.action?.Invoke();
    }
}