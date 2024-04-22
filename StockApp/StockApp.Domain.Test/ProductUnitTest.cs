using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Teste Positivo
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "Product Imagem", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInValidName()
        {
            Action action = () => new Product(1, "", "Product Description", 1, 1, "Product Imagem", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidName()
        {
            Action action = () => new Product(1, "Lorem ipsum dolor sit amet. Rem enim delectus ex veniam rerum nam assumenda animi ea nostrum repudiandae in fugiat exercitationem? Est rerum autem nam blanditiis voluptas a accusantium sequi non beatae nihil. Sit natus culpa sed consequatur ipsa non omnis maxime vel repellendus dignissimos rem repellendus expedita.", "Product Description", 1, 1, "Product Imagem", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidMaxName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 1, 1, "Product Imagem", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Descriprion")]
        public void CreateProduct_WithNullParameters_DomainExceptionInValidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 1, 1, "Product Imagem", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product Whith Invalid State Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionValidationMaxPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 999999999.99m, 1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price, too long, max value 9999999.99.");
        }

            [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, -1, "Product Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Image")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInValidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, "Lorem ipsum dolor sit amet. Rem enim delectus ex veniam rerum nam assumenda animi ea nostrum repudiandae in fugiat exercitationem? Est rerum autem nam blanditiis voluptas a accusantium sequi non beatae nihil. Sit natus culpa sed consequatur ipsa non omnis maxime vel repellendus dignissimos rem repellendus expedita. Est perferendis neque sed dicta mollitia qui facere magni nam nulla sunt.\r\n\r\nSed veniam voluptas eum eveniet magni et exercitationem odit eos nihil neque in earum praesentium. Est nostrum nesciunt sit delectus explicabo quo enim maiores aut internos asperiores eos officia deserunt. Sed molestiae repudiandae non autem odit quo consequuntur distinctio ut quod voluptatum qui molestiae vitae ut officia maxime.", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}