using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SilverScreener.Startup))]
namespace SilverScreener
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
