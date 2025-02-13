using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models
{
    public class ProjectEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
