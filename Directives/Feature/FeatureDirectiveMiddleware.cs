using HC14_Bug.Services;
using HotChocolate.Resolvers;

namespace HC14_Bug.Directives.Feature;

public class FeatureDirectiveMiddleware(FieldDelegate next, Directive directive)
{
    public async Task InvokeAsync(IMiddlewareContext context, IFeatureProvider featureProvider)
    {
        var name = directive.GetArgumentValue<string>("name");

        if (!featureProvider.FeatureIsEnabled(name)) {
            context.ReportError($"The feature \"{name}\", is required for use of this field or operation");
            context.Result = null;
        }

        await next(context);
    }
}
