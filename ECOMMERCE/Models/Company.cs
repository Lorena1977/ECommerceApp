using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Company
    {
        //Atributos de la compañia (Id y nombre)
        [Key] //Le dice que el CompanyID es la clave de la tabla
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "Company")] //Que muestre el literal "Department".
        [Index("Company_Name_Index", IsUnique = true)] //que el nombre sea único en la tabla Departamentos
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        public string Address { get; set; }


        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "Yuo must select a {0}")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "Yuo must select a {0}")]
        public int CityId { get; set; }

        [NotMapped]//Para que no lleve el campo a la base de datos
        public HttpPostedFileBase LogoFile { get; set; }

        //Definimos las relaciones entre los campos.
        public virtual Department Deparment { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}