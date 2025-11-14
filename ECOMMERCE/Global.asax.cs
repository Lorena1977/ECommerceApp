using ECOMMERCE.Clases;
using ECOMMERCE.Migrations;
using ECOMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECOMMERCE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Migra automaticamente los cambios en la base de datos
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ECommerceContext,Configuration>());
            //Me aseguro que mi aplicación tenga los roles y tenga un superUsuario
            CheckRolesAndSuperUser();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }

        private void CheckRolesAndSuperUser()
        {
            UserHelper.CheckRole("Admin");
            UserHelper.CheckRole("User");
        }
    }
}
