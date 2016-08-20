using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS.Www.Startup))]
namespace MIS.Www
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
