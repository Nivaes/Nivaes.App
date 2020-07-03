namespace Nivaes
{
    using FluentValidation;

    public class NewAccountValidator
        : AbstractValidator<NewAccountModel>
    {
        public NewAccountValidator()
        {
            _ = base.RuleFor(x => x.Account).NotNull().SetValidator(new AccountValidator());
            _ = base.RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es requerida");
            _ = base.RuleFor(x => x.Password).MinimumLength(7).WithMessage("La contraseña ha de tener al menos 7 caracteres");
        }
    }
}
