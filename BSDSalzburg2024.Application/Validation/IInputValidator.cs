namespace BSDSalzburg2024.Application.Validation;

using FluentValidation;

public interface IInputValidator<T>
    : IValidator<T>
{
}
