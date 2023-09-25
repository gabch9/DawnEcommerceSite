using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DawnShoesV2.Startup))]
namespace DawnShoesV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
