## Graphql with Dotnet


### what we will build

### Schema

1. Platform
   - Id
   - Name
   - LicenceKey
2. Commands
   - id
   - commandLine
   - PlatformID

```sql
select * from <tablename>
```

### Queries and Commands

Queries is getting data.

Commands is for creating data.

### Ingridients

1. .Net 5
2. SQl Server (Docker)
3. Insomnia

### What is Graphql

- Graphql is a query and manipulation languages for APIS.
- Graphql is also the runtime for fulfilling requests.
- Created @ Facebooks to address both over and under fetching
- Opensource . Hosted by Linux Foundation

### Core Concepts (Non .Dotnet Context)

#### Schema

- Describes the Api in full
- Self documenting
- Comprised of Types
-  Must have a Root Query Type

### Types

1. Query
2. Mutation
3. Subcription
4. Object
5. Enumeration
6. Scalar
    - Id
    - Int
    - String
    - Boolean
    - Float

```json
type: Car {
    id: ID!
    make: String!
}
```

### Resolvers

- A resolver returns data for a given field.
- They can resolve to "anythin

### Data Source

1. Database.
2. Microservice
3. Rest Api

### What is wrong with REST

- Nothing
### Some of the thing that Rest does not do so well.

#### Over-Fetching

Rest over-fetches: returns more data than you need. Scaling rest api to return only the data you
want becomes very difficults.

For graphql you get only the data you need.

#### Under-Fetching

You are getting less data than you may need.


### When to use?

#### Graphql Queries.

- interact / real-time
- Mobile Apps
- Complex object Hierarchy
- Complex Queries

#### REST

- Non-interactive
- Microservices
- Simple Object Hierachy

###Graphql in .NET

- Graphql.Net
   - opensource
   - 4 million Nuget Downloads
- Hotchocolate
   - opensource
   - 1 Million Nuget downloads

## Dependency Injection

- Use an interface or base class to abstract the dependency implementation.
- Registration of the dependency is in a Service container (IserviceProvider) in Asp.net usually
    through the configurer services.
- The service ( aka dependecy) is injected into the constructor of the class where it is used.
- The Di framework is responsible for creating an instance of the dependecy and disponsing of it
    (AKA Service Lifetime)

### Services Injected at Startup

0nly the following services can be injected into the statup constructor when using IHostBuider.

- IWebHostEnvironment
- IHostEnvironment
- IConfiguration


### Once the DI and DataContext configured

### Generating Migrations

```bash
dotnet ef migrations add AddPlatformToDB
```

### Isomnia

When we try to run graphql queries in parallel using aliases, We get some errors. This is due to the fact that the DbContext is not multithreaded.

graphql query

```json
query {
  a: platform {
    id
    name
  }
  b: platform {
    id
    name
  }
    c: platform {
    id
    name
  }
}
```

the result

```json
{
  "errors": [
    {
      "message": "Unexpected Execution Error",
      "locations": [
        {
          "line": 10,
          "column": 5
        }
      ],
      "path": [
        "c"
      ]
    },
    {
      "message": "Unexpected Execution Error",
      "locations": [
        {
          "line": 6,
          "column": 3
        }
      ],
      "path": [
        "b"
      ]
    }
  ],
  "data": {
    "a": [
      {
        "id": 1,
        "name": "test"
      }
    ],
    "b": null,
    "c": null
  }
}
```
We can resolve this error by using polled db context.



### Fixing DB Context

1. Change number one is Using Polled Db Context.

```csharp
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(connectionStr));
```

2. Updating the query class to be like this.

This tell the method how to make use of a pooled db contextFactory.

```csharp
public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
    {
        return context.Platforms;
    }
}
```

This brings us to the Service Lifetimes.

### Singleton

 - same for every request.

### Scoped

- created once per client request.

### Transient

- New instance created every time.



### Once you add another relatioship .

We need to decolate the query with **UseProjection** to be able to load nested relatioships. You
have to walk the graph to pull back any child object.



### Approaches

#### Annotation Vs Code First Approaches

#### Annotation

- What we have use so far.
- Use "clean" C# code / pure .Net types.
- Annotate with attribute.


### GraphQl Subcription
