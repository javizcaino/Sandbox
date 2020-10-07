namespace NetCore.ODataTest.Controllers
{
    using System.Linq;

    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;

    using NetCore.ODataTest.Models;

    public class ProductsController : ODataController
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// The standard validation settings for OData Controllers.
        /// </summary>
        protected static ODataValidationSettings standardValidationSettings = new ODataValidationSettings
        {
            AllowedQueryOptions = AllowedQueryOptions.All,
            AllowedFunctions = AllowedFunctions.AllFunctions,
            MaxExpansionDepth = 20
        };

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        public IQueryable<Product> Get(ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            queryOptions.Validate(standardValidationSettings);
            return _repository.GetAll();
        }
    }
}
