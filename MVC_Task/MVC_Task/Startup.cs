using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Task.Startup))]
namespace MVC_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
