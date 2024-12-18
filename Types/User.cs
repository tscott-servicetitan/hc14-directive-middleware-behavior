using HC14_Bug.Directives.Feature;

namespace HC14_Bug.Types;

public class User
{
    [GraphQLType<NonNullType<IdType>>]
    public long Id { get; set; }

    [FeatureDirective("Bar")]
    public string? Name { get; set; }
}
