using FluentValidation;
using course3_s1_lab1_web.DTOs;

namespace course3_s1_lab1_web.Validators;

public class CarCreateDtoValidator : AbstractValidator<CarCreateDto>
{
    public CarCreateDtoValidator()
    {
        RuleFor(x => x.ModelName)
            .NotEmpty().WithMessage("Назва моделі машини не може бути порожньою.")
            .MaximumLength(50).WithMessage("Назва моделі машини не може перевищувати 50 символів.");

        RuleFor(x => x.FactoryId)
            .GreaterThan(0).WithMessage("FactoryId повинен бути більшим за 0.");
    }
}