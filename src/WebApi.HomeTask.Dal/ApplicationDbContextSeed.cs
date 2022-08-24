using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal;

public class ApplicationDbContextSeed
{
    public static async Task SeedBaseData(RestaurantDbContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            TableSizeEntity small = new TableSizeEntity();
            TableSizeEntity medium = new TableSizeEntity();
            TableSizeEntity large = new TableSizeEntity();

            if (!context.Tables.Any())
            {
                small = new TableSizeEntity
                {
                    Size = "Small",
                    PeopleCount = 2
                };

                medium = new TableSizeEntity
                {
                    Size = "Medium",
                    PeopleCount = 4
                };

                large = new TableSizeEntity
                {
                    Size = "Large",
                    PeopleCount = 6
                };

                context.TableSizes.AddRange(small, medium, large);
                await context.SaveChangesAsync();
            }
            else
            {
                small = context.TableSizes.First(q => q.Size == "Small");
                medium = context.TableSizes.First(q => q.Size == "Medium");
                large = context.TableSizes.First(q => q.Size == "Large");
            }

            // Restaurants
            if (!context.Restaurants.Any())
            {
                var abc = new RestaurantEntity
                {
                    Name = "ABC",
                    OpenTimeSpan = new TimeSpan(15, 0, 0),
                    CloseTimeSpan = new TimeSpan(23, 0, 0)
                };

                var def = new RestaurantEntity
                {
                    Name = "DEF",
                    OpenTimeSpan = new TimeSpan(16, 0, 0),
                    CloseTimeSpan = new TimeSpan(22, 0, 0)
                };

                var ghi = new RestaurantEntity
                {
                    Name = "GHI",
                    OpenTimeSpan = new TimeSpan(17, 0, 0),
                    CloseTimeSpan = new TimeSpan(21, 0, 0)
                };

                context.Restaurants.AddRange(abc, def, ghi);
                await context.SaveChangesAsync();

                // Locations.
                var sun = new LocationEntity
                {
                    Name = "1334 Sun St",
                    RestaurantId = abc.Id
                };

                var moon = new LocationEntity
                {
                    Name = "5345 Moon St",
                    RestaurantId = def.Id
                };

                var mars = new LocationEntity
                {
                    Name = "214 Mars St",
                    RestaurantId = ghi.Id
                };

                context.Locations.AddRange(sun, moon, mars);
                await context.SaveChangesAsync();

                // Tables
                var absTables = new List<TableEntity>
                {
                    new TableEntity
                    {
                        Name = "s1abs",
                        TableSizeId = small.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "s2abs",
                        TableSizeId = small.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "m1abs",
                        TableSizeId = medium.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "m2abs",
                        TableSizeId = medium.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "l1abs",
                        TableSizeId = large.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    }
                };

                var defTables = new List<TableEntity>
                {
                    new TableEntity
                    {
                        Name = "s1def",
                        TableSizeId = small.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "s2def",
                        TableSizeId = small.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "m1def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "m2def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "m3def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "l1def",
                        TableSizeId = large.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    },
                    new TableEntity
                    {
                        Name = "l2def",
                        TableSizeId = large.Id,
                        RestaurantId = def.Id,
                        LocationId = sun.Id
                    }
                };

                var ghiTables = new List<TableEntity>
                {
                    new TableEntity
                    {
                        Name = "s1ghi",
                        TableSizeId = small.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new TableEntity
                    {
                        Name = "m1ghi",
                        TableSizeId = medium.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new TableEntity
                    {
                        Name = "m2ghi",
                        TableSizeId = medium.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new TableEntity
                    {
                        Name = "l1ghi",
                        RestaurantId = ghi.Id,
                        TableSizeId = large.Id,
                        LocationId = mars.Id
                    }
                };

                context.Tables.AddRange(absTables);
                context.Tables.AddRange(defTables);
                context.Tables.AddRange(ghiTables);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApplicationDbContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}