using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "Product Image", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidMaxName()
        {
            Action action = () => new Product(1, "Product Name paskpoaksopaopsaoskaopskpoakspakspakspaskpaskpaksokspaokspaoskpaosaoskpoaksopakospakopskoaskpoakspoksopakpskapskapskakspoaks", "Product Description", 1, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidMaxPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 99999999.99m, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, -1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Image")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        #endregion
    }
}