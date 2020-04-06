using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeTalk.Startup))]
namespace CodeTalk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
