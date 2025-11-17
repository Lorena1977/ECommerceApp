using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Tax
    {
    //Atributos de los impuestos
    [Key] //Le dice que el TaxId es la clave de la tabla
    public int TaxId { get; set; }


    [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
    [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo       
    [Display(Name = "Tax")] //Que muestre el literal "City".
    [Index("Tax_CompanyId_Description_Index", 2, IsUnique = true)]
    public string Description { get; set; }

    [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
    [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
    [Range(0, 1, ErrorMessage = "You must select a {0} between {1} and {2}")]
    public double Rate { get; set; }

    [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
    [Range(1, double.MaxValue, ErrorMessage = "Yuo must select a {0}")]
    [Index("Tax_CompanyId_Description_Index", 1, IsUnique = true)]
    [Display(Name = "Company")]
    public int CompanyId { get; set; }

   

    //Creamos las relaciones con Company
    public virtual Company Company  { get; set; }
    public virtual ICollection<Product> Products { get; set; } 

    }
}