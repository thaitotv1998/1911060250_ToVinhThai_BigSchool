using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911060250_ToVinhThai_BigSchool.Startup))]
namespace _1911060250_ToVinhThai_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
