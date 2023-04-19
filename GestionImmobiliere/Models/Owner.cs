using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImmobiliere.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("owner", Schema = "public")]
    public class Owner
    {
        [Key]
        [Display(Name = "Numéro du propriétaire")]
        public int Id_owner { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nom")]
        public string Name_owner { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Prénom")]
        public string First_name_owner { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse e-mail est requise")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string E_mail_owner { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Le numéro n'a pas le bon format")]
        [StringLength(10, ErrorMessage = "Le numéro n'a pas le bon format")]
        [Display(Name = "Télephone")]
        public string Phone_owner { get; set; }
    }
}
