namespace ODataSamples.Business
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MedeaOne.Tools.Data;

    using Microsoft.EntityFrameworkCore;

    using ODataSamples.Business.Interfaces;
    using ODataSamples.DomainModels;

    public class ProductsBusinessService : BusinessService<Product>, IProductsBusinessService
    {
        #region Public Constructors

        public ProductsBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Overriden Methods

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <remarks>We override this method because we don't want effective deletions, but logical deletions instead.</remarks>
        /// <param name="keyValues">The primary key values.</param>
        public override void Delete(params object[] keyValues)
        {
            IRepository<Product> repository = UnitOfWork.Repository<Product>();

            Product itemToMarkAsDeleted = repository.Find(keyValues);
            if (itemToMarkAsDeleted == null)
            {
                throw new ItemNotFoundException();
            }

            itemToMarkAsDeleted.DeletedOn = DateTime.Now;

            Update(itemToMarkAsDeleted);
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="keyValues">The primary key values.</param>
        /// <returns>The task for the async operation.</returns>
        public override async Task DeleteAsync(params object[] keyValues)
        {
            IRepository<Product> repository = UnitOfWork.Repository<Product>();

            Product itemToMarkAsDeleted = await repository.FindAsync(keyValues).ConfigureAwait(false);

            if (itemToMarkAsDeleted == null)
            {
                throw new ItemNotFoundException();
            }

            itemToMarkAsDeleted.DeletedOn = DateTime.Now;

            await UpdateAsync(itemToMarkAsDeleted).ConfigureAwait(false);
        }

        #endregion Overriden Methods

        #region Public Methods

        /// <summary>
        /// Rates the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="username">The username.</param>
        /// <param name="comments">The comments.</param>
        /// <exception cref="ItemNotFoundException">If the item to rate does not exist.</exception>
        public void RateProduct(int productId, int rating, string username, string comments)
        {
            Product itemToRate = base.Retrieve(productId);
            if (itemToRate == null)
            {
                throw new ItemNotFoundException();
            }

            IRepository<ProductRating> ratingRepository = UnitOfWork.Repository<ProductRating>();
            ratingRepository.Add(new ProductRating
            {
                ProductId = productId,
                Rating = rating,
                Username = username,
                Comments = comments,
                RatedOn = DateTime.Now
            });
            UnitOfWork.SaveChanges();
        }

        public void RateProduct(ProductRating rating)
        {
            Product itemToRate = base.Retrieve(rating.ProductId);
            if (itemToRate == null)
            {
                throw new ItemNotFoundException();
            }

            IRepository<ProductRating> ratingRepository = UnitOfWork.Repository<ProductRating>();
            ratingRepository.Add(rating);
            UnitOfWork.SaveChanges();
        }

        public decimal GetMeanProductRating(int productId)
        {
            Product product = RetrieveAll()
                .Include(_ => _.ProductRatings)
                .SingleOrDefault(_ => _.Id.Equals(productId));
            if (product == null)
            {
                throw new ItemNotFoundException();
            }

            if (product.ProductRatings.Count > 0)
            {
                return product.ProductRatings.Sum(r => r.Rating) / product.ProductRatings.Count;
            }

            return 0;
        }

        #endregion Public Methods
    }
}