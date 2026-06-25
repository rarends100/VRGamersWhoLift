using Microsoft.AspNetCore.Identity;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.users;
using VRGamersWhoLift.Helpers;


namespace VRGamersWhoLift.Models.database
{
    public class ConfigureIdentity //preseed role data on preseeded users
    {
      
        public static async Task CreateInitUsersAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var context = provider.GetRequiredService<VRGamersWhoLiftContext>();
            
            //premade usernames, roles, and password
            string username_1 = "rarends";
            string username_2 = "swilkins";
            string username_3 = "ngreyson";

            /*
            string role_name_admin = "Admin";
            string role_name_member = "Member";
            string role_name_coach = "Coach";
            */

            string password = "Password_1";

            //if role not exist - create it
            //var role = await roleManager.FindByNameAsync(role_name_admin);
            //Console.WriteLine("Role is TRole<> " + role_name_admin);
            //Console.WriteLine("Role " + Roles.Admin.ToString());
            var users = userManager.Users.ToList(); //It is null, why?

            string admin = Roles.Admin.ToString();
            string member = Roles.Member.ToString();
            string coach = Roles.Coach.ToString();

            if (await roleManager.FindByNameAsync(admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(admin));
            }
            if (await roleManager.FindByNameAsync(member) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(member));
            }
            if (await roleManager.FindByNameAsync(coach) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(coach));
            }

            //var Tusername = await userManager.FindByNameAsync(username_1);
            //Console.WriteLine("Role is Task<TUser> " + Tusername);
            
            //if username not exist - create it
            if (await userManager.FindByNameAsync(username_1) == null)
            {
                //Instantiation requires a concrete type or it will not beable to identify its params in Identity framework, meaning -> Concrete derived classes (BaseUser, Admin, member, coach) are required for user creation and management.
                BaseUser user = new Admin (username_1, "robert.arends100@gitmail.com"); //Abstract User class hides the implementatin details, BaseUser allows for easy instantiation that can be based on BaseUser or role type, finally cannot create a new user based on an abstract class type parameter, since abstract classes cannot be instantiated using one will result in table reference issues
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, admin);
                    await context.Profile.AddAsync(new Profile(user.UserName!, "Robert", "Charles", "Arends"));
                    await context.SaveChangesAsync();
                {

                    };

                }
            }
            if (await userManager.FindByNameAsync(username_2) == null)
            {
                BaseUser user = new Member(username_2, "samantha.wilkins@gitmail.com");
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, member);
                    await context.Profile.AddAsync(new Profile(user.UserName!, "Samantha", "Eve", "Wilkins"));
                    await context.SaveChangesAsync();
                }
            }
            if (await userManager.FindByNameAsync(username_3) == null)
            {
                BaseUser user = new Coach(username_3, "nolan.greyson@gitmail.com");
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, coach);
                    await context.Profile.AddAsync(new Profile(user.UserName!, "Nolan", "", "Greyson"));
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
