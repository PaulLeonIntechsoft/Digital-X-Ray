using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Digital_X_Ray.Startup))]
namespace Digital_X_Ray
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
