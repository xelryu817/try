﻿using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace sampleforchecking.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string CivilStatus { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}
