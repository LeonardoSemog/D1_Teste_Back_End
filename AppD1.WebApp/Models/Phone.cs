using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppD1.Models
{
    [Table("tblPhone")]
    public class Phone
    {
        [Key, Column("PhoneId")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Type of Phone is Required" , AllowEmptyStrings =false)]
        public PhoneTypes PhoneTypeId { get; set; }

        [Required(ErrorMessage = "Phone number is Required", AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }


    }

    public enum PhoneTypes
    {
        Mobile = 1,
        Private = 2,
        Residence = 3,
        Contact = 4,
        Emergency = 5,
        Office = 6
    }
}
