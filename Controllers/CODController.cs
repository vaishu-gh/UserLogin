using UserLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace UserLogin.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CODController : ControllerBase
    {
        private readonly RegContext _db;
        public CODController(RegContext db)
        {
            _db = db;
        }
        //Get COD
        [HttpGet]
        [Route("Get_COD")]
        public async Task<ActionResult<IEnumerable<COD>>> GetCOD()
        {
            try
            {
                if (_db.COD == null)
                {
                    return NotFound();
                }
                return await _db.COD.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong" + ex.Message);
            }
        }

        // Get COD by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<COD>> GetCOD(int id)
        {
            if (_db.COD == null)
            {
                return NotFound();
            }
            var cod = await _db.COD.FindAsync(id);

            if (cod == null)
            {
                return NotFound();
            }

            return cod;
        }

        //Update COD by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCOD(int id, COD cod)
        {
            if (id != cod.ID)
            {
                return BadRequest();
            }

            _db.Entry(cod).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CODExists(id))
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
        //method
        private bool CODExists(int id)
        {
            return (_db.COD?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        //Post COD
        [HttpPost]
        [Route("Post_COD")]
        public async Task<ActionResult> PostCOD(COD item)
        {
            try
            {
                _db.COD.Add(item);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "COD Succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "COD Failed" + ex.Message);
            }
        }

        //Delete COD

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCOD(int id)
        {
            if (_db.COD == null)
            {
                return NotFound();
            }
            var cod = await _db.COD.FindAsync(id);
            if (cod== null)
            {
                return NotFound();
            }

            _db.COD.Remove(cod);
            await _db.SaveChangesAsync();

            return NoContent();
        }





    }
    }

