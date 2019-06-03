using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;

namespace Music.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            this._groupService = groupService;
        }

        // GET api/groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAll()
        {
            return Ok(_groupService.GetAll());
        }

        // GET api/groups/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Group>> Get(string id)
        {
            return Ok(_groupService.Get(new ObjectId(id)));
        }

        // POST api/groups
        [HttpPost]
        public async Task<ActionResult<Group>> Create([FromBody] Group group)
        {
            _groupService.Create(group);

            //SaveChange

            return CreatedAtAction(nameof(Get), new { id = group.Id }, group);
        }

        // PUT api/groups
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Group group)
        {
            //if (new ObjectId(id) != group.Id)
            //{
            //    return BadRequest();
            //}

            _groupService.Update(new ObjectId(id), group);

            //SaveChange

            return NoContent();
        }

        // DELETE api/group
        [HttpDelete]
        public async Task<IActionResult> Detete(string id)
        {
            var group = _groupService.Get(new ObjectId(id));

            if (group == null)
            {
                return NotFound();
            }
            _groupService.Delete(new ObjectId(id));
            return NoContent();
        }
    }
}