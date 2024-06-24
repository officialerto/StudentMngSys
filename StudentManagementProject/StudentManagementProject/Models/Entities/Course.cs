using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementProject.Models.Entities
{
    public class Course
    {
        [Key]
        [Display(Name = "Course ID")]
        public int course_id { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(50, ErrorMessage = "Course Name cannot be longer than 50 characters.")]
        [Display(Name = "Course Name")]
        public string course_name { get; set; }

        [Required(ErrorMessage = "Teacher ID is required.")]
        [Display(Name = "Teacher ID")]
        public int teacher_id { get; set; }

        //FOREIGN KEY RSHPS
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}