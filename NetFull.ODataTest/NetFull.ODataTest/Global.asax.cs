namespace NetFull.ODataTest
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(ODataConfig.Register);
        }
    }
}
