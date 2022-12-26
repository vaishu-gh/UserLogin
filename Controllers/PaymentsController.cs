using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly RegContext _context;

        public PaymentsController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        [Route("Get_Payment")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayment()
        {
            try
            {
                if (_context.Payment == null)
                {
                    return NotFound();
                }
                return await _context.Payment.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong" + ex.Message);
            }
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(string id)
        {
            if (_context.Payment == null)
            {
                return NotFound();
            }
            var payment = await _context.Payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Card_Number)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments

        //        [HttpPost]
        //    public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        //{

        //    try
        //    {
        //         _context.Payment.Add(payment);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PaymentExists(payment.Card_Number))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPayment", new { id = payment.Card_Number }, payment);
        //}


        [HttpPost]
        [Route("Post_Payment")]
        public async Task<ActionResult> PostPayment(Payment item)
        {
            try
            {
                _context.Payment.Add(item);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Payment Succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Payment Failed" + ex.Message);
            }
        }



        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payment == null)
            {
                return NotFound();
            }
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payment?.Any(e => e.Card_Number == id)).GetValueOrDefault();
        }

    }
}
