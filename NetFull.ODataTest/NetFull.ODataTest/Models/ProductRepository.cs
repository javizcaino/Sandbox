namespace NetFull.ODataTest.Models
{
    using System;
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private ProductsContext db = new ProductsContext();

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

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}