using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiLanguageUrlRoute.Startup))]
namespace MultiLanguageUrlRoute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
