using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cube.Mlm.Startup))]
namespace Cube.Mlm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
