// <copyright file="TemplateValidationMessage.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.WebUI.Shared;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

public class TemplateValidationMessage<TValue>
    : ComponentBase, IDisposable
{
    private readonly EventHandler<ValidationStateChangedEventArgs> validationStateChangedHandler;
    private EditContext previousEditContext;
    private Expression<Func<TValue>> previousFieldAccessor;
    private FieldIdentifier fieldIdentifier;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    [CascadingParameter]
    EditContext CurrentEditContext { get; set; }

    [Parameter]
    public Expression<Func<TValue>> For { get; set; }

    public TemplateValidationMessage()
    {
        this.validationStateChangedHandler = (sender, eventArgs) => this.StateHasChanged();
    }

    protected override void OnParametersSet()
    {
        if (this.CurrentEditContext == null)
        {
            throw new InvalidOperationException($"{this.GetType()} requires a cascading parameter " +
                $"of type {nameof(EditContext)}. For example, you can use {this.GetType()} inside " +
                $"an {nameof(EditForm)}.");
        }

        if (this.For == null)
        {
            throw new InvalidOperationException($"{this.GetType()} requires a value for the " +
                $"{nameof(this.For)} parameter.");
        }
        else if (this.For != this.previousFieldAccessor)
        {
            this.fieldIdentifier = FieldIdentifier.Create(this.For);
            this.previousFieldAccessor = this.For;
        }

        if (this.CurrentEditContext != this.previousEditContext)
        {
            this.DetachValidationStateChangedListener();
            this.CurrentEditContext.OnValidationStateChanged += this.validationStateChangedHandler;
            this.previousEditContext = this.CurrentEditContext;
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        foreach (var message in this.CurrentEditContext.GetValidationMessages(this.fieldIdentifier))
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "validation-message");
            builder.AddMultipleAttributes(2, this.AdditionalAttributes);
            builder.AddContent(3, message);
            builder.CloseElement();
        }
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    void IDisposable.Dispose()
    {
        this.DetachValidationStateChangedListener();
        this.Dispose(true);
    }

    private void DetachValidationStateChangedListener()
    {
        if (this.previousEditContext != null)
        {
            this.previousEditContext.OnValidationStateChanged -= this.validationStateChangedHandler;
        }
    }
}