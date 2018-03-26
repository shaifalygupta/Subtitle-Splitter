using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TitleSplitterWeb.Startup))]
namespace TitleSplitterWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
