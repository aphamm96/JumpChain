using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JumpChain.WebMVC.Startup))]
namespace JumpChain.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
