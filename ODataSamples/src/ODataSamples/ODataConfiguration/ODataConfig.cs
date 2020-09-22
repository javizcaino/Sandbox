namespace ODataSamples.ODataConfiguration
{
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.OData.Edm;

    using ODataSamples.DomainModels;

    public static class ODataConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            RegisterEntitySets(odataBuilder);
            RegisterEntityFunctions(odataBuilder);
            RegisterEntityActions(odataBuilder);

            return odataBuilder.GetEdmModel();
        }

        private static void RegisterEntitySets(ODataConventionModelBuilder builder)
        {
            builder.EntitySet<Product>("Products");
        }

        private static void RegisterEntityFunctions(ODataConventionModelBuilder builder)
        {
            FunctionConfiguration meanRating = builder.EntityType<Product>().Function("MeanProductRating");
            meanRating.Returns<decimal>();
        }

        private static void RegisterEntityActions(ODataConventionModelBuilder builder)
        {
            ActionConfiguration rateAction = builder.EntityType<Product>().Action("Rate");
            rateAction.Parameter<int>("rating").Required();
            rateAction.Parameter<string>("comments").Optional();

            ActionConfiguration rateProductAction = builder.EntityType<Product>().Action("RateProduct");
            rateProductAction.Namespace = "Actions";
            rateProductAction.EntityParameter<ProductRating>("value").Optional();
        }
    }
}