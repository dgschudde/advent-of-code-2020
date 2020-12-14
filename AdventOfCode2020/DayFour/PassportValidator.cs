using System.Text.RegularExpressions;
using FluentValidation;

namespace DayFour
{
    public class PassportValidator : AbstractValidator<Passport>
    {
        public PassportValidator()
        {
            RuleFor(x => x.BirthYear).GreaterThanOrEqualTo(1920).LessThanOrEqualTo(2002);
            RuleFor(x => x.IssueYear).GreaterThanOrEqualTo(2010).LessThanOrEqualTo(2020);
            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(2020).LessThanOrEqualTo(2030);
            
            RuleFor(x => x.Height).Custom((s, context) =>
            {
                int height;
                switch (string.IsNullOrEmpty(s))
                {
                    case false when s.EndsWith("cm"):
                    {
                        s = s.Replace("cm", "");
                        height = int.Parse(s);
                        if ((height >= 150 && height <= 193) == false)
                        {
                            context.AddFailure("Height in centimeters is invalid.");
                        }

                        break;
                    }
                    case false when s.EndsWith("in"):
                    {
                        s = s.Replace("in", "");
                        height = int.Parse(s);
                        if ((height >= 59 && height <= 76) == false)
                        {
                            context.AddFailure("Height in inches is invalid.");
                        }

                        break;
                    }
                    default:
                        context.AddFailure("Height in invalid.");
                        break;
                }
            });

            RuleFor(x => x.HairColor).Custom((s, context) =>
            {
                if (string.IsNullOrEmpty(s) == false && s.StartsWith("#") && s.Length == 7)
                {
                    s = s.Replace("#", "");
                    if (Regex.IsMatch(s, @"\A\b[0-9a-fA-F]+\b\Z") == false)
                    {
                        context.AddFailure("Hair color value is not valid");
                    }
                }
                else
                {
                    context.AddFailure("Hair color lenght is not valid");
                }
            });

            RuleFor(x => x.EyeColor).Must(x => x == "amb" ||
                                               x == "blu" ||
                                               x == "brn" ||
                                               x == "gry" ||
                                               x == "grn" ||
                                               x == "hzl" ||
                                               x == "oth");

            RuleFor(x => x.PassportId).Custom((s, context) =>
            {
                if (string.IsNullOrEmpty(s) == false && s.Length == 9)
                {
                    if (Regex.IsMatch(s, @"\A\b[0-9]+\b\Z") == false)
                    {
                        context.AddFailure("PassportId value is not valid");
                    }
                }
                else
                {
                    context.AddFailure("PassportId length is not valid");
                }
            });

        }
    }
}