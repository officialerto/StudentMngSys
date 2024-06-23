using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementProject.Models.Entities
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Teacher ID")]
        public int teacher_id { get; set; }

        [Required(ErrorMessage = "Teacher Name is required.")]
        [StringLength(50, ErrorMessage = "Teacher Name cannot be longer than 50 characters.")]
        [Display(Name = "Teacher Name")]
        public string teacher_name { get; set; }

        [Required(ErrorMessage = "Teacher Surname is required.")]
        [StringLength(50, ErrorMessage = "Teacher Surname cannot be longer than 50 characters.")]
        [Display(Name = "Teacher Surname")]
        public string teacher_surname { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //FOREIGN KEY
        public virtual ICollection<Course> Courses { get; set; }

    }
}