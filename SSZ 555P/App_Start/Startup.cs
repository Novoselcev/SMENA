using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(SSZ.App_Start.Startup))]
namespace SSZ.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}