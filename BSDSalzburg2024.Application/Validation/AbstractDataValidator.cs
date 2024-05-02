namespace BSDSalzburg2024.Application.Validation;

using FluentValidation;

public abstract class AbstractDataValidator<T>
    : AbstractValidator<T>, IDataValidator<T>
{
}