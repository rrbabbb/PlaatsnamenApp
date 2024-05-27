using MySql.Data.MySqlClient;

namespace ClassLibrary1;

public class Database : IDisposable
{
    private readonly string connectionString = new MySqlConnectionStringBuilder
    {
        UserID = "root",
        Password = "root",
        Port = 3306,
        Server = "localhost",
        Database = "PlaatsnamenApp"
    }.ToString();
    private readonly MySqlConnection connection;

    public Database()
    {
        connection = new(connectionString);
        connection.Open();
    }

    public async Task InsertAsync(Place place)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "insert into Place (ID, Woonplaatsen, Woonplaatscode_1, Naam_2, " +
                                                "Code_3, Naam_4, Code_5, Naam_6, Code_7) " +
                              "values (@ID, @Woonplaatsen, @Woonplaatscode_1, @Naam_2, @Code_3, @Naam_4, @Code_5, @Naam_6, @Code_7)" +
                              "on duplicate key update Woonplaatsen = @Woonplaatsen, Woonplaatscode_1 = @Woonplaatscode_1," +
                              "Naam_2 = @Naam_2, Code_3 = @Code_3, Naam_4 = @Naam_4, Code_5 = @Code_5, Naam_6 = @Naam_6, Code_7 = @Code_7";
        command.Parameters.AddWithValue("@ID", place.ID);
        command.Parameters.AddWithValue("@Woonplaatsen", place.Woonplaatsen);
        command.Parameters.AddWithValue("@Woonplaatscode_1", place.Woonplaatscode_1);
        command.Parameters.AddWithValue("@Naam_2", place.Naam_2);
        command.Parameters.AddWithValue("@Code_3", place.Code_3);
        command.Parameters.AddWithValue("@Naam_4", place.Naam_4);
        command.Parameters.AddWithValue("@Code_5", place.Code_5);
        command.Parameters.AddWithValue("@Naam_6", place.Naam_6);
        command.Parameters.AddWithValue("@Code_7", place.Code_7);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<Place>> SearchAsync(string input)
    {
        var placeList = new List<Place>();

        using var command = connection.CreateCommand();
        command.CommandText = "select distinct Naam_2 from Place where Naam_2 like @input";
        command.Parameters.AddWithValue("@input", input + "%");
        using var reader = command.ExecuteReader();

        while (await reader.ReadAsync())
        {
            placeList.Add(new Place
            {
                Naam_2 = reader.GetString("Naam_2")
            });
        }

        return placeList;
    }

    public void Dispose()
    { 
        connection.Close();
        GC.SuppressFinalize(this);
    }
}
