using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.users;
using VRGamersWhoLift.Models.ViewModels;
using VRGamersWhoLift.Models;
using Microsoft.Data.SqlClient;
using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        private VRGamersWhoLiftContext context { get; set; }

        public AuthenticationController(UserManager<User> userMngr, SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        //TODO: Register, login, and Logout methods here

        [HttpGet]
        public IActionResult MemberRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemberRegister(RegisterViewModel model) 
        {
            if (ModelState.IsValid)
            {
                //TODO: later add switch for different User sub class types to be registered here -> Coach, Member -> Later add a new view, Controller action method, and Register model for Admins

                Profile profile = new Profile(model.UserName, model.FirstName + "_" + model.LastName);
                Member member = new Member( //Profile is not stored in the User table, it is in the Profile table, so this constructor is used to make the necessary Membrer
                    model.UserName,
                    model.FirstName,
                    model.MiddleName,
                    model.LastName,
                    model.Email,
                    "member",
                    model.Password
                    );
                //https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud?view=aspnetcore-10.0
                //DB CRUD ops
                try
                {

                    //await context.Users.AddAsync(member);
                    var result = await userManager.CreateAsync(member, model.Password); //pg 670
                    if(result.Succeeded)
                    {
                        await context.profiles.AddAsync(profile); //pg 484
                        Console.WriteLine("User and profile for new user based on the username, added to the database.");
                        await signInManager.SignInAsync(member, isPersistent: false);
                        return RedirectToAction("Index", "Home");

                        
                    }
                    
                }catch(SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex);
                }


            }
            else
            {
                return View();
            }
            return View(model);
           
        }
    }
}
