using FluentValidation;
using ShopWebApi.Models;

namespace ShopWebApi.Validators
{
    public class ShopItemValidator : AbstractValidator<ShopItem>
    {
        public ShopItemValidator()
        {
            RuleFor(shopItem => shopItem.Name).Length(4, 50);
            RuleFor(shopItem => shopItem.ItemPrice).GreaterThan(0M);
        }
    }
}
