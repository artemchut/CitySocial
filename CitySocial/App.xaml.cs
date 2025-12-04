namespace CitySocial;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddEvent), typeof(AddEvent));
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
