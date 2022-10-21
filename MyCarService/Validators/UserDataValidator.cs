using MyCarService.AuthServices;
using MyCarService.ErrorHandling;
using MyCarService.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyCarService.Validators
{
    public class UserDataValidator
    {
        static private readonly List<Regex> PasswordRequirements = new List<Regex> { new Regex(@"[0-9]+"), new Regex(@"[A-Z]+"),
                                       new Regex(@".{8,32}"), new Regex(@"[a-z]+"), new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]") };
        static private readonly Regex EmailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


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
        static public bool CheckIfEmailOrUsernameNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null && userAuth.Username == null)
            {
                return false;
            }
            return true;
        }

        static private bool ChechIfDataNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null || userAuth.Username == null || userAuth.Password == null) return false;

            return true;
        }

        static private bool IsEmailCorrect(string email)
        {
            return EmailPattern.IsMatch(email);
        }

        static private bool IsPasswordMatchingCriterias(string password)
        {
            return PasswordRequirements.Select(req => IsMatching(req, password)).All(v => v == true);
        }

        private static bool IsMatching(Regex reg, string password) => reg.IsMatch(password);

    }
}
