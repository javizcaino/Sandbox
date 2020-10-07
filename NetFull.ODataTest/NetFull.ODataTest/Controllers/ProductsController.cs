namespace NetFull.ODataTest.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;

    using NetFull.ODataTest.Models;

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

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key, ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            queryOptions.Validate(standardValidationSettings);

            IQueryable<Product> result = _repository.GetAll().Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}