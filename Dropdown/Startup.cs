using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dropdown.Startup))]
namespace Dropdown
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
