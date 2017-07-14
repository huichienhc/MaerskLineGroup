using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaerskLineGroup.Startup))]
namespace MaerskLineGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
