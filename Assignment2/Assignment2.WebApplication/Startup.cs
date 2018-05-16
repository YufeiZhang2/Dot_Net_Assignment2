using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment2.WebApplication.Startup))]
namespace Assignment2.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
