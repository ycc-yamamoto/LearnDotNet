namespace WpfApp;

public abstract class WindowsViewModelBase : ViewModelBase
{
    private readonly double initialTop;
    
    private readonly double initialLeft;
    
    private readonly double initialWidth;
    
    private readonly double initialHeight;
    
    private string title;

    private double top;
    
    private double left;
    
    private double width;
    
    private double height;

    private bool isBusy;
    
    protected WindowsViewModelBase(string title, double top, double left, double width, double height)
    {
        this.title = title;
        this.top = top;
        this.left = left;
        this.width = width;
        this.height = height;
        this.initialTop = top;
        this.initialLeft = left;
        this.initialWidth = width;
        this.initialHeight = height;
        this.InitializeCommand = new DelegateCommand(this.Initialize);
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
    
    public double Width
    {
        get => this.width;
        set => this.SetField(ref this.width, value);
    }
    
    public double Height
    {
        get => this.height;
        set => this.SetField(ref this.height, value);
    }
    
    public bool IsBusy
    {
        get => this.isBusy;
        set => this.SetField(ref this.isBusy, value);
    }
    
    public DelegateCommand InitializeCommand { get; }
    
    protected virtual void Initialize()
    {
        this.Top = this.initialTop;
        this.Left = this.initialLeft;
        this.Width = this.initialWidth;
        this.Height = this.initialHeight;
    }
}