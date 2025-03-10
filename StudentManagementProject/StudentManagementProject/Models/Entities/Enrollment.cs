﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementProject.Models.Entities
{
    public class Enrollment
    {
        [Key]
        [Display(Name = "Enrollment ID")]
        public int enrollment_id { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        [Display(Name = "Student ID")]
        public int student_id { get; set; }

        [Required(ErrorMessage = "Course ID is required.")]
        [Display(Name = "Course ID")]
        public int course_id { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [Display(Name = "Grade")]
        public int grade { get; set; }


        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}