using Microsoft.AspNetCore.Identity;
using VRGamersWhoLift.Models.Abstract;

namespace VRGamersWhoLift.Models.ViewModels
{
    public class UserViewModel //provides easy way for the view to access the users and roles it needs to display pg 680
    {
        public IEnumerable<User> Users { get; set; } = null;
        public IEnumerable<IdentityRole> Roles { get; set; } = null;
    }
}
