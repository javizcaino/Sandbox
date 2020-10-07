namespace NetCore.ODataTest.Models
{
    using System.Linq;

    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);
    }
}