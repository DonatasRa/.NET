using FluentValidation;
using ShopWebApi.Models;

namespace ShopWebApi.Validators
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.Name)
                .Length(4, 50). WithMessage("Length of {PropertyName} Invalid")
                .Must(IsNameValid).WithMessage("{PropertyName} contains Invalid Characters");
        }

        protected bool IsNameValid(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");

            return name.All(char.IsLetter);
        }
    }
}
