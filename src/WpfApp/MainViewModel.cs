using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp;

public sealed class MainViewModel : WindowsViewModelBase
{
    private readonly DispatcherTimer timer;
    
    private DateTime currentTime;

    private string heavyProcessButtonText;
    
    public MainViewModel()
        : base($"サンプルWPFアプリ ({RuntimeInformation.FrameworkDescription})", 100, 100, 800, 450)
    {
        this.currentTime = DateTime.Now;
        this.heavyProcessButtonText = "実行開始";
        this.timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1),
        };
        this.timer.Tick += this.OnTimerTick;
        this.timer.Start();
        this.HeavyProcessCommand = new AsyncDelegateCommand(
            async () => await this.DoHeavyProcessAsync(),
            () => !this.IsBusy);
    }
    
    public DateTime CurrentTime
    {
        get => this.currentTime;
        set => this.SetField(ref this.currentTime, value);
    }
    
    public string HeavyProcessButtonText
    {
        get => this.heavyProcessButtonText;
        set => this.SetField(ref this.heavyProcessButtonText, value);
    }
    
    public AsyncDelegateCommand HeavyProcessCommand { get; }

    protected override void DisposeManagedResources()
    {
        base.DisposeManagedResources();
        this.timer.Stop();
        this.timer.Tick -= this.OnTimerTick;
    }

    private async Task DoHeavyProcessAsync()
    {
        try
        {
            this.IsBusy = true;
            this.HeavyProcessButtonText = "実行中...";
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(true);
        }
        finally
        {
            this.HeavyProcessButtonText = "実行開始";
            this.IsBusy = false;
        }
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        this.CurrentTime = this.CurrentTime.AddSeconds(1);
    }
}