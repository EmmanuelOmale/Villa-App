using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[Controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        /// API documentation with statuscodes description
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(VillaDto))]
        public ActionResult<VillaDto> GetVillaById(int id)
        {
            if(id == 0)
                return BadRequest();
          
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

            if(villa == null)
                return NotFound();
            
            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if(VillaStore.villaList.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) !=null)
            {
                ModelState.AddModelError("Custom Error", "Villa already exists!");
                return BadRequest(ModelState);
            }
            /// For model validation on required members in the DTO model we can include the following guard clause.
            /// By default, the APIController annotation on this controller class has in-built features for the following guard clause.
            /// But Just so you choose to do this manually, you can always include the codes on line 49 & 50 below.
            /*if(!ModelState.IsValid)
                return BadRequest(ModelState);*/
            if(villaDto == null)
                return BadRequest();
            if(villaDto.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);
            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDto);

            //return Ok(villaDto);  /// Returning Ok() is fine, but what if we want to specify the route where the object is created?
                                  //  Then we will have to give the get method a name for the sake of referencing.
            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }
    }
}
