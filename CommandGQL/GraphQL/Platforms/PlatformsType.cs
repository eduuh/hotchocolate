using CommandGQL.Data;
using CommandGQL.Models;

namespace CommandGQl.Graphql.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or services that has a Command line interface");

        descriptor.Field(t => t.LicenseKey).Ignore();

        descriptor.Field(p => p.Commands).ResolveWith<Resolvers>(p => p.GetCommands(default!, default!)).UseDbContext<AppDbContext>().Description("This is the list of available command for this platform");
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
        {
            return context.Commands.Where(p => p.platformId == platform.Id);
        }
    }

}
