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
    public class AdminController : ControllerBase
    {
        GeneralService generalService;
        AdminService adminService;

        public AdminController(TodoContext context)
        { 
            generalService = new GeneralService(context);
            adminService = new AdminService(context);
        }

        [HttpGet("api/[controller]/watchlist{admin_id}")]
        public ActionResult<List<User>> GetWatchlist(int admin_id)
        {
            User? user = generalService.GetUserById(admin_id);
            
            if (user is not Admin || user is null)
                return BadRequest();

            Admin admin = (Admin)user;
            if (admin.WatchList is null || admin.WatchList.Count() < 1)
                return NoContent();

            return Ok(admin.WatchList);
        }

        [HttpPost("api/[controller]/add-to-watchlist{admin_id}/{user_id}")]
        public ActionResult AddUserToWatclist(int admin_id, int user_id)
        {   
            User? adminUser = generalService.GetUserById(admin_id);
            User? clientUser = generalService.GetUserById(user_id);
            Admin admin;
            Client client;

            string error = String.Empty;

            if (adminUser is null || clientUser is null)
                return BadRequest("user not found");
            if (adminUser is not Admin)
                error += "admin id incorrect ";
            if (clientUser is not Client)
                error += "client id incorrect ";
            if (error != String.Empty)
                return BadRequest(error);
            admin = (Admin)adminUser;
            client = (Client)clientUser;

            admin.WatchList.Add(client);
            
            return Ok(client);
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

