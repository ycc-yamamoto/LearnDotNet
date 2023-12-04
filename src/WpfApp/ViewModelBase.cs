using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp;

public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    public bool IsDisposed { get; protected set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected virtual void DisposeManagedResources()
    {
        // 継承先でマネージドリソースを解放
    }
    
    protected virtual void DisposeUnmanagedResources()
    {
        // 継承先でアンマネージドリソースを解放
    }
    
    private void Dispose(bool disposing)
    {
        if (this.IsDisposed) return;
        
        if (disposing)
        {
            // マネージリソースをここで解放します
            this.DisposeManagedResources();
        }
        
        // アンマネージドリソースをここで解放します
        this.DisposeUnmanagedResources();
        this.IsDisposed = true;
    }
}