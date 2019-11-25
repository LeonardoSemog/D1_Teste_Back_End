using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppD1.Models
{
    [Table("tblClient")]
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("ClientId")]
        public int Id { get; set; }

        [Column("ClientName")]
        [MaxLength(100), Required(ErrorMessage ="The name is required!",AllowEmptyStrings =false)]
        public string Name { get; set; }

        [Column("ClientDateBirth")]
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy HH:mm:ss}")]
        [Required(ErrorMessage ="Date of Birthday is required!" ,AllowEmptyStrings =false)]
        public DateTime? DateOfBirth { get; set; }

        [Column("RgNumber")]
        [Required(ErrorMessage ="RG number is required!" ,AllowEmptyStrings =false)]
        public double Rg { get; set; }

        [Column("CpfNumber")]
        [Required(ErrorMessage ="CPF number is required!" ,AllowEmptyStrings =false)]
        public double Cpf { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

    }

    
}
