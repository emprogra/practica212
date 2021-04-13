using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebWork.Startup))]
namespace WebWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
