using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinksController : ControllerBase
    {

        private readonly RegContext _context;

        public ColdDrinksController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Colddrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Colddrinks>>> GetColddrinks()
        {
            if (_context.Colddrinks == null)
            {
                return NotFound();
            }
            return await _context.Colddrinks.ToListAsync();

        }


        // GET: api/Colddrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colddrinks>> GetColddrinks(int id)
        {
            if (_context.Colddrinks == null)

            {
                return NotFound();
            }
            var data = await _context.Colddrinks.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Colddrinks/5

        //[HttpPut("{id}")]

        //public async Task<IActionResult> PutFruits(int id, Fruits fruit)
        //{
        //    if (id != fruit.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(fruit).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Menu_CardExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Fruits

        //[HttpPost]
        //public async Task<ActionResult<ColdDrinksController>> PostColddrinks(Models.Colddrinks menu_Card)
        //{
        //    if (_context.Colddrinks == null)
        //    {
        //        return Problem("Entity set 'RegContext.Menu_Card'  is null.");
        //    }
        //    _context.Colddrinks.Add(menu_Card);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMenu_Card", new { id = menu_Card.id }, menu_Card);
        //}

        [HttpPost]
        [Route("postColddrinks")]
        public async Task<IActionResult> PostColdDrinks(Colddrinks item)
        {
            try
            {
                _context.Colddrinks.Add(item);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        // DELETE: api/Colddrinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColddrinks(int id)
        {
            if (_context.Colddrinks == null)
            {
                return NotFound();
            }
            var data = await _context.Colddrinks.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Colddrinks.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Menu_CardExists(int id)
        {
            return (_context.Colddrinks?.Any(e => e.id == id)).GetValueOrDefault();
        }




        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateColddrink(Models.Colddrinks Menu)
        {
            try
            {

                _context.Colddrinks.Update(Menu);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Data Not Matched");
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _context.Colddrinks.FirstOrDefault(e => e.id == id);
                _context.Colddrinks.Remove(data);
                _context.SaveChanges();
                return Ok("Data Deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "ID Not Matched");
            }

        }
    }
}
