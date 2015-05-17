using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pai.Startup))]
namespace Pai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
