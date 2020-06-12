namespace Nivaes
{
    using FluentValidation;

    public class AccountValidator
        : AbstractValidator<AccountDataModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.TaxVat).NotEmpty().When(x => string.IsNullOrEmpty(x.TaxVat)).WithMessage("Se requiere identificación fiscal");
            RuleFor(x => x.PersonalName).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.FamilyName).NotEmpty().WithMessage("Los apellidos son requeridos");
            RuleFor(x => x.Email).NotEmpty().WithMessage("El email es requido");
            RuleFor(x => x.Email).EmailAddress().WithMessage("No es un email valido");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("El teléfono es requerido");
            RuleFor(x => x.PhoneNumber).Length(9, 12).WithMessage("No es un teléfono valido");
        }
    }
}
