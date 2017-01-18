using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Election.Startup))]

namespace Election
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
