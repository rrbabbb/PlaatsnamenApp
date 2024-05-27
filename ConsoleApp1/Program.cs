using System.Text.Json;
using ClassLibrary1;

try
{
    var jsonString = File.ReadAllText("plaatsnamen.json");
    var data = JsonSerializer.Deserialize<Places>(jsonString);
    Database databaseConnection = new();

    if (data != null && data.PlacesDictionary != null)
    {
        foreach (var (_, place) in data.PlacesDictionary)
        {
            // functionaliteit per place in PlacesDictionary
            await databaseConnection.InsertAsync(place);
        }
    }

    Console.WriteLine("Zoek een plaats in Nederland op: ");
    string? input = Console.ReadLine();

    if (!string.IsNullOrEmpty(input))
    {
        foreach (var place in await databaseConnection.SearchAsync(input))
        {
            Console.WriteLine(place);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
