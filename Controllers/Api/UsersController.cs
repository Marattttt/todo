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
        AdminService adminService;
        ClientService clientService;

        public UsersController(TodoContext context)
        { 
            generalService = new GeneralService(context);
            adminService = new AdminService(context);
            clientService = new ClientService(context);
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

        [Route("api/[controller]/create-user{first_name}/{last_name}/{login}/{password}")]
        [HttpPost]
        public async Task<IActionResult> CreateUserFromURL(
            string first_name,
            string last_name,
            string login,
            string password)
        {
            User user;
            
            Console.WriteLine(
                first_name + "\n" + last_name + "\n" + login + "\n" + password);
            
            user = new User(first_name, last_name);
            Console.WriteLine(
    first_name + "\n" + last_name + "\n" + login + "\n" + password);

            user.LoginInfo.UpdateLoginInfo(login, password);
            Console.WriteLine(
    first_name + "\n" + last_name + "\n" + login + "\n" + password);


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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

