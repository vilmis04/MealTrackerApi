using Microsoft.EntityFrameworkCore;
using MealTrackerApi.MealAPI;

namespace MealTrackerApi.Data
{
    public class MealContext : DbContext
    {
        public MealContext(DbContextOptions<MealContext> options)
            : base(options)
        {
        }

        public DbSet<Meal> Meal { get; set; } = default!;
    }
}
