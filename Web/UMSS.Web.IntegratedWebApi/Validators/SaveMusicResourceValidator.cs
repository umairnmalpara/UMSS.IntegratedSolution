using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using UMSS.Web.IntegratedWebApi.Resources;

namespace UMSS.Web.IntegratedWebApi.Validators
{
    public class SaveMusicResourceValidator : AbstractValidator<SaveMusicResource>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("'Name' is mandatory.")
                .MaximumLength(50)
                .WithMessage("'Name' cannot exceed maximum length 50.");

            RuleFor(m => m.ArtistId)
                .NotEmpty()
                .WithMessage("'Artist Id' must not be 0.");
        }
    }
}
