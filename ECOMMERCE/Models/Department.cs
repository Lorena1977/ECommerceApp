using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class Department
    {
        //Atributos del departamento (Id y nombre)
        [Key] //Le dice que el DepartamentoID es la clave de la tabla
        public int DepartmentId { get; set; }

        //Incluimos DataNotations al campo Nombre.
        [Required(ErrorMessage = "The field {0} is required")] //El nombre es un campo obligatorio
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters length")] //Longitud del campo
        [Display(Name = "Department")] //Que muestre el literal "Department".
        [Index("Department_Name_Index", IsUnique = true)] //que el nombre sea un íncide único en la tabla Departamentos
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; } //ICollection: Implementación de una Interface. Un departamento
                                                              //tiene varias Cities. (relación uno a muchos)
       
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}