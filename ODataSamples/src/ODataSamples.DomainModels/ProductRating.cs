namespace ODataSamples.DomainModels
{
    using System;

    using MedeaOne.Tools.Data;

    public class ProductRating : Entity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public DateTimeOffset RatedOn { get; set; }

        public string Username { get; set; }

        public string Comments { get; set; }

        public virtual Product Product { get; set; }
    }
}