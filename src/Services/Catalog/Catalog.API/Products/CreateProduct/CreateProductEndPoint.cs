namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, string Description, decimal Price, string ImageFile, List<string> Categories);
    public class CreateProductEndPoint
    {
    }
}
