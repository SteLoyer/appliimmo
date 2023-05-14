using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionImmobiliere.Models
{
    // Table : spécifie la table de la base de donné à laquelle la classe est mappée
    [Table("parameters", Schema = "public")]
    public class Parameters
    {
        [Key]
        public int Id_parameters { get; set; }

        [Display(Name = "Taxe agence")]
        [DisplayFormat(DataFormatString = "{0} %")]
        public decimal Agency_taxe { get; set; }


    }
}