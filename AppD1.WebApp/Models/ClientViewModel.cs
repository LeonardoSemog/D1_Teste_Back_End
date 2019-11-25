using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppD1.Models
{
    public class ClientViewModel
    {


        public Int32 Id { get; set; }

       
        [Required(ErrorMessage = "The name is required!", AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birthday is required!", AllowEmptyStrings = false)]
        [Display(Name = "BirthDay")]
        public DateTime? DateOfBirth { get; set; }


        //public Int32 PhoneId { get; set; }
        //public virtual Phone Phone { get; set; }

        //public int AddressId { get; set; }
        //public virtual Address Addresses { get; set; }

        //public int NetSocialId { get; set; }
        //public virtual NetSocial NetSocial { get; set; }

        [Display(Name ="RG Number")]
        [Required(ErrorMessage = "RG number is required!", AllowEmptyStrings = false)]
        public double Rg { get; set; }

        [Display(Name = "CPF Number")]
        [Required(ErrorMessage = "CPF number is required!", AllowEmptyStrings = false)]
        public double Cpf { get; set; }
    }
}