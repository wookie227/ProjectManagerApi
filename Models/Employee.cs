﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string MiddleName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }

        [JsonIgnore] // Исключаем Company при сериализации
        public Company? Company { get; set; }

        [JsonIgnore] // Исключаем список проектов сотрудника
        public List<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
