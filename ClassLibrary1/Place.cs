namespace ClassLibrary1;

public class Place
{
    public int ID { get; set; }
    public string? Woonplaatsen { get; set; }
    public string? Woonplaatscode_1 { get; set; }
    public string? Naam_2 { get; set; }
    public string? Code_3 { get; set; }
    public string? Naam_4 { get; set; }
    public string? Code_5 { get; set; }
    public string? Naam_6 { get; set; }
    public string? Code_7 { get; set; }

    public override string ToString() => $"{Naam_2} {Naam_4}";
}
