using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poc.Domain.Entities.User;
using Poc.SQLServer.Mappings;

namespace Poc.SQLServer.Context;

public class EFSqlServerContext : DbContext
{
    public EFSqlServerContext()
    { }

    public EFSqlServerContext(DbContextOptions<EFSqlServerContext> options) : base(options)
    { }

    public virtual DbSet<UserEntity> User { get; set; }
    //public virtual DbSet<EventCore> EventCore { get; set; }

    // Views
    //public virtual DbSet<ViewUserList> ViewUserList { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        //builder.ApplyConfiguration(new EventCoreConfiguration());

        // View
        //builder.ApplyConfiguration(new ViewUserListMap());
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
