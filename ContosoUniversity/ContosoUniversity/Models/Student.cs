using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        //specifies the specific data we want in this case the date not the time
        [DataType(DataType.Date)]
        //explicitly defines how data type will be formatted to display, ApplyFormatInEditMode sets wether the format will be shown in view
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        //calculated properties are only getters and don't interact with database
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        //used for one-to-many relationships
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}