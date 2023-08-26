using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDBConnect.Models;
using MongoExample.Services;

namespace MongoDBConnect.Controllers
{
    [Route("[controller]")]
    public class UsernameController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public UsernameController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Username>> get()
        {
            return await _mongoDBService.GetAsync();
        }
        [HttpGet("{id}")]
         public async Task<List<Username>> get(string id)
        {
            return await _mongoDBService.GetSpecificUser(id);
        }
        [HttpPost]
        public async Task<IActionResult> post([FromBody] Username username)
        {
            await _mongoDBService.CreateUser(username);
            return CreatedAtAction(nameof(get), new { id = username.Id }, username);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(string id, Username username)
        {
            await _mongoDBService.Updateasync(id, username);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }


    }
}