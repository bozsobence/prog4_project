using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Web.Models
{
    public class Account
    {
        [Display(Name = "Account ID")]
        [Required]
        public int AccountId { get; set; }

        [Display(Name = "Name")]
        [Required]

        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Price per minute")]
        public int? Minute { get; set; }

        [Display(Name = "Monthly price")]
        public int? Monthly { get; set; }

    }
}