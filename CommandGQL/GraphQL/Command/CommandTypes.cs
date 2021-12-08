using CommandGQL.Data;
using CommandGQL.Models;

namespace CommandGQL.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Representes any executable commands");
        descriptor.Field(c => c.Platform)
          .ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!)).
          UseDbContext<AppDbContext>()
          .Description("This is the platform to which the command belongs");

    }

    private class Resolvers
    {
        public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.platformId);
        }
    }
}
