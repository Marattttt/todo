using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;
using Todo.Services;

namespace Todo.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {      
        GeneralService generalService;

        public UsersController(TodoContext context)
        { 
            generalService = new GeneralService(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("api/[controller]/get-user{id}")]
        public ActionResult<User> GetUserById(int id)
        {   
            User? user = generalService.GetUserById(id);

            if (user is null)
                return BadRequest();

            return user;
        }

        [Route("api/[controller]/create-user{first_name}/{last_name}/{is_admin}/{login}/{password}")]
        [HttpPost]
        public async Task<IActionResult> CreateUserFromURL(
            string first_name,
            string last_name,
            bool is_admin,
            string login,
            string password)
        {
            User user;
            if (is_admin) 
                user = new Admin(first_name, last_name);
            else
                user = new Client(first_name, last_name);

            user.LoginInfo.UpdateLoginInfo(login, password);
            return Ok(await generalService.CreateUser(user));
        }

        [Route("api/[controller]/create-user")]
        [HttpPost]
        public async Task<IActionResult> CreateUserFromBody([FromBody] string userJSON)
        {
            User? user = JsonSerializer.Deserialize<User>(userJSON);
            if (user is null)
                return BadRequest();

            return Ok(await generalService.CreateUser(user));
        }

        // PUT api/values/5
        [HttpGet("api/[controller]/check-user{id}")]
        public void Put(int id)
        {
        }

        // DELETE api/values/5
        [HttpDelete("api/[controller]/delete-user{id}")]
        public void DeleteUser(int id)
        {
            generalService.DeleteUser(id);
        }
    }
}

