using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionImmobiliere.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("tenant", Schema = "public")]
    public class Tenant
    {
        [Key]
        [Display(Name = "Numéro De Locataire")]
        public int Id_tenant { get; set; }
 
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nom")]
        public string Name_tenant { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Prénom")]
        public string First_name_tenant { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse e-mail est requise")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email_tenant { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Le numéro n'a pas le bon format")]
        [StringLength(10, ErrorMessage = "Le numéro n'a pas le bon format")]
        [Display(Name = "Télephone")]
        public string Phone_tenant { get; set; }
    }
}