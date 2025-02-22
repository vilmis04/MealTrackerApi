using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MealTrackerApi.MealAPI;

public class MealContext : DbContext
{
    public MealContext(DbContextOptions<MealContext> options)
        : base(options)
    {
    }

    public DbSet<MealTrackerApi.MealAPI.Meal> Meal { get; set; } = default!;
}
