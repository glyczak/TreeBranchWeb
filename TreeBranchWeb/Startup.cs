using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeBranchWeb.Startup))]
namespace TreeBranchWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
