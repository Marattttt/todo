using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;
using Todo.Services;

namespace Todo.Controllers.Api;

//This controller handles create and read methods related to users in general

[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{      
    GeneralService generalService;
    public UsersController(TodoContext context)
    { 
        generalService = new GeneralService(context);
    }

    [HttpGet("api/[controller]/check-user-class{id}")]
    public ActionResult<bool> IsUserAdmin(int id)
    {
        User user;
        try {
            user = generalService.GetUserById(id);
        }
        catch (KeyNotFoundException e) { return BadRequest(); }

        return generalService.IsUserAdmin(user);
    }

    // GET api/values/5
    [HttpGet("api/[controller]/get-user{id}")]
    public ActionResult<User> GetUserById(int id)
    {   
        User user;

        try {
            user = generalService.GetUserById(id);
        }
        catch (KeyNotFoundException e) { return BadRequest(); }

        return user;
    }

    //Method created for a better realization in future
    [Route("api/[controller]/create-user{first_name}/{last_name}/{is_admin}/{login}/{password}")]
    [HttpPost]
    public async Task<IActionResult> CreateUserFromURL(
        string first_name,
        string last_name,
        Role role,
        string login,
        string password)
    {
        User user = new Models.User (first_name, last_name, role);
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
    
    [HttpDelete("api/[controller]/delete-user{id}")]
    public void DeleteUser(int id)
    {
        generalService.DeleteUser(id);
    }
}
