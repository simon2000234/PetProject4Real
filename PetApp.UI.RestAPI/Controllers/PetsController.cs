using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetApp.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return _petService.GetFilteredPets(filter);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.AddPet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                return _petService.GetPet(id);
            }
            catch (Exception e)
            {
                return BadRequest("No pet with that id");
            }

        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public Pet Put(int id, [FromBody] Pet pet)
        {
            return _petService.UpdatePer(pet);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return _petService.RemovePet(id);
            }
            catch (Exception e)
            {
                return BadRequest("No pet with that id");
            }
        }

    }
}