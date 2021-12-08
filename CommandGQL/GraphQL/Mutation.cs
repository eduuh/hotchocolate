using CommandGQL.Data;
using CommandGQL.GraphQL.Commands;
using CommandGQL.GraphQL.Platforms;
using CommandGQL.Models;
using HotChocolate.Subscriptions;

namespace CommandGQL.GraphQL;

public class Mutation
{
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
    {
        var platform = new Platform
        {
            Name = input.Name,
        };
        context.Platforms.Add(platform);
        await context.SaveChangesAsync(cancellationToken);

        await eventSender.SendAsync(nameof(Subcription.OnPlatformAdded), platform, cancellationToken);

        return new AddPlatformPayload(platform);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
    {
        var command = new Command
        {
            HowTo = input.HowTo,
            CommandLine = input.CommandLine,
            platformId = input.PlatformId,

        };
        context.Commands.Add(command);
        await context.SaveChangesAsync();
        return new AddCommandPayload(command);
    }
}
