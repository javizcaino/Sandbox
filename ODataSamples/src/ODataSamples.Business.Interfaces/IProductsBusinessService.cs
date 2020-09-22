namespace ODataSamples.Business.Interfaces
{
    using ODataSamples.DomainModels;

    public interface IProductsBusinessService : IBusinessService<Product>
    {
        /// <summary>
        /// Rates the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="username">The username.</param>
        /// <param name="comments">The comments.</param>
        /// <exception cref="ItemNotFoundException">If the item to rate does not exist.</exception>
        void RateProduct(int productId, int rating, string username, string comments);

        void RateProduct(ProductRating rating);

        decimal GetMeanProductRating(int productId);
    }
}