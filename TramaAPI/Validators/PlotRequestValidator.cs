using FluentValidation;
using TramaAPI.Models;

namespace TramaAPI.Validators
{
    public class PlotRequestValidator : AbstractValidator<PlotRequest>
    {
        public PlotRequestValidator()
        {
            RuleFor(x => x.startDate).NotEmpty().WithMessage("La fecha inicial es requerida.");
            RuleFor(x => x.endDate).NotEmpty().WithMessage("La fecha final es requerida.");
            RuleFor(x => x.plotTypes).IsInEnum().WithMessage("El tipo de trama no es válido.");
        }
    }
}
