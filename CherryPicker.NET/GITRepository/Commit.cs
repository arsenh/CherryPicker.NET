namespace CherryPicker.NET.GITRepository;

public struct Commit
{
    public string Hash { get; set; }
    public string Email { get; set; }
    public string Author { get; set; }
    public string Message { get; set; }
}
