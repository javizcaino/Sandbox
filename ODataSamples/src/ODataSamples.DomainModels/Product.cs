namespace ODataSamples.DomainModels
{
    using System;
    using System.Collections.Generic;

    using MedeaOne.Tools.Data;

    public class Product : Entity
    {
        public Product()
        {
            ProductRatings = new HashSet<ProductRating>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LastUpdatedOn { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }

        public virtual ICollection<ProductRating> ProductRatings { get; set; }
    }
}
