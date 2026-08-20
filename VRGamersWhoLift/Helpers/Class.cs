//https://stackoverflow.com/questions/24181888/authorize-attribute-with-multiple-roles — I cannot believe there is no better way other than string literals, annoying.

namespace VRGamersWhoLift.Helpers
{
    public class RolesControlClass
    {
        public const string Administrator = "Admin";
        public const string Coach = "Coach";
        public const string Member = "Member";
    }
}
