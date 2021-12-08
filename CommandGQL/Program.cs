using CommandGQL.Data;
using CommandGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommandGQl.Graphql.Platforms;
using CommandGQL.GraphQL.Commands;

var builder = WebApplication.CreateBuilder(args);
var connectionStr = builder.Configuration.GetConnectionString("CommandConStr");

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(connectionStr));
builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .AddSubscriptionType<Subcription>()
  .AddType<PlatformType>()
  .AddType<CommandType>()
  .AddFiltering()
  .AddSorting()
  .AddInMemorySubscriptions();



var app = builder.Build();
/* using (var scope = app.Services.CreateScope()) */
/* { */
/*     var dbContext = scope.ServiceProvider.<AppDbContext>(); */
/*     dbContext.Database.Migrate(); */
/* } */



app.UseRouting();
app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
}, path: "/graphql-voyage");


app.Run();
