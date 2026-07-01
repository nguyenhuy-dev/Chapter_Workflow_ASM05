namespace MangaWorkflow.MauiHybridWebApp.HuyNQ;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage()) { Title = "MangaWorkflow.MauiHybridWebApp.HuyNQ" };
    }
}
