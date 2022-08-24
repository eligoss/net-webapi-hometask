using Microsoft.EntityFrameworkCore;
using WebApi.HomeTask.Dal.Config;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal;

public class RestaurantDbContext : DbContext
{
    /// <summary>
    ///     Gets or sets the restaurants locations.
    /// </summary>
    public virtual DbSet<LocationEntity> Locations { get; set; }

    /// <summary>
    ///     Gets or sets the restaurants reservations.
    /// </summary>
    public virtual DbSet<ReservationEntity> Reservations { get; set; }

    /// <summary>
    ///     Gets or sets the restaurants.
    /// </summary>
    public virtual DbSet<RestaurantEntity> Restaurants { get; set; }

    /// <summary>
    ///     Gets or sets the restaurant table summaries.
    /// </summary>
    public virtual DbSet<RestaurantTablesSummaryEntity> TablesSummaries { get; set; }

    /// <summary>
    ///     Gets or sets the restaurants tables.
    /// </summary>
    public virtual DbSet<TableEntity> Tables { get; set; }

    /// <summary>
    ///     Gets or sets the table sizes.
    /// </summary>
    public virtual DbSet<TableSizeEntity> TableSizes { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RestaurantDbContext"/> class.
    /// </summary>
    public RestaurantDbContext()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RestaurantDbContext"/> class.
    /// </summary>
    /// <param name="options">DbContext Options</param>
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {
    }

    /// <summary>
    ///     OnModelCreating event.
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder <see cref="ModelBuilder"/></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LocationEntityConfig());
        modelBuilder.ApplyConfiguration(new ReservationEntityConfig());
        modelBuilder.ApplyConfiguration(new RestaurantEntityConfig());
        modelBuilder.ApplyConfiguration(new RestaurantTablesSummaryEntityConfig());
        modelBuilder.ApplyConfiguration(new TableEntityConfig());
        modelBuilder.ApplyConfiguration(new TableSizeEntityConfig());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=tcp:webaspi-hometask-db-server.database.windows.net,1433;Initial Catalog=webapi-hometask-db;Persist Security Info=False;User ID=devtest;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}