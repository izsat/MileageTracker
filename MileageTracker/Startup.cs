using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MileageTracker.Startup))]
namespace MileageTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
