using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeExample.Models
{
    public class Person
    {
        [Display(Name = "Enter Phone No:")]
        [Required(ErrorMessage = "its a compulsory field")]
        public int PhoneNum { get; set; }


        [Display(Name = "Enter First Name(should not be greater than 10 chars)")]
        [Required(ErrorMessage = "its a compulsory field")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Firstname cannot be greater than 10 chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "its a compulsory field")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Lastname cannot be greater than 10 chars")]
        public string LastName { get; set; }

        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }

        [Range(18, 60, ErrorMessage = "Age is not valid")]

        public int Age { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords donot match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



       /* [Display(Name = "Enter Experience in details")]
        [DataType(DataType.MultilineText)]
        public string ExperienceDetails { get; set; }*/
    }
}
