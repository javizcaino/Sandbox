namespace NetCore.ODataTest.Models
{
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext db;

        public ProductRepository(ProductsContext productsContext)
        {
            db = productsContext;
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetById(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}