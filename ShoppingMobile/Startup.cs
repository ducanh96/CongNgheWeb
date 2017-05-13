using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingMobile.Startup))]
namespace ShoppingMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
