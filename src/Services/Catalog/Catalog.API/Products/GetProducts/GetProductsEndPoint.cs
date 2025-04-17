﻿namespace Catalog.API.Products.GetProducts
{
    //publiic record GetProductsRequest()
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var query = new GetProductsQuery();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);

            })
                .WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .WithTags("Products")
                .WithSummary("Get all products")
                .WithDescription("Get all products");

        }
    

    }
}
