using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Product
    {
        //Atributos de los productos
        [Key] //Le dice que el ProductId es la clave de la tabla
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "Yuo must select a {0}")]
        [Index("Product_CompanyId_Description_Index", 1, IsUnique = true)]
        [Index("Product_CompanyId_BarCode_Index", 1, IsUnique = true)] //No puede haber dos códigos de barra por compañia

        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo       
        [Display(Name = "Product")] //Que muestre el literal "City".
        [Index("Product_CompanyId_Description_Index", 2, IsUnique = true)]
        public string Description { get; set; }


        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(13, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo       
        [Display(Name = "Bar Code")] //Que muestre el literal "City".
        [Index("Product_CompanyId_BarCode_Index", 2, IsUnique = true)] //No puede haber dos códigos de barra por compañia
        public string BarCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tax")]
        public int TaxId { get; set; }


        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must select a {0} between {1} and {2}")]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }


        //Creamos las relaciones con Company
        public virtual Company Company { get; set; }
        public virtual Category Category { get; set; }
        public virtual Tax Tax { get; set; }

    }
}