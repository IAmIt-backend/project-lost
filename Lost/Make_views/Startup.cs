using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Make_views.Startup))]
namespace Make_views
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
