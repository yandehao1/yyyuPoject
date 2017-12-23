using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yyyuWEB.Startup))]
namespace yyyuWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
