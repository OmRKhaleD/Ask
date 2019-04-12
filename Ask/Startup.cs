using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ask.Startup))]
namespace Ask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
