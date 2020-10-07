namespace NetFull.ODataTest.Models
{
    using System;
    using System.Linq;

    public interface IProductRepository : IDisposable
    {
        IQueryable<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);
    }
}