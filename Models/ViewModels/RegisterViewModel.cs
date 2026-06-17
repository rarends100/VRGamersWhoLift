using VRGamersWhoLift.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace VRGamersWhoLift.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required (ErrorMessage = "An email is required.")]
        public string Email {  get; set; } = string.Empty;
        [Required(ErrorMessage = "A password is required.")]
        [DataType(DataType.Password)] //Ensures password feilds use the password options specified in the Program.cs middleware configuration for the password options from the identity framework
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {  get; set; } = string.Empty;
        [Required(ErrorMessage = "A username is required.")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "A first name is required.")]
        public string FirstName {  get; set; } = string.Empty;
        public string MiddleName {  get; set; } = string.Empty;
        [Required(ErrorMessage = "A last name is required.")]
        public string LastName { get; set; } = string.Empty;
    }
}
