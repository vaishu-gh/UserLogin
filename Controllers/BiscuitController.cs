using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;


namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiscuitController : ControllerBase
    {

        private readonly RegContext _context;

        public BiscuitController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Biscuits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Bakery_and_Biscuits>>> GetBiscuits()
        {
            if (_context.Bakery_and_Biscuits == null)
            {
                return NotFound();
            }
            return await _context.Bakery_and_Biscuits.ToListAsync();

        }


        // GET: api/Biscuit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bakery_and_Biscuits>> GetBiscuits(int id)
        {
            if (_context.Bakery_and_Biscuits == null)

            {
                return NotFound();
            }
            var data = await _context.Bakery_and_Biscuits.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Biscuits/5

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

        // POST: api/Biscuits

        [HttpPost]
        //public async Task<ActionResult<FruitsController>> PostBiscuits(Models.Bakery_and_Biscuits menu_Card)
        //{
        //    if (_context.Bakery_and_Biscuits == null)
        //    {
        //        return Problem("Entity set 'RegContext.Menu_Card'  is null.");
        //    }
        //    _context.Bakery_and_Biscuits.Add(menu_Card);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMenu_Card", new { id = menu_Card.id }, menu_Card);
        //}

        [HttpPost]
        [Route("postBiscuits")]
        public async Task<IActionResult> PostBiscuits(Bakery_and_Biscuits item)
        {
            try
            {
                _context.Bakery_and_Biscuits.Add(item);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        // DELETE: api/Biscuits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiscuit(int id)
        {
            if (_context.Bakery_and_Biscuits == null)
            {
                return NotFound();
            }
            var data = await _context.Bakery_and_Biscuits.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Bakery_and_Biscuits.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Menu_CardExists(int id)
        {
            return (_context.Bakery_and_Biscuits?.Any(e => e.id == id)).GetValueOrDefault();
        }




        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateBiscuit(Models.Bakery_and_Biscuits Menu)
        {
            try
            {

                _context.Bakery_and_Biscuits.Update(Menu);
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
                var data = _context.Bakery_and_Biscuits.FirstOrDefault(e => e.id == id);
                _context.Bakery_and_Biscuits.Remove(data);
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
