using Microsoft.AspNetCore.Identity;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.users;


namespace VRGamersWhoLift.Models.database
{
    public class ConfigureIdentity //preseed role data on preseeded users
    {

        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>(); 

            //premade usernames, roles, and password
            string username_1 = "rarends";
            string username_2 = "swilkins";
            string username_3 = "ngreyson";

            string role_name_admin = "Admin";
            string role_name_member = "Member";
            string role_name_coach = "Coach";

            string password = "Password_1";

            //if role not exist - create it
            //var role = await roleManager.FindByNameAsync(role_name_admin);
            //Console.WriteLine("Role is TRole<> " + role_name_admin);

            if (await roleManager.FindByNameAsync(role_name_admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role_name_admin));
            }
            if (await roleManager.FindByNameAsync(role_name_member) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role_name_member));
            }
            if (await roleManager.FindByNameAsync(role_name_coach) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role_name_coach));
            }

            var Tusername = await userManager.FindByNameAsync(username_1);
            Console.WriteLine("Role is Task<TUser> " + Tusername);
            
            //if username not exist - create it
            if (await userManager.FindByNameAsync(username_1) == null)
            {
                BaseUser user = new BaseUser (UserName: username_1);
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role_name_admin);
                }
            }
            if (await userManager.FindByNameAsync(username_2) == null)
            {
                BaseUser user = new BaseUser(UserName: username_2);
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role_name_member);
                }
            }
            if (await userManager.FindByNameAsync(username_3) == null)
            {
                BaseUser user = new BaseUser(UserName: username_3);
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role_name_coach);
                }
            }

        }
    }
}
