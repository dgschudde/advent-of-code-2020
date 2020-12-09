using DayTwo.Model;
using System.Linq;

namespace DayTwo
{
    public static class PasswordPolicyExtensions
    {
        public static bool IsValid(this PasswordPolicy passwordPolicy)
        {
            int amount =
                (passwordPolicy.Password ?? string.Empty).Count(x => x == passwordPolicy.CharacterToCheck);

            return amount >= passwordPolicy.Minimum && amount <= passwordPolicy.Maximum;
        }

        public static bool IsValidAccordingNewPolicy(this PasswordPolicy passwordPolicy)
        {
            char[] password = passwordPolicy.Password.ToCharArray();

            return
                password[passwordPolicy.Minimum - 1] == passwordPolicy.CharacterToCheck ^
                password[passwordPolicy.Maximum - 1] == passwordPolicy.CharacterToCheck;
        }
    }
}