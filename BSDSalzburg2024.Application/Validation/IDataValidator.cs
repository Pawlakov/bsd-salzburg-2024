namespace BSDSalzburg2024.Application.Validation;

using FluentValidation;

public interface IDataValidator<T>
    : IValidator<T>
{
}
