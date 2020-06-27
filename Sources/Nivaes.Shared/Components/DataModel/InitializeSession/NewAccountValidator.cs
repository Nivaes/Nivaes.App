namespace Nivaes
{
    using FluentValidation;

    public class NewAccountValidator
        : AbstractValidator<NewAccountModel>
    {
        public NewAccountValidator()
        {
            base.RuleFor(x => x.Account).NotNull().SetValidator(new AccountValidator());
            base.RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es requerida");
            base.RuleFor(x => x.Password).MinimumLength(7).WithMessage("La contraseña ha de tener al menos 7 caracteres");
        }
    }
}
