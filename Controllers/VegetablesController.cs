using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetablesController : ControllerBase
    {
        private readonly RegContext _context;

        public VegetablesController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Vegetables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Vegetables>>> GetVegetables()
        {
            if (_context.Vegetables == null)
            {
                return NotFound();
            }
            return await _context.Vegetables.ToListAsync();

        }


        // GET: api/Vegetables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vegetables>> GetVegetables(int id)
        {
            if (_context.Vegetables == null)

            {
                return NotFound();
            }
            var data = await _context.Vegetables.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Vegetables/5

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
        //public async Task<ActionResult<VegetablesController>> PostVegetable(Models.Vegetables menu_Card)
        //{
        //    if (_context.Vegetables == null)
        //    {
        //        return Problem("Entity set 'RegContext.Menu_Card'  is null.");
        //    }
        //    _context.Vegetables.Add(menu_Card);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMenu_Card", new { id = menu_Card.id }, menu_Card);
        //}

        [HttpPost]
        [Route("postVegetables")]
        public async Task<IActionResult> PostVegetables(Vegetables item)
        {
            try
            {
                _context.Vegetables.Add(item);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        // DELETE: api/Vegetable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVegetable(int id)
        {
            if (_context.Vegetables == null)
            {
                return NotFound();
            }
            var data = await _context.Vegetables.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Vegetables.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Menu_CardExists(int id)
        {
            return (_context.Vegetables?.Any(e => e.id == id)).GetValueOrDefault();
        }




        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateVegetable(Models.Vegetables Menu)
        {
            try
            {

                _context.Vegetables.Update(Menu);
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
                var data = _context.Vegetables.FirstOrDefault(e => e.id == id);
                _context.Vegetables.Remove(data);
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
