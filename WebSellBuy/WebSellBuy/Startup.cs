using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSellBuy.Startup))]
namespace WebSellBuy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
