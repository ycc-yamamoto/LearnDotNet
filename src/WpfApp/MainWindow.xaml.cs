﻿namespace WpfApp;

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
}