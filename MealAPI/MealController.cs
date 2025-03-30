using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealTrackerApi.Data;

namespace MealTrackerApi.MealAPI
{
    [Route("api/meal")]
    [ApiController]
    public class MealController(MealContext context) : ControllerBase
    {
        private readonly MealContext _context = context;

        // GET: api/Meal
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Meal>>> GetMeal()*/
        public IEnumerable<Meal> GetMeal()
        {
            IEnumerable<Meal> meals = [
                new Meal { Id = "1", Name = "Burger", Calories = "500", Date = DateTime.UtcNow },
                new Meal { Id = "2", Name = "Fries", Calories = "300", Date = DateTime.UtcNow },
                new Meal { Id = "3", Name = "Cola", Calories = "450", Date = DateTime.UtcNow },
                new Meal { Id = "4", Name = "Sauce", Calories = "800", Date = DateTime.UtcNow },
            ];


            return meals;
            /*return await _context.Meal.ToListAsync();*/
        }

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public ActionResult<Meal> GetMeal(string id)
        {
            // var meal = await _context.Meal.FindAsync(id);
            var meal = new Meal { Id = "1", Name = "Burger", Calories = "500", Date = DateTime.UtcNow };

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // PUT: api/Meal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(string id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Meal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.Meal.Add(meal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MealExists(meal.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeal", new { id = meal.Id }, meal);
        }

        // DELETE: api/Meal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(string id)
        {
            var meal = await _context.Meal.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Meal.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealExists(string id)
        {
            return _context.Meal.Any(e => e.Id == id);
        }
    }
}
