using Microsoft.Maui.Controls.Shapes;

namespace CitySocial;
public partial class AddEvent : ContentPage
{
    HorizontalStackLayout images;
    int numImages=0;
    public AddEvent()
    {
        InitializeComponent();
        images = new HorizontalStackLayout
        {
            Spacing = 12,
            HorizontalOptions=LayoutOptions.Center
        };
    }

    // NAVIGATION
    private async void homePage(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    // Inputs design
    private void TitleEntry(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(titleEntry.Text))
            titleLabel.Text = "Title";
        else
            titleLabel.Text = "";
    }

    private void LocationEntry(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(locationEntry.Text))
            locationLabel.Text = "Title";
        else
            locationLabel.Text = "";
    }

    // UPLOADING PHOTOS
    private async void UploadPhoto(object sender, TappedEventArgs e)
    {
        var addMoreImages=new Border
        {
            WidthRequest = UploadContainer.Width/4,
            HeightRequest = UploadContainer.Height-20,
            BackgroundColor=Color.FromArgb("#c9ecf9"),
            Stroke=Brush.Transparent,
            StrokeShape=new RoundRectangle{CornerRadius=12}
        };
        var addMoreImagesLabel=new Label
        {
            Text="Add image",
            VerticalTextAlignment=TextAlignment.Center,
            HorizontalTextAlignment=TextAlignment.Center  
        };
        addMoreImages.Content=addMoreImagesLabel;

        if (numImages < 3)
        {
            var options = new PickOptions
            {
                PickerTitle = "Select images",
                FileTypes = FilePickerFileType.Images
            };

            var file = await FilePicker.PickAsync(options);

            if (file == null)
            {
                return;   
            }

            var stream = await file.OpenReadAsync();

            var roundedImage=new Border
            {
                WidthRequest = UploadContainer.Width/4,
                HeightRequest = UploadContainer.Height-20,
                Stroke=Brush.Transparent,
                StrokeShape=new RoundRectangle{CornerRadius=12}
            };
            var image = new Image
            {
                Source = ImageSource.FromStream(() => stream),
                Aspect = Aspect.Fill
            };
            roundedImage.Content=image;

            numImages++;
            if (numImages == 1)
            {
                images.Children.Add(roundedImage);
                images.Children.Add(addMoreImages);
            }
            else if (numImages == 2)
            {
                images.Children.RemoveAt(images.Children.Count-1);
                images.Children.Add(roundedImage);
                images.Children.Add(addMoreImages);
            }
            else if (numImages == 3)
            {
                images.Children.RemoveAt(images.Children.Count-1);
                images.Children.Add(roundedImage);
            }   
        }

        UploadContainer.Padding=new Thickness(24,12);
        UploadContainer.Content = images;
    }            
}
