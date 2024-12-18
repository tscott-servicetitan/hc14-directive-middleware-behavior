using HC14_Bug.Directives.Feature;
using HC14_Bug.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFeatureProvider, FeatureProvider>();
builder
    .AddGraphQL()
    .AddHC14_BugTypes()
    .AddDirectiveType<FeatureDirectiveType>();


var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
