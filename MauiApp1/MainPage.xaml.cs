using ClassLibrary1;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly Database databaseClient = new();

    public MainPage()
    {
        InitializeComponent();
    }

    public async Task Btn_Clicked(object sender, EventArgs e)
    {
        string userInput = PlaceEntry.Text;

        if (!string.IsNullOrEmpty(userInput))
        {
            var result = await databaseClient.SearchAsync(userInput);

            foreach (var place in result)
            {
                PlaceLabel.Text = place.Naam_2;
            }
        }
    }
}
