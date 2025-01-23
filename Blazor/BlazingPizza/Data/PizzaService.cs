namespace BlazingPizza.Data
{
    public class PizzaService
    {
        public Task<Pizza[]> GetPizzasAsync()
        {
            return Task.FromResult(Array.Empty<Pizza>());
        }
    }
}
