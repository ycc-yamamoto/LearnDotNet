using System;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        this.DataContext = new MainViewModel();
        this.InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        if (this.DataContext is IDisposable disposable)
        {
            disposable.Dispose();
        }
        
        base.OnClosed(e);
    }
}