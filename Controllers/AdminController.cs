using UserLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace UserLogin.Controllers
{
   [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RegContext _db;
        public AdminController(RegContext db)
        {
            _db = db;
        }
       
        [HttpPost]
        [Route("Admin_Login")]
        public IActionResult AdminLogin(Admin user)
        {
            var data = _db.Admin.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (data != null)
            {               
                return StatusCode(StatusCodes.Status200OK, "Login Successfull");
            }
           
            return StatusCode(StatusCodes.Status400BadRequest, "Login Failed");
        }


        [HttpPost]
        [Route("Admin_Register")]
        public async Task<IActionResult> AdminRegister(Admin User)
        {
            try
            {
                _db.Admin.Add(User);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Registered Successfully");
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status404NotFound, "Failed to Register"+ex.Message);
            }

        }

        // ********************* Payment Methods *****************************

        [HttpGet]
        [Route("Get_Payment")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayment()
        {
            try
            {
                if (_db.Payment == null)
                {
                    return NotFound();
                }
                return await _db.Payment.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong" + ex.Message);
            }
        }






        // ********************* Shop Methods *****************************


        [HttpGet]
        [Route("Get_Shops")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            try
            {
                if (_db.Shop == null)
                {
                    return NotFound("Shop is not available");
                }

                return await _db.Shop.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }


        [HttpPost]
        [Route("postShop")]
        public async Task<IActionResult> PostShop(Shop item)
        {
            try
            {
                _db.Shop.Add(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteShop")]
        public async Task<IActionResult> DeleteShop(Shop item)
        {
            try
            {
                _db.Shop.Remove(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }


        [HttpPut]
        [Route("UpdateShop")]
        public async  Task<IActionResult> UpdateShop(Shop item)
        {
            try
            {

                _db.Shop.Update(item);
               await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Shop Not Found");
            }

        }

        //******************************** User Information **************************

        [HttpGet]
        [Route("Get_Users")]
        public async Task<ActionResult<IEnumerable<Registration>>> GetUsers()
        {
            try
            {
                if (_db.Registration == null)
                {
                    return NotFound("No user is available");
                }
                return await _db.Registration.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went Wrong"+ ex.Message);
            }
        }

        [HttpPost]
        [Route("Create_User")]
        public async  Task<IActionResult> CreateUser(Registration User)
        {
            try
            {
                _db.Registration.Add(User);
               await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Registered Successfull");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Failed to Add data"+ex.Message);
            }

        }

        [HttpPut]
        [Route("Update_User")]
        public async Task<IActionResult> UpdateUser(Registration User)
        {
            try
            {
                var data = _db.Registration.FirstOrDefaultAsync(x => x.Equals(User));
                if (data == null)
                {
                    return NotFound("User not Found");
                }

                _db.Registration.Update(User);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Data Not Matched");
            }

        }


        [HttpDelete]
        [Route("Delete_User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var data =  _db.Registration.FirstOrDefault(e => e.UID == id);
                if (data == null)
                {
                    return NotFound("User not Found");
                }
                _db.Registration.Remove(data);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK,"Data deleted successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
            }

        }

        //   Get Method for Order Confirmation 
        [HttpGet]
        [Route("Get_Order")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrder()
        {


            try
            {
                if (_db.OrderDetails == null)
                {
                    return NotFound();
                }
                return await _db.OrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong" + ex.Message);
            }
        }

    }
}
