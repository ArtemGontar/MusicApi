using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Music.WebAPI.Controllers
{
    //[Authorize]
    /// <summary>
    /// Groups controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        /// <summary>
        /// Groups controller constructor
        /// </summary>
        /// <param name="groupService"></param>
        public GroupsController(IGroupService groupService)
        {
            this._groupService = groupService;
        }

        // GET api/groups
        /// <summary>
        /// Get all groups async
        /// </summary>
        /// <returns>Returns IEnumerable groups list</returns>
        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await Task.FromResult(await _groupService.GetAllAsync());
        }

        // GET api/groups/5
        /// <summary>
        /// Get group by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns group get by Id</returns>
        [HttpGet("{id:length(24)}")]
        public async Task<Group> GetAsync(string id)
        {
            return await Task.FromResult(await _groupService.GetAsync(new ObjectId(id)));
        }

        // POST api/groups
        /// <summary>
        /// Create group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns>Returns group that was created</returns>
        [HttpPost]
        public async Task<ActionResult<Group>> CreateAsync([FromBody] Group group)
        {
            await _groupService.CreateAsync(group);
            
            return CreatedAtAction(nameof(GetAsync), new { id = group.Id }, group);
        }

        // PUT api/groups
        /// <summary>
        /// Update group async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="group"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Group group)
        {
            //if (new ObjectId(id) != group.Id)
            //{
            //    return BadRequest();
            //}

            await _groupService.UpdateAsync(new ObjectId(id), group);
            
            return NoContent();
        }

        // DELETE api/group
        /// <summary>
        /// Delete group async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns NoContent(204) status code</returns>
        [HttpDelete]
        public async Task<IActionResult> DeteteAsync(string id)
        {
            var group = await _groupService.GetAsync(new ObjectId(id));

            if (group == null)
            {
                return NotFound();
            }
            await _groupService.DeleteAsync(new ObjectId(id));
            return NoContent();
        }
    }
}