using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;
using Todo.Services;

namespace Todo.Controllers.Api;

//This controller handles create and read methods related to users in general

[Route("api/[controller]/")]
public class UsersController : ControllerBase
{      
    GeneralService generalService;
    public UsersController(TodoContext context)
    { 
        generalService = new GeneralService(context);
    }

    [HttpGet("check-user-class{id}")]
    public ActionResult<bool> IsUserAdmin(int id)
    {
        User user = generalService.GetUser(id);

        if (user is null)
            return BadRequest(); 
    
        return (user is Admin);
    }

    // GET api/values/5
    [HttpGet("api/[controller]/get-user{id}")]
    public ActionResult<User> GetUserById(int id)
    {   
        User? user = generalService.GetUser(id);
        
        if (user is null)
            return BadRequest();

        return user;
    }
    //Method created for a better realization in future
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser(
            User user,
            string login,
            string password,
            Role role)
    {     
        if (!ModelState.IsValid)
            return BadRequest("Invalid model");
        if (user.Id != 0)
            return BadRequest("id must be 0");
        
        user.LoginInfo = new LoginInfo(login, password);

        return Ok(await generalService.CreateUser(
                user,
                role));
    }
    
    [HttpDelete("delete-user{id}")]
    public void DeleteUser(int id)
    {
        generalService.DeleteUser(id);
    }
}
