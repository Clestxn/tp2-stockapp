using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    #region Testes Positivos
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Category With Invalid State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExcpetionInvalid()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Category With Invalid State")]
        public void CreateCategory_WithInvalidParameters_DomainExcpetionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        [Fact(DisplayName = "Create Category With Null State")]
        public void CreateCategory_WithNullParameters_DomainExcpetionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
        }
        #endregion
    }
}