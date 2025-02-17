using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; } = string.Empty;

        [Required]
        public int CustomerCompanyId { get; set; }
        public Company? CustomerCompany { get; set; }

        [Required]
        public int ExecutorCompanyId { get; set; }
        public Company? ExecutorCompany { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int Priority { get; set; }

        public int? ProjectManagerId { get; set; }
        public Employee? ProjectManager { get; set; }

        public List<ProjectEmployee>? ProjectEmployees { get; set; }


        public string? FilePath { get; set; } = string.Empty;
    }
}
