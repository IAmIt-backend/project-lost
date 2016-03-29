using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Make_logic.Startup))]
namespace Make_logic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
