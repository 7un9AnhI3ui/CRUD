namespace CRUD
{
    public class ProductModels
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public int Quantity { get; set; }
        public double Money { get; set; }

        public ProductModels(string? name, string? color, string? type, int quantity, double money)
        {
            Name = name;
            Color = color;
            Type = type;
            Quantity = quantity;
            Money = money;
        }
    }
}