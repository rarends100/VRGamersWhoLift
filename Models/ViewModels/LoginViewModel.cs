using System.ComponentModel.DataAnnotations;

namespace VRGamersWhoLift.Models.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            
        }

        public LoginViewModel(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
            
        }

        public LoginViewModel(string UserName, string Password, string ReturnUrl, bool RememberMe)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.ReturnUrl = ReturnUrl;
            this.RememberMe = RememberMe;
        }

        [Required (ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty; //app redirects by this query string pg 672
        public bool RememberMe { get; set; } = false; //will be assigned to a presistent cookie to keep the user logged in
    }
}
