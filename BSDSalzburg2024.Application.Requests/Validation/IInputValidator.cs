// <copyright file="IInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Validation;

using FluentValidation;

public interface IInputValidator<T>
    : IValidator<T>
{
}
