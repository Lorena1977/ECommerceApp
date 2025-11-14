using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class ECommerceContext : DbContext //Hereda de la clase Data.Entity.
    {

        //Creamos el constructor que invoca al constructor de la superClase que llama
        // a nuestra conexión DefaultConéxion. Cada basae de datos necesita un contexto de datos
        //Con esto mi aplicación se conecta a mi base de datos.
        public ECommerceContext() : base("DefaultConnection")
        {
              
        }

        public DbSet<ECOMMERCE.Models.Department> Departments { get; set; }//Modelo que estamos mandando a base de datos

        public System.Data.Entity.DbSet<ECOMMERCE.Models.City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //Para impedir el borrado en cascada (departamento con registros relacionados)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<ECOMMERCE.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ECOMMERCE.Models.User> Users { get; set; }
    }
}