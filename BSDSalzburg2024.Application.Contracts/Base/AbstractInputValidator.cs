// <copyright file="AbstractInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

using FluentValidation;

public abstract class AbstractInputValidator<T>
    : AbstractValidator<T>, IInputValidator<T>
{
}