namespace PizzaPlace.Shared
{
    using System;

    public class Pizza
    {
        #region Public Constructors

        public Pizza(int id, string name, decimal price,
        Spiciness spiciness)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name), "A pizza needs a name!");
            Price = price;
            Spiciness = spiciness;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Id { get; }

        public string Name { get; }

        public decimal Price { get; }

        public Spiciness Spiciness { get; }

        #endregion Public Properties
    }
}