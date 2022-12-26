using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]


    public class FruitsController : ControllerBase
    {
        private readonly RegContext _context;

        public FruitsController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Fruits
        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<Models.Fruits>>> GetFruits()
        {
            if (_context.Fruits == null)
            {
                return NotFound();
            }
            return await _context.Fruits.ToListAsync();

        }


        // GET: api/Fruits/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Fruits>> GetFruits(int id)
        {
            if (_context.Fruits == null)

            {
                return NotFound();
            }
            var data = await _context.Fruits.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/Fruits/5

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
        //public async Task<ActionResult<FruitsController>> PostFruits(Models.Fruits menu_Card)
        //{
        //    if (_context.Fruits == null)
        //    {
        //        return Problem("Entity set 'RegContext.Menu_Card'  is null.");
        //    }
        //    _context.Fruits.Add(menu_Card);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMenu_Card", new { id = menu_Card.id }, menu_Card);
        //}



        [HttpPost]
        [Route("postFruit")]
        public async Task<IActionResult> PostFruit(Fruits item)
        {
            try
            {
                _context.Fruits.Add(item);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        // DELETE: api/Fruits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruits(int id)
        {
            if (_context.Fruits == null)
            {
                return NotFound();
            }
            var data = await _context.Fruits.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Fruits.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Menu_CardExists(int id)
        {
            return (_context.Fruits?.Any(e => e.id == id)).GetValueOrDefault();
        }




        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateFruits(Models.Fruits Menu)
        {
            try
            {

                _context.Fruits.Update(Menu);
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
                var data = _context.Fruits.FirstOrDefault(e => e.id == id);
                _context.Fruits.Remove(data);
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
