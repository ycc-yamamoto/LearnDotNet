namespace WpfApp;

public sealed class MainViewModel : ViewModelBase
{
    private string title;

    private double top;
    
    private double left;

    public MainViewModel()
    {
        this.title = "サンプルWPFアプリ";
        this.top = 100;
        this.left = 100;
    }
    
    public string Title
    {
        get => this.title;
        set => this.SetField(ref this.title, value);
    }
    
    public double Top
    {
        get => this.top;
        set => this.SetField(ref this.top, value);
    }
    
    public double Left
    {
        get => this.left;
        set => this.SetField(ref this.left, value);
    }
}