using CommandGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandGQL.Data;

public class AppDbContext : DbContext
{
    /* private IConfiguration _configuration; */
    /* /1* public AppDbContext(IConfiguration configuration) *1/ */
    /* /1* { *1/ */
    /* /1*     _configuration = configuration; *1/ */
    /* } */

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Command> Commands { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) */
    /* { */
    /*     optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CommandConStr")); */
    /* } */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Platform>().HasMany(p => p.Commands).WithOne(p => p.Platform).HasForeignKey(c => c.platformId);

        modelBuilder.Entity<Command>().HasOne(p => p.Platform).WithMany(c => c.Commands).HasForeignKey(c => c.platformId);
    }
}
