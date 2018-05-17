using Microsoft.Owin;
using Owin;
using System;
using System.IO;

[assembly: OwinStartupAttribute(typeof(Assignment2.WebApplication.Startup))]
namespace Assignment2.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Assignment2.Database"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            ConfigureAuth(app);
        }
    }
}
