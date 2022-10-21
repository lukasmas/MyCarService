using MyCarService.AuthServices;
using MyCarService.ErrorHandling;
using MyCarService.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyCarService.Validators
{
    public class UserDataValidator
    {

        static public Error? ValidateUserAuthData(UserAuth userAuth)
        {
            if (!ChechIfDataNotNull(userAuth))
            {
                return new Error(ErrorCode.DataIsNull, "Some fields are missing");
            }
            if (!IsEmailCorrect(userAuth.Email!))
            {
                return new Error(ErrorCode.InvalidData, "Email is not correct!");
            }
            if (!IsPasswordMatchingCriterias(userAuth.Password!))
            {
                return new Error(ErrorCode.InvalidData, "Password doesn't match criteria!");
            }
            return null;
        }
        static private bool ChechIfDataNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null || userAuth.Username == null || userAuth.Password == null) return false;

            return true;
        }

        static private bool CheckIfEmailOrUsernameNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null && userAuth.Username == null)
            {
                return false;
            }
            return true;
        }

        static private bool IsEmailCorrect(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        static public bool IsPasswordMatchingCriterias(string password)
        {
            List<Regex> requirements = new List<Regex> { new Regex(@"[0-9]+"), new Regex(@"[A-Z]+"),
                                       new Regex(@".{8,32}"), new Regex(@"[a-z]+"), new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]") };

            foreach (Regex requirement in requirements)
            {
                if (!requirement.IsMatch(password))
                {
                    return false;
                }
            }

            return true;

        }
    }
}
