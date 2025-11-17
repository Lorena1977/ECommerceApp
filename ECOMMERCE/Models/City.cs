using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Index("City_Department_Name_Index", 2, IsUnique = true)] 
        public string Name { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")] //Para que obligue a cumplimentar un departamento
                                                                            //cuando cree una ciudad.
        [Index("City_Department_Name_Index",1,  IsUnique = true)]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } //Crea la relación de varias ciudades 1 Departamento.


        public virtual ICollection<Company> Companies { get; set; } //Una ciudad tiene muchas compañías.
        public virtual ICollection<User> Users { get; set; }//Una ciudad tiene muchos usuarios
    }
}