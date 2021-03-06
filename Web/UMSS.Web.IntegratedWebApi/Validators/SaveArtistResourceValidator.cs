﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using UMSS.Web.IntegratedWebApi.Resources;

namespace UMSS.Web.IntegratedWebApi.Validators
{
    public class SaveArtistResourceValidator : AbstractValidator<SaveArtistResource>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("'Name' is mandatory.")
                .MaximumLength(50)
                .WithMessage("'Name' cannot exceed maximum length 50.");
        }
    }
}
