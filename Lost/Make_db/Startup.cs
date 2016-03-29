using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Make_db.Startup))]
namespace Make_db
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
