using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Category
    {
        //Atributos de la categoría
        [Key] //Le dice que el CategoryId es la clave de la tabla
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo       
        [Display(Name = "Category")] //Que muestre el literal "City".
        [Index("Category_CompanyId_Description_Index", 2, IsUnique = true)] 
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "Yuo must select a {0}")]
        [Index("Category_CompanyId_Description_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        //[Required(ErrorMessage = "The field {0} is required")]
        //[Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")] //Para que obligue a cumplimentar un departamento
        //                                                                    //cuando cree una ciudad.
        //[Index("Category_CompanyId_Description_Index", 1, IsUnique = true)]
        //public int CompanyId { get; set; }

        //Creamos las relaciones con Company
        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Products { get; set; } //Una ciudad tiene muchas compañías.
    }
}