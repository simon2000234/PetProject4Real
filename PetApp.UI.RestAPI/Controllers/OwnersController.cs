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
    public class OwnersController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwner();
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.AddOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return _ownerService.GetOwner(id);
            }
            catch (Exception e)
            {
                return BadRequest("No owner with that id");
            }
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            Owner oldOwner = _ownerService.GetOwner(id);
            oldOwner.Name = owner.Name;
        }

        // DELETE api/owenrs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.RemoveOwner(id);
        }
    }
}