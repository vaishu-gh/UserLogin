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
    public class UserController : ControllerBase
    {



        private readonly RegContext _db;
        public UserController(RegContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("User_Registration")]
        public IActionResult CreateUser(Registration User)
        {
            try
            {
                _db.Registration.Add(User);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Registered Successfull");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Failed to Add data");
            }

        }


        [HttpPost]
        [Route("User_Login")]
        public IActionResult Login(User user)
        {
            var data = _db.Registration.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (data != null)
            {

                return StatusCode(StatusCodes.Status200OK, "Login Successfull");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Login Failed");
        }

        [HttpPost]
        [Route("Post_Payment")]
        public async Task<ActionResult> PostPayment(Payment item)
        {
            try
            {
                _db.Payment.Add(item);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Payment Succesfull");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Payment Failed" + ex.Message);
            }
        }


        //  Order confirmation Method 
        public class confirmOrder
        {
            
            public string Name { get; set; }
           
        

            public string ItemName { get; set; }
            public int Quantity { get; set; }

            public int Price { get; set; }
            public string Address { get; set; }
            public string TimeSlot { get; set; }
        }

        [HttpPost]
        [Route("Post_Order")]
        public async Task<ActionResult> PostOder(confirmOrder item)
        {

            var data = _db.Registration.FirstOrDefault(x => x.Fname == item.Name);
            OrderDetails orders = new OrderDetails();

            try
            {

                orders.Address = item.Address;
                orders.ItemName = item.ItemName;
                orders.TimeSlot = item.TimeSlot;
                orders.Price = item.Price;
                orders.Quantity = item.Quantity;
                orders.UID = data.UID;
                _db.OrderDetails.Add(orders);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Order Confirmed");
                //return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Failed to Place Order" + ex.Message);
            }
        }

      

        [HttpGet]
        [ActionName("GetOrdersByName")]
        public IActionResult GetOrdersByid([FromQuery] string name)
        {
            List<OrderDetails> list = new List<OrderDetails>();
           
           var hello =  _db.Registration.FirstOrDefault(x => x.Fname == name);
            foreach (var item in _db.OrderDetails.ToList())
            {
                if (hello.UID == item.UID)
                {
                    list.Add(item);
                }
               
            }


            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            } 


        }
    }
}
