using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videly.Startup))]
namespace Videly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
