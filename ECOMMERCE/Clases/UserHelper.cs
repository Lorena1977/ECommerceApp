using ECOMMERCE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;

namespace ECOMMERCE.Clases
{
    public class UserHelper : IDisposable //Implementamos IDisposable porque necesito dos contextos de datos
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext(); //Para conectarnos a la seguridad integrada
        private static ECommerceContext db = new ECommerceContext();


        //Chequea el Rol y Crea el Role si no existe (Tendremos 2 el usuario y el administrador)
        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        //Garantiza que exista el usuario SuperUsuario y que tenga el role administrador.
        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, "Admin", password); //Crea el usuario si no existe.
                return;
            }

            userManager.AddToRole(userASP.Id, "Admin"); //Garantiza que si existe el usuario tenga el role de admin
        }

        //Método que crea el SuperUsuario.
        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);
        }

        //Método que crea un usuario con su role y password.
        public static void CreateUserASP(string email, string roleName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, roleName);
        }

        public static async Task PasswordRecovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }

            var user = db.Users.Where(tp => tp.UserName == email).FirstOrDefault();
            if (user == null)
            {
                return;
            }

            var random = new Random();
            var newPassword = string.Format("{0}{1}{2:04}*",
                user.FirstName.Trim().ToUpper().Substring(0, 1),
                user.LastName.Trim().ToLower(),
                random.Next(10000));

            userManager.RemovePassword(userASP.Id);
            userManager.AddPassword(userASP.Id, newPassword);

            var subject = "Taxes Password Recovery";
            var body = string.Format(@"
                <h1>Taxes Password Recovery</h1>
                <p>Yor new password is: <strong>{0}</strong></p>
                <p>Please change it for one, that you remember easyly",
                newPassword);

            await MailHelper.SendMail(email, subject, body);
        }

        public static bool DeleteUser(string userName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(userName); //Busca si existe el usuario 
            if(userASP == null)
            {
                return false;
            }
            //Lo podemos borrar porque lo ha encontrado
            userManager.Delete(userASP); //Devuelve un identityresult que lo almacenamos
            var response = userManager.Delete(userASP);
            return response.Succeeded; //devuelve verdadero si pudo borrar y falso si no.
        }

        //Método para actualizar el correo.
        public static bool updateUserName(string currentUserName, string newUserName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(currentUserName); //Busca si existe el usuario 
            if (userASP == null)
            {
                return false;
            }
            userASP.UserName = newUserName; //Actualizamos el nombre de usuario
            userASP.Email = newUserName; //Actualizamos el nuevo correo

            var response = userManager.Update(userASP);
            return response.Succeeded;
        }
        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }

    }
}