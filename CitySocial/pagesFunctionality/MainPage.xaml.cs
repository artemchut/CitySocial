using System.Collections.ObjectModel;

namespace CitySocial;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Event> events { get; set; }

    public record Event(string imageSource, string mainText);

    public MainPage()
    {
        InitializeComponent();

        events = new ObservableCollection<Event>
        {
            new Event("dotnet_bot.png", "House party"),
            new Event("home.png", "Rave"),
            new Event("add.png", "Metallica concert"),
            new Event("profile.png", "Gay marriage")
        };

        BindingContext = this;
    }
    private async void addEvent(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new AddEvent());
    }
}
