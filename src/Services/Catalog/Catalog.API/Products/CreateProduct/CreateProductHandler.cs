using System.Windows.Input;
using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, string ImageFile, List<string> Categories) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid ID);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // TODO: Implement the logic to create a product
            // creat product entity from the command object
            // save  to the database (not implemented here)
            // return the result with the product ID

            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                ImageFile = command.ImageFile,
                Categories = command.Categories
            };
          
            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
