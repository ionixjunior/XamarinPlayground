using System;
using Newtonsoft.Json;

namespace Core.Models
{
    public class ContactModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("linkedin")]
        public string Linkedin { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("credit_card_day")]
        public int CreditCardDay { get; set; }

        public string Image { get; set; }

        public void SetDefault()
        {
            FirstName = "Josh";
            LastName = "Carter";
            Email = "josh.carter@gmail.com";
            Website = "https://joshcarter.com.br";
            Phone = "011999887766";
            Address = "1 Infinite Loop Cupertino CA";
            Facebook = "/joshcarter";
            Twitter = "@joshcarter";
            Linkedin = "https://linkedin.com/joshcarter";
            Birthday = new DateTime(1987, 8, 30);
        }
    }
}
