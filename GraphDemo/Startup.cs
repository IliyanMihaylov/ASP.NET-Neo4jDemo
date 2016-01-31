using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraphDemo.Startup))]
namespace GraphDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
