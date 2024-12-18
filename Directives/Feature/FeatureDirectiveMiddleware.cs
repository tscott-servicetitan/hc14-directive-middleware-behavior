using HC14_Bug.Services;
using HotChocolate.Resolvers;

namespace HC14_Bug.Directives.Feature;

public class FeatureDirectiveMiddleware(FieldDelegate next, Directive directive)
{
    public ValueTask Invoke(IMiddlewareContext context)
    {
        var featureProvider = context.Services.GetRequiredService<IFeatureProvider>();
        var name = directive.GetArgumentValue<string>("name");

        if (!featureProvider.FeatureIsEnabled(name)) {
            context.ReportError($"The feature \"{name}\", is required for use of this field or operation");
            context.Result = null;
        }

        return next.Invoke(context);
    }
}
