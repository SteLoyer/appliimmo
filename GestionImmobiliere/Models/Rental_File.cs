using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace GestionImmobiliere.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("rental_file", Schema = "public")]

       public class Rental_File
    {
        [Key]
        [Display(Name = "N° dossier")]
        public int Id_rental_file { get; set; }

        public int Id_tenant { get; set; }

        public int Id_logement { get; set; }

        [Display(Name = "Nom")]
        public string Name_tenant { get; set; }

        [Display(Name = "Prénom")]
        public string First_name_tenant { get; set; }

        [Display(Name = "E-Mail")]
        public string Email_tenant { get; set; }

     //   [Required]
        [DataType(DataType.PhoneNumber)]
     //   [RegularExpression("^[0-9]{10}$", ErrorMessage = "Le numéro n'a pas le bon format")]
     //   [StringLength(10, ErrorMessage = "Le numéro n'a pas le bon format")]
        [Display(Name = "Télephone")]
        public string Phone_tenant { get; set; }

        [Display(Name = "Adresse")]
        public string Adress_property { get; set; }

        [Display(Name = "Code Postal")]
        public int Postal_code_property { get; set; }

        [Display(Name = "Ville")]
        public string Town_property { get; set; }

        [Required]
        [Display(Name = "Montant Loyer")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal Rental_property { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat( DataFormatString = "{0:C}")]
        [Display(Name = "Charges")]
        public decimal Charge_property { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat( DataFormatString = "{0:C}")]
        [Display(Name = "Dépot de garantie")]
        public decimal Deposit_property { get; set; }

        [Display(Name = "Date d'entrée")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_rental { get; set; }

       [Display(Name = "Etat des lieux")]
        public string Lease_report { get; set; }

        [Display(Name = "Date d'état des lieux")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_lease_report { get; set; }

        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_finish_lease { get; set; }
    }
  
}