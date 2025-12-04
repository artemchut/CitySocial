namespace CitySocial;
public partial class AddEvent : ContentPage
{
    public AddEvent()
    {
        InitializeComponent();
    }
    private async void homePage(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
