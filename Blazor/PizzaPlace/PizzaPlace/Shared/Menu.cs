namespace PizzaPlace.Shared
{
    using System.Collections.Generic;
    using System.Linq;

    public class Menu
    {
        public List<Pizza> Pizzas { get; set; }
            = new List<Pizza>();

        public Pizza GetPizza(int id)
        {
            return Pizzas.SingleOrDefault(pizza => pizza.Id == id);
        }
    }
}