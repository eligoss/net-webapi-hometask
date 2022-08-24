using Microsoft.EntityFrameworkCore;
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

            if (!context.TableSizes.Any())
            {
                small = new TableSizeEntity
                {
                    Name = "Small",
                    PeopleCount = 2
                };

                medium = new TableSizeEntity
                {
                    Name = "Medium",
                    PeopleCount = 4
                };

                large = new TableSizeEntity
                {
                    Name = "Large",
                    PeopleCount = 8
                };

                context.TableSizes.AddRange(small, medium, large);
                await context.SaveChangesAsync();
            }
            else
            {
                small = await context.TableSizes.FirstAsync(q => q.Name == "Small");
                medium = await context.TableSizes.FirstAsync(q => q.Name == "Medium");
                large = await context.TableSizes.FirstAsync(q => q.Name == "Large");
            }

            RestaurantEntity abc;
            RestaurantEntity def;
            RestaurantEntity ghi;

            // Restaurants
            if (!context.Restaurants.Any())
            {
                abc = new RestaurantEntity
                {
                    Name = "ABC",
                    OpenTimeSpan = new TimeSpan(15, 0, 0),
                    CloseTimeSpan = new TimeSpan(23, 0, 0)
                };

                def = new RestaurantEntity
                {
                    Name = "DEF",
                    OpenTimeSpan = new TimeSpan(16, 0, 0),
                    CloseTimeSpan = new TimeSpan(22, 0, 0)
                };

                ghi = new RestaurantEntity
                {
                    Name = "GHI",
                    OpenTimeSpan = new TimeSpan(17, 0, 0),
                    CloseTimeSpan = new TimeSpan(21, 0, 0)
                };

                context.Restaurants.AddRange(abc, def, ghi);
                await context.SaveChangesAsync();
            }
            else
            {
                abc = context.Restaurants.First(q => q.Name == "ABC");
                def = context.Restaurants.First(q => q.Name == "DEF");
                ghi = context.Restaurants.First(q => q.Name == "GHI");
            }

            // Locations.
            LocationEntity sun;
            LocationEntity moon;
            LocationEntity mars;
            if (!context.Locations.Any())
            {
                sun = new LocationEntity
                {
                    Name = "1334 Sun St",
                    RestaurantId = abc.Id
                };

                moon = new LocationEntity
                {
                    Name = "5345 Moon St",
                    RestaurantId = def.Id
                };

                mars = new LocationEntity
                {
                    Name = "214 Mars St",
                    RestaurantId = ghi.Id
                };

                context.Locations.AddRange(sun, moon, mars);
                await context.SaveChangesAsync();
            }
            else
            {
                sun = context.Locations.First(q => q.RestaurantId == abc.Id);
                moon = context.Locations.First(q => q.RestaurantId == def.Id);
                mars = context.Locations.First(q => q.RestaurantId == ghi.Id);
            }

            // Tables
            if (!context.Tables.Any())
            {
                var absTables = new List<TableEntity>
                {
                    new()
                    {
                        Name = "s1abs",
                        TableSizeId = small.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new()
                    {
                        Name = "s2abs",
                        TableSizeId = small.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new()
                    {
                        Name = "m1abs",
                        TableSizeId = medium.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new()
                    {
                        Name = "m2abs",
                        TableSizeId = medium.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    },
                    new()
                    {
                        Name = "l1abs",
                        TableSizeId = large.Id,
                        RestaurantId = abc.Id,
                        LocationId = sun.Id
                    }
                };

                var defTables = new List<TableEntity>
                {
                    new()
                    {
                        Name = "s1def",
                        TableSizeId = small.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "s2def",
                        TableSizeId = small.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "m1def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "m2def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "m3def",
                        TableSizeId = medium.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "l1def",
                        TableSizeId = large.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    },
                    new()
                    {
                        Name = "l2def",
                        TableSizeId = large.Id,
                        RestaurantId = def.Id,
                        LocationId = moon.Id
                    }
                };

                var ghiTables = new List<TableEntity>
                {
                    new()
                    {
                        Name = "s1ghi",
                        TableSizeId = small.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new()
                    {
                        Name = "m1ghi",
                        TableSizeId = medium.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new()
                    {
                        Name = "m2ghi",
                        TableSizeId = medium.Id,
                        RestaurantId = ghi.Id,
                        LocationId = mars.Id
                    },
                    new()
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

            // TablesSummaries
            if (!context.TablesSummaries.Any())
            {
                var abcSum = new List<RestaurantTablesSummaryEntity>
                {
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = abc.Id,
                        TableSizeId = small.Id,
                        Amount = 2
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = abc.Id,
                        TableSizeId = medium.Id,
                        Amount = 2
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = abc.Id,
                        TableSizeId = large.Id,
                        Amount = 1
                    }
                };

                var defSum = new List<RestaurantTablesSummaryEntity>
                {
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = def.Id,
                        TableSizeId = small.Id,
                        Amount = 2
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = def.Id,
                        TableSizeId = medium.Id,
                        Amount = 3
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = def.Id,
                        TableSizeId = large.Id,
                        Amount = 2
                    }
                };

                var ghiSum = new List<RestaurantTablesSummaryEntity>
                {
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = ghi.Id,
                        TableSizeId = small.Id,
                        Amount = 1
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = ghi.Id,
                        TableSizeId = medium.Id,
                        Amount = 2
                    },
                    new RestaurantTablesSummaryEntity
                    {
                        RestaurantId = ghi.Id,
                        TableSizeId = large.Id,
                        Amount = 1
                    }
                };

                context.TablesSummaries.AddRange(abcSum);
                context.TablesSummaries.AddRange(defSum);
                context.TablesSummaries.AddRange(ghiSum);
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