using System.Web.Http;

using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(ODataSamples.Startup))]

namespace ODataSamples
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            DIConfig.Register(httpConfiguration);
            ODataConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}