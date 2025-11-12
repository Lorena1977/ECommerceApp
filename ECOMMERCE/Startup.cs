using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECOMMERCE.Startup))]
namespace ECOMMERCE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
