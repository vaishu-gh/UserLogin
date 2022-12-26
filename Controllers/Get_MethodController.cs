using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get_MethodController : ControllerBase
    {
        private readonly RegContext _context;

        public Get_MethodController(RegContext context)
        {
            _context = context;
        }

       
        // GET: api/Colddrinks
        [HttpGet]
        [Route("Get_Colddrinks")]
        public async Task<ActionResult<IEnumerable<Colddrinks>>> GetColddrinks()
        {
            try
            {
                if (_context.Colddrinks == null)
                {
                    return NotFound("Item is not available");
                }

                return await _context.Colddrinks.ToListAsync();
            }
            catch(Exception ex)
            {
                return BadRequest("Something went wrong"+ ex.Message);
            }
        }

        // GET: api/Vegetables
        [HttpGet]
        [Route("Get_Vegetables")]
        public async Task<ActionResult<IEnumerable<Vegetables>>> GetVegetables()
        {
            try
            {
                if (_context.Vegetables == null)
                {
                    return NotFound();
                }
                return await _context.Vegetables.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }

        }

        // GET: api/Fruits
        [HttpGet]
        [Route("Get_Fruits")]
        public async Task<ActionResult<IEnumerable<Fruits>>> GetFruits()
        {
            try
            {
                if (_context.Fruits == null)
                {
                    return NotFound();
                }
                return await _context.Fruits.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }

        }

        // GET: api/Biscuits
        [HttpGet]
        [Route("Get_Biscuits")]
        public async Task<ActionResult<IEnumerable<Bakery_and_Biscuits>>> GetBiscuits()
        {
            try
            {
                if (_context.Bakery_and_Biscuits == null)
                {
                    return NotFound();
                }
                return await _context.Bakery_and_Biscuits.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }

        }

        // GET: api/Dairy
        //[HttpGet]
        //[Route("Get_Dairy")]
        //public async Task<ActionResult<IEnumerable<Dairy>>> GetDairy()
        //{
        //    try
        //    {
        //        if (_context.Dairy == null)
        //        {
        //            return NotFound();
        //        }
        //        return await _context.Dairy.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}

        // GET: api/Sauces
        //[HttpGet]
        //[Route("Get_Sauces")]
        //public async Task<ActionResult<IEnumerable<Sauces>>> GetSauces()
        //{
        //    try
        //    {
        //        if (_context.Sauces == null)
        //        {
        //            return NotFound();
        //        }
        //        return await _context.Sauces.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }


        //}

        // GET: api/Snack
        //[HttpGet]
        //[Route("Get_Snack")]
        //public async Task<ActionResult<IEnumerable<Snack>>> GetSnack()
        //{
        //    try
        //    {
        //        if (_context.Snack == null)
        //        {
        //            return NotFound();
        //        }
        //        return await _context.Snack.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}

        // GET: api/Sweet_Tooth
        //[HttpGet]
        //[Route("Get_Sweet_Tooth")]
        //public async Task<ActionResult<IEnumerable<Sweet_Tooth>>> GetSweet_Tooth()
        //{
        //    try
        //    {
        //        if (_context.Sweet_Tooth == null)
        //        {
        //            return NotFound();
        //        }
        //        return await _context.Sweet_Tooth.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}
    }
}
