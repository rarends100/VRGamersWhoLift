using Microsoft.AspNetCore.Identity;
using VRGamersWhoLift.Models.Abstract;


namespace VRGamersWhoLift.Models.database
{
    public class ConfigureIdentity //preseed role data on preseeded users
    {

        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            //premade roles
            string username_1 = "rarends";
            string username_2 = "swilkins";
            string username_3 = "ngreyson";

            string role_name_admin = "admin";
            string role_name_member = "member";
            string role_name_coach = "coach";

            //if role not exist - create it
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

            //if username not exist - create it
            if (await userManager.FindByNameAsync(username_1) == null)
            {
                
            }

        }
    }
}
