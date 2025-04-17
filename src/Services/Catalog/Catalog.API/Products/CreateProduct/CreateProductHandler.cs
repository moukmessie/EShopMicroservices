
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, string ImageFile, List<string> Categories) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");
            RuleFor(x => x.ImageFile)
                .NotEmpty()
                .WithMessage("Image file is required.");
            RuleFor(x => x.Categories)
                .NotEmpty()
                .WithMessage("At least one category is required.");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger) : 
        ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            
            logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);

            var product = new Product
            {
               
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                ImageFile = command.ImageFile,
                Categories = command.Categories
            };

            // save the product to the database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
