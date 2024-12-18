namespace HC14_Bug.Services;

public interface IFeatureProvider
{
    public bool FeatureIsEnabled(string name);
}

public class FeatureProvider : IFeatureProvider
{
    private static readonly Dictionary<string, bool> Features = new()
    {
        { "Foo", true },
        { "Bar", false }
    };

    public bool FeatureIsEnabled(string name)
    {
        return Features[name];
    }
}
