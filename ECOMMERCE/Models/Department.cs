using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Department
    {
        //Atributos del departamento (Id y nombre)
        [Key] //Le dice que el DepartamentoID es la clave de la tabla
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "Department")] //Que muestre el literal "Department".
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; } //ICollection: Implementación de una Interface. Un departamente tiene varias Cities. (relación uno a muchos)
    }
}