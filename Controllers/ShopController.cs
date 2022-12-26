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
    public class ShopController : ControllerBase
    {
        private readonly RegContext _db;
        public ShopController(RegContext db)
        {
            _db = db;
        }


        // ******************************** Post Methods *************************************

        [HttpPost]
        [Route("ShopLogin")]
        public IActionResult Login(User user)
        {
            try
            {
                var data = _db.Shop.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

                if (data != null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Login Successfull");
                }

                return StatusCode(StatusCodes.Status400BadRequest, "Login Failed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong" + ex.Message);
            }
        }



        [HttpPost]
        [Route("Shop_Register")]
        public async Task<IActionResult> ShopRegister(Shop User)
        {
            try
            {
                _db.Shop.Add(User);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Registered Successfully");
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status404NotFound, "Failed to Register" + ex.Message);
            }

        }

        [HttpPost]
        [Route("postVegetable")]
        public async Task<IActionResult> PostVegetable(Vegetables item)
        {
            try
            {
                _db.Vegetables.Add(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        [HttpPost]
        [Route("postFruit")]
        public async Task<IActionResult> PostFruit(Fruits item)
        {
            try
            {
                _db.Fruits.Add(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }
        }

        [HttpPost]
        [Route("postColddrink")]
        public async Task<IActionResult> PostColddrink(Colddrinks item)
        {
            try
            {
                _db.Colddrinks.Add(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }

        }

        [HttpPost]
        [Route("postBakery_and_Biscuits")]
        public async Task<IActionResult> PostBakery_and_Biscuits(Bakery_and_Biscuits item)
        {
            try
            {
                _db.Bakery_and_Biscuits.Add(item);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong" + ex.Message);
            }

        }

        //[HttpPost]
        //[Route("postDairy")]
        //public async Task<IActionResult> PostDairy(Dairy item)
        //{
        //    try
        //    {
        //        _db.Dairy.Add(item);
        //        await _db.SaveChangesAsync();

        //        return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}

        //[HttpPost]
        //[Route("postSauces")]
        //public async Task<IActionResult> PostSauces(Sauces item)
        //{
        //    try
        //    {
        //        _db.Sauces.Add(item);
        //        await _db.SaveChangesAsync();

        //        return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}

        //[HttpPost]
        //[Route("postSnack")]
        //public async Task<IActionResult> PostSnack(Snack item)
        //{
        //    try
        //    {
        //        _db.Snack.Add(item);
        //        await _db.SaveChangesAsync();

        //        return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}


        //[HttpPost]
        //[Route("postSweet_Tooth")]
        //public async Task<IActionResult> PostSweet_Tooth(Sweet_Tooth item)
        //{
        //    try
        //    {
        //        _db.Sweet_Tooth.Add(item);
        //        await _db.SaveChangesAsync();

        //        return StatusCode(StatusCodes.Status200OK, "Data Added Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Something went wrong" + ex.Message);
        //    }

        //}

        // ******************************** Delete Methods *************************************


    

        [HttpDelete]
        [Route("DeleteVegetable")]
        public async Task<IActionResult> DeleteVegetable(int id)
        {
            try
            {
                var data = _db.Vegetables.FirstOrDefault(e => e.id == id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Vegetables.Remove(data);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
            }

        }

        [HttpDelete]
        [Route("DeleteFruit")]
        public async Task<IActionResult> DeleteFruit(int id)
        {
            try
            {
                var data = _db.Fruits.FirstOrDefault(e => e.id == id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Fruits.Remove(data);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
            }

        }

        [HttpDelete]
        [Route("DeleteBakery_and_Biscuits")]
        public async Task<IActionResult> DeleteBakery_and_Biscuits(int id)
        {
            try
            {
                var data = _db.Bakery_and_Biscuits.FirstOrDefault(e => e.id == id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Bakery_and_Biscuits.Remove(data);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
            }

        }

        [HttpDelete]
        [Route("DeleteColddrink")]
        public async Task<IActionResult> DeleteColddrink(int id)
        {
            try
            {
                var data = _db.Colddrinks.FirstOrDefault(e => e.id == id);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Colddrinks.Remove(data);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
            }

        }

        //[HttpDelete]
        //[Route("DeleteDairy")]
        //public async Task<IActionResult> DeleteDairy(int id)
        //{
        //    try
        //    {
        //        var data = _db.Dairy.FirstOrDefault(e => e.id == id);
        //        if (data == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Dairy.Remove(data);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
        //    }

        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
        //    }

        //}

        //[HttpDelete]
        //[Route("DeleteSauces")]
        //public async Task<IActionResult> DeleteSauces(int id)
        //{
        //    try
        //    {
        //        var data = _db.Sauces.FirstOrDefault(e => e.id == id);
        //        if (data == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Sauces.Remove(data);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
        //    }

        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
        //    }

        //}

        //[HttpDelete]
        //[Route("DeleteSnack")]
        //public async Task<IActionResult> DeleteSnack(int id)
        //{
        //    try
        //    {
        //        var data = _db.Snack.FirstOrDefault(e => e.id == id);
        //        if (data == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Snack.Remove(data);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
        //    }

        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
        //    }

        //}

        //[HttpDelete]
        //[Route("DeleteSweet_Tooth")]
        //public async Task<IActionResult> DeleteSweet_Tooth(int id)
        //{
        //    try
        //    {
        //        var data = _db.Sweet_Tooth.FirstOrDefault(e => e.id == id);
        //        if (data == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Sweet_Tooth.Remove(data);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Data deleted Successfully");
        //    }

        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong");
        //    }

        //}

        // ******************************** Update Methods *************************************

        [HttpPut]
        [Route("Update_Vegetable")]
        public async Task<IActionResult> UpdateVegetable(Vegetables item)
        {
            try
            {
                if (_db.Vegetables == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Vegetables.Update(item);
               await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" +ex.Message);
            }

        }

        [HttpPut]
        [Route("Update_Fruit")]
        public async Task<IActionResult> UpdateFruit(Fruits item)
        {
            try
            {
                if (_db.Fruits == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Fruits.Update(item);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
            }

        }


        [HttpPut]
        [Route("Update_Bakery_and_Biscuits")]
        public async Task<IActionResult> UpdateBakery_and_Biscuits(Bakery_and_Biscuits item)
        {
            try
            {
                if (_db.Bakery_and_Biscuits == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Bakery_and_Biscuits.Update(item);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
            }

        } 
        
        
        [HttpPut]
        [Route("Update_Colddrinks")]
        public async Task<IActionResult> UpdateColddrinks(Colddrinks item)
        {
            try
            {
                if (_db.Colddrinks == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
                }
                _db.Colddrinks.Update(item);
                await _db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Update Successfull");

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
            }

        } 
        
        //[HttpPut]
        //[Route("Update_Dairy")]
        //public async Task<IActionResult> UpdateDairy(Dairy item)
        //{
        //    try
        //    {
        //        if (_db.Dairy == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Dairy.Update(item);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Update Successfull");

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
        //    }

        //} 



        //[HttpPut]
        //[Route("Update_Sauces")]
        //public async Task<IActionResult> UpdateSauces(Sauces item)
        //{
        //    try
        //    {
        //        if (_db.Sauces == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Sauces.Update(item);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Update Successfull");

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
        //    }

        //}


        //[HttpPut]
        //[Route("Update_Snack")]
        //public async Task<IActionResult> UpdateSnack(Snack item)
        //{
        //    try
        //    {
        //        if (_db.Snack == null)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
        //        }
        //        _db.Snack.Update(item);
        //        await _db.SaveChangesAsync();
        //        return StatusCode(StatusCodes.Status200OK, "Update Successfull");

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
        //    }

        //}

    //    [HttpPut]
    //    [Route("Update_Sweet_Tooth")]
    //    public async Task<IActionResult> UpdateSweet_Tooth(Sweet_Tooth item)
    //    {
    //        try
    //        {
    //            if (_db.Sweet_Tooth == null)
    //            {
    //                return StatusCode(StatusCodes.Status404NotFound, "Item not Found");
    //            }
    //            _db.Sweet_Tooth.Update(item);
    //            await _db.SaveChangesAsync();
    //            return StatusCode(StatusCodes.Status200OK, "Update Successfull");

    //        }
    //        catch (Exception ex)
    //        {

    //            return StatusCode(StatusCodes.Status404NotFound, "Something went wrong" + ex.Message);
    //        }

    //    }
    }
}
