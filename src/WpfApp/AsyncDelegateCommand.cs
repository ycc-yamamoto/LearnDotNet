using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp;

public class AsyncDelegateCommand : ICommand
{
    private readonly Func<bool>? canExecute;
    
    private Func<Task>? action;
    
    public AsyncDelegateCommand(Func<Task>? action, Func<bool>? canExecute = default)
    {
        this.action = action;
        this.canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;
    
    public bool CanExecute(object? parameter)
    {
        return this.canExecute?.Invoke() ?? true;
    }

    public async void Execute(object? parameter)
    {
        if (this.action is not null)
        {
            await this.action().ConfigureAwait(true);
        }
    }
    
    public void OnCanExecuteChanged()
    {
        this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}