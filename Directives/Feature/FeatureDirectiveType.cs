using HC14_Bug.Services;

namespace HC14_Bug.Directives.Feature;

public record FeatureDirective(string Name);

public class FeatureDirectiveType : DirectiveType<FeatureDirective>
{
    protected override void Configure(IDirectiveTypeDescriptor<FeatureDirective> descriptor)
    {
        descriptor.Name("feature");
        descriptor.Repeatable();
        descriptor.Location(DirectiveLocation.FieldDefinition | DirectiveLocation.InputFieldDefinition);

        descriptor.Argument(x => x.Name).Type<NonNullType<StringType>>();

        // ===============================================================================
        // UNCOMMENT BELOW TO OBSERVE BEHAVIOR WHEN MIDDLEWARE IS DEFINED AS A CLASS (This DOES NOT work)
        // ===============================================================================

        // descriptor.Use<FeatureDirectiveMiddleware>();

        // ===============================================================================
        // UNCOMMENT BELOW TO OBSERVE BEHAVIOR WHEN MIDDLEWARE IS DEFINED AS AN EXPRESSION (This works)
        // ===============================================================================

        // descriptor.Use((next, directive) => context =>
        // {
        //     var featureProvider = context.Services.GetRequiredService<IFeatureProvider>();
        //     var name = directive.GetArgumentValue<string>("name");
        //
        //     if (!featureProvider.FeatureIsEnabled(name))
        //     {
        //         context.ReportError($"The feature '{name}', is required for use of this field or operation");
        //         context.Result = null;
        //     }
        //
        //     return next.Invoke(context);
        // });


        // ===============
        // This also works
        // ================

        // descriptor.Use((next, directive) => new FeatureDirectiveMiddleware(next, directive).Invoke);
    }
}
