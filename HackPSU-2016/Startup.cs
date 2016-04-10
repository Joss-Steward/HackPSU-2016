using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HackPSU_2016.Startup))]
namespace HackPSU_2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
