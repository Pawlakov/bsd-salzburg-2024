// <copyright file="CreateMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.CreateMunicipalityCommand;

using System.Linq;
using MediatR;

public class CreateMunicipalityCommand : IRequest<int>
{
    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }

    public bool IsValid
    {
        get
        {
            if (this.PostalCode != null)
            {
                if (this.PostalCode.Length != 0 && this.PostalCode.Length != 4 && this.PostalCode.Length != 5)
                {
                    return false;
                }

                if (this.PostalCode.Any(x => !char.IsDigit(x)))
                {
                    return false;
                }
            }

            if (this.Country != null)
            {
                if (Enums.Country.GetFromIso(this.Country) == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}