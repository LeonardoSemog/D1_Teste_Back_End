using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppD1.WebApp.Models
{
    public class PhoneViewModel
    {

        public Int32 Id { get; set; }
        public Int32 ClientId { get; set; }

        [Required(ErrorMessage = "The Type is required!", AllowEmptyStrings = false)]
        [Display(Name = "Phone Type")]
        public Int32 PhoneTypeId { get; set; }

        [Display(Name = "Phone Types")]
        public string PhoneType { get; set; }

        [Required(ErrorMessage = "The Number is required!", AllowEmptyStrings = false)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}