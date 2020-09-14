using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vemianou.Startup))]
namespace Vemianou
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
