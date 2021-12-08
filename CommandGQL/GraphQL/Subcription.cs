using CommandGQL.Models;

namespace CommandGQL.GraphQL;

public class Subcription
{
    [Subscribe]
    [Topic]
    public Platform OnPlatformAdded([EventMessage] Platform platform)
    {
        return platform;
    }
}
