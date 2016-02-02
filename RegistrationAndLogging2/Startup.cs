using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationAndLogging2.Startup))]
namespace RegistrationAndLogging2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
