namespace PizzaPlace.Client
{
    using System.Text.Json;

    public static class DebuggingExtensions
    {
        public static string ToJson(this object obj)
            => JsonSerializer.Serialize(obj, obj.GetType());
    }
}