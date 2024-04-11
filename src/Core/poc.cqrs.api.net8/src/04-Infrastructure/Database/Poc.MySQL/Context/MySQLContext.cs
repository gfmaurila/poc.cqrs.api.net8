using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poc.Domain.Entities.MKT.Post;
using Poc.MySQL.Mappings;

namespace Poc.MySQL.Context;

public class MySQLContext : DbContext
{
    public MySQLContext()
    { }

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    { }

    public virtual DbSet<PostEntity> Post { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
