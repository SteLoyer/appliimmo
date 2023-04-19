using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionImmobiliere.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("logement", Schema = "public")]
    public class Logement
    {
        [Key]
        [Display(Name = "N°")]
        public int Id_property { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Adresse")]
        public string Adress_property { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Complément")]
        public string Complement_adress_property { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Range(1, 99999)]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Le numéro n'a pas le bon format")]
        
        [Display(Name = "Code Postal")] 
        public int Postal_code_property { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ville")]
        public string Town_property { get; set; }

        [Display(Name = "Type de bien")]
        public Type_property Type_property { get; set; }
       
        [Required]       
        [DataType(DataType.Currency)]
        [Range(1,1500)]
        [Display(Name ="Loyer")]
        public decimal Rental_property { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 1500)]
        [Required]
        [Display(Name = "Charges")]
        public decimal Charge_property { get; set; }
       
        [DataType(DataType.Currency)]
        [Range(1, 1500)]
        [Required]
        [Display(Name = "Caution")]
        public decimal Deposit_property { get; set; }

        [Display(Name = "Etat")]
        public bool State_property { get; set; }
    }
    public enum Type_property
    {
        Maison,Appartement,Immeuble,Garage,Autre
    }

}