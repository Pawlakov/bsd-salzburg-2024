// <copyright file="IInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

using FluentValidation;

public interface IInputValidator<T>
    : IValidator<T>
{
}
