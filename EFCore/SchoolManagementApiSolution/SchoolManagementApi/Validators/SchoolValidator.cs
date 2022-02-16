using FluentValidation;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.Validators
{
    public class SchoolValidator : AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(school => school.Name)
                .Length(4, 30).WithMessage("Length of {PropertyName} Invalid")
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
