// <copyright file="FluentValidationValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.WebUI.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using BSDSalzburg2024.Application.Validation;
using FluentValidation;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

public class FluentValidationValidator<TModel>
    : ComponentBase
    where TModel : class
{
    private ValidationMessageStore messages;

    [Inject]
    private IEnumerable<IInputValidator<TModel>> Validators { get; set; }

    [CascadingParameter]
    private EditContext CurrentEditContext { get; set; }

    protected override void OnInitialized()
    {
        if (this.CurrentEditContext == null)
        {
            throw new InvalidOperationException($"A cascading parameter of type EditContext is required.");
        }

        this.messages = new ValidationMessageStore(this.CurrentEditContext);
        this.CurrentEditContext.OnValidationRequested += this.ValidateModel;
        this.CurrentEditContext.OnFieldChanged += this.ValidateField;
    }

    private void ValidateModel(object sender, ValidationRequestedEventArgs eventArgs)
    {
        var context = new ValidationContext<TModel>(this.CurrentEditContext.Model as TModel);
        var errors = this.Validators.SelectMany(validator => validator.Validate(context).Errors);

        this.messages.Clear();
        foreach (var error in errors)
        {
            this.messages.Add(this.CurrentEditContext.Field(error.PropertyName), error.ErrorMessage);
        }

        this.CurrentEditContext.NotifyValidationStateChanged();
    }

    private void ValidateField(object sender, FieldChangedEventArgs eventArgs)
    {
        var fieldIdentifier = eventArgs.FieldIdentifier;
        var properties = new[] { fieldIdentifier.FieldName };

        var context = new ValidationContext<TModel>(this.CurrentEditContext.Model as TModel, new PropertyChain(), new MemberNameValidatorSelector(properties));
        var errors = this.Validators.SelectMany(validator => validator.Validate(context).Errors);

        this.messages.Clear(fieldIdentifier);
        foreach (var error in errors)
        {
            this.messages.Add(fieldIdentifier, error.ErrorMessage);
        }

        this.CurrentEditContext.NotifyValidationStateChanged();
    }
}