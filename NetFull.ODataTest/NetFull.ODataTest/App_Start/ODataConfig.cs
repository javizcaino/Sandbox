namespace NetFull.ODataTest
{
    using System.Web.Http;

    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;

    using NetFull.ODataTest.Models;

    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            DIConfig.Register(config);

            // Enable default OData Query options
            config
                .Count()
                .Filter()
                .OrderBy()
                .Expand()
                .Select()
                .MaxTop(null)
                .SkipToken();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}