using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectKoelkast.Startup))]
namespace ProjectKoelkast
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
