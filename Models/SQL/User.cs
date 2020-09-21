using System.ComponentModel.DataAnnotations;

namespace people_web_api.Models.SQL
{
    public class User : EntityKey
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}