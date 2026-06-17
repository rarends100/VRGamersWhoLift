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

        //private VRGamersWhoLiftContext context { get; set; } - old way, trash
        private readonly VRGamersWhoLiftContext context;

        public AuthenticationController(UserManager<User> userMngr, SignInManager<User> signInMngr, VRGamersWhoLiftContext _context)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            context = _context; // necessary or no access to db ontext, context is then null, and CRUD ops don't work based on context - make commit
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

                
                Member member = new Member( //Profile is not stored in the User table, it is in the Profile table, so this constructor is used to make the necessary Membrer
                    model.UserName,
                    model.FirstName,
                    model.MiddleName,
                    model.LastName,
                    model.Email,
                    "member",
                    model.Password
                    );
                Profile profile = new Profile(model.UserName, model.FirstName + "_" + model.LastName, member);

                //https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud?view=aspnetcore-10.0
                //DB CRUD ops
                try
                {

                    //await context.Users.AddAsync(member);
                    var result = await userManager.CreateAsync(member, model.Password); //pg 670 //  Password_1
                    if (result.Succeeded)
                    {
                        

                        context.Profile.Add(profile);
                        context.SaveChanges();//pg 484
                        Console.WriteLine("User and profile for new user based on the username, added to the database.");
                        await signInManager.SignInAsync(member, isPersistent: false);
                        return RedirectToAction("Index", "Home");

                        
                    }
                    
                }catch(SqlException ex)
                {
                    Console.WriteLine("\nSQL Error: \n\t" + ex);
                }catch(Exception ex)
                {
                    Console.WriteLine("\nError: \n\t" + ex);
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
