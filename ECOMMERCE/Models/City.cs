using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class City
    {
        //Atributos de la Ciudad (Id y nombre)
        [Key] //Le dice que el CityId es la clave de la tabla
        public int CityId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        
        [Display(Name = "City")] //Que muestre el literal "City".
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } 
}
}