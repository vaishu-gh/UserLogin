
using UserLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace UserLogin.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly RegContext _db;
        public RegistrationsController(RegContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("Get_Users")]
        public IEnumerable<Registration> GetUsers()
        {

            var data = _db.Registration.ToList();
            return data;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Registration User)
        {
            try
            {
                _db.Registration.Add(User);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Registered Successfull");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Failed to Add data");
            }

        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Registration User)
        {
            try
            {

                _db.Registration.Update(User);
                _db.SaveChanges();
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
                var data = _db.Registration.FirstOrDefault(e => e.UID == id);
                _db.Registration.Remove(data);
                _db.SaveChanges();
                return Ok("Data Deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "ID Not Matched");
            }

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User user)
        {
            var data = _db.Registration.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (data != null)
            {
                /*return RedirectToAction("Index");*///open food item page from here
                                                     //return
                /*"Login is Successful!!!";*/
                //return "Login Successful!!!";
                return StatusCode(StatusCodes.Status200OK, "Login Successfull");

            }
            //return BadRequest("Login Failed!!");
            //return "Invalid Username or Password";
            return StatusCode(StatusCodes.Status400BadRequest, "Login Failed");
        }



    }
}