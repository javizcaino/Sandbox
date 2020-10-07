namespace ODataSamples.Models
{
    using System.Data.Entity;

    public class ProductsContext : DbContext
    {
        public ProductsContext()
                : base("name=ProductsDatabase")
        {
#if DEBUG
            Database.Log = s => System.Diagnostics.Debug.Write(s);
#endif
        }

        public DbSet<Product> Products { get; set; }
    }
}