using HC14_Bug.Directives.Feature;

namespace HC14_Bug.Types;

[QueryType]
public class Query
{
    [FeatureDirective("Foo")]
    public User Me()
    {
        return new User { Id = 1, Name = "John Doe" };
    }
}
