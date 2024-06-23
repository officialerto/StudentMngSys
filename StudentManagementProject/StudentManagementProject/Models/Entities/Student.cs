using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementProject.Models.Entities
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public int student_id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(50, ErrorMessage = "Student Name cannot be longer than 50 characters.")]
        [Display(Name = "Student Name")]
        public string student_name { get; set; }

        [Required(ErrorMessage = "Student Surname is required.")]
        [StringLength(50, ErrorMessage = "Student Surname cannot be longer than 50 characters.")]
        [Display(Name = "Student Surname")]
        public string student_surname { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
}
}