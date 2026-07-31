namespace VRGamersWhoLift.Helpers
{
    public class Nav
    {
        public static string RegisterActive(string link, string? currentAction)
        {
            return (link.ToLower() == currentAction?.ToLower()) ? "active" : "";
        }
    }
}
