namespace MealTrackerApi.MealAPI
{
    public class Meal
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Calories { get; set; }
        public required DateTime Date { get; set; }
    }
}
