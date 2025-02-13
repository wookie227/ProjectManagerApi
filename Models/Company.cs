using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
