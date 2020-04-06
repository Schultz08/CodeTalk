using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Brain_code.Startup))]
namespace Brain_code
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
