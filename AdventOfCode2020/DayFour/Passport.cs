using Newtonsoft.Json;

namespace DayFour
{
    [JsonObject]
    public class Passport
    {
        [JsonProperty("byr")] public int BirthYear { get; set; }

        [JsonProperty("iyr")] public int IssueYear { get; set; }

        [JsonProperty("eyr")] public int ExpirationYear { get; set; }

        [JsonProperty("hgt")] public string Height { get; set; }

        [JsonProperty("hcl")] public string HairColor { get; set; }

        [JsonProperty("ecl")] public string EyeColor { get; set; }

        [JsonProperty("pid")] public string PassportId { get; set; }

        [JsonProperty("cid")] public string CountryId { get; set; }
    }
}