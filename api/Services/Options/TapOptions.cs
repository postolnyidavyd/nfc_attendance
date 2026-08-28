namespace Services.Options;

public class TapOptions
{
    public const string SectionName = "Tap";

    public int DuplicateWindowMinutes { get; set; } = 5;
}
