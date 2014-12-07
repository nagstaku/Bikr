using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bikr.Startup))]
namespace Bikr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
