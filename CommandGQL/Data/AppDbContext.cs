using CommandGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandGQL.Data;

public class AppDbContext : DbContext
{
    private IConfiguration _configuration;
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Platform> Platforms { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CommandConStr"));
    }
}
