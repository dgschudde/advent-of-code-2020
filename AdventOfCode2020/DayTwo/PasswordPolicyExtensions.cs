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
    }
}