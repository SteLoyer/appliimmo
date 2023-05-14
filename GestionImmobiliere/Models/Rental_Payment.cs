using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImmobiliere.Models
{  
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("rental_payment", Schema = "public")]
    public class Rental_Payment
    {
      
        [Key]
        [Display(Name = "Numéro de paiement")]
        public int Id_rental_payment { get; set; }

        [Display(Name = "Numéro de dossier")]
        public int Id_rental_file { get; set; }

        [Display(Name = "Nom")]
        public string Name_tenant { get; set; }

        [Display(Name = "Prénom")]
        public string First_name_tenant { get; set; }

        [EmailAddress(ErrorMessage = "L'adresse e-mail est requise")]
       // [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email_tenant { get; set; }

        //[Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Le numéro n'a pas le bon format")]
        [StringLength(10, ErrorMessage = "Le numéro n'a pas le bon format")]
        [Display(Name = "Télephone")]
        public string Phone_tenant { get; set; }

        [Display(Name = "Adresse")]
        public string Adress_property { get; set; }

       [Display(Name = "Code Postal")]
       public int? Postal_code_property { get; set; }

        [Display(Name = "Ville")]
        public string Town_property { get; set; }

       
        [Display(Name = "Montant Loyer")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Rental_property { get; set; }

        [Display(Name = "Taxe agence")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal Agency_taxe { get; set; }

        [Display(Name = "Montant agence")]
        [DataType(DataType.Currency)]
        public decimal Taxe_agency { get { return Rental_property * Agency_taxe/100 ; } }
       
        [Display(Name = "Charges")]
        [DataType(DataType.Currency)]
        public decimal Charge_property { get; set; }

        [Display(Name = "Date de paiement")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Payment_date { get; set; }

        [Display(Name = "Montant à régler")]
        [DataType(DataType.Currency)]
        public decimal Amount_to_be_paid { get { return Taxe_agency + Charge_property + Rental_property; } set { } }
      
        [DataType(DataType.Currency)]
        [Display(Name = "Montant payé")]
        public decimal Amount_paid { get; set; }
        
        [Display(Name = "Solde")]
        public bool Payment_ok
        {
            get { return (Amount_to_be_paid - Amount_paid) == 0; }
            set { }
        }



        [Display(Name = "Mode de paiement")]
         public Payment_method? Payment_method { get; set; }


   }
  public enum Payment_method
    {
            Chéque,CAF,Carte,Virement,Espéce
        }
}