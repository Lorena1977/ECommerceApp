using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class User
    {
        //Atributos de los Usuarios
        [Key] //Le dice que el UserID es la clave de la tabla
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "First Name")] //Que muestre el literal "First Name".
        public string FirstName { get; set; }


        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "Last Name")] //Que muestre el literal "First Name".
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(256, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "E-Mail")] //Que muestre el literal "First Name".
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
     
        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        //Vamos a crear una propiedad de lectura para concatenar nombre y apellidos.
        [Display(Name = "User")]
        public string FullName { get{return string.Format("{0} {1}", FirstName, LastName);} }//Sin el set no se mapea en la base de datos

        [NotMapped]//Para que no lleve el campo a la base de datos
        public HttpPostedFileBase PhotoFile { get; set; }

        //Definimos las relaciones entre los campos.
        public virtual Department Deparment { get; set; }
        public virtual City City { get; set; }
        public virtual Company Company { get; set; }

    }
}