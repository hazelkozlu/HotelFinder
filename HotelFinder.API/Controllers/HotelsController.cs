using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        //hotelbusinesstan bir örnek lazım
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            //hotelServise e değer ataması yap
            _hotelService = hotelService;
        }
        /// <summary>
        /// Gets All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels =_hotelService.GetAllHotels();
            return Ok(hotels); //response 200 +data
        }
        /// <summary>
        /// Get the hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
           var hotel= _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel); //200+data
            }
            return NotFound();//404   
             
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200+data
            }
            return NotFound();//404   

        }
        [HttpGet]
        [Route("[action]/{id}/{name}")]
        public IActionResult GetHotelByIdAndName(int id,string name)
        {
            return Ok();

        }
        //[HttpGet]
        //[Route("[action]")]
        ////http://localhost:30691/api/Hotels/GetHotelByIdAndName?id=3&name=billurcu
        //public IActionResult GetHotelByIdAndName(int id, string name)
        //{
        //    return Ok();

        //}

        /// <summary>
        /// Create the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {// apicontroller yukarda oluğu için kedisi validationı var demekmiş
            //if (ModelState.IsValid)
            //{
            //    var createHotel = _hotelService.CreateHotel(hotel);
            //    return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);//201 + data
            //}
            //return BadRequest(ModelState); //400 + validation errors    


            var createHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);//201 + data

        }
        /// <summary>
        /// update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 +data
            }
            return NotFound(); 
        }
        /// <summary>
        /// delete the hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById(id)!= null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound();
        }
             
    }
}
