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
