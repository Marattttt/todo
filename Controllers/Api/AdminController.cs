using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;
using Todo.Services;

namespace Todo.Controllers.Api;

//This controller handles special methods to be used by admins

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
}


