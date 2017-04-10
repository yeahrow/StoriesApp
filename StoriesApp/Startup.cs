using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoriesApp.Startup))]
namespace StoriesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
