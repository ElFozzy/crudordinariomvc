using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crud_ordinario.Startup))]
namespace crud_ordinario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
