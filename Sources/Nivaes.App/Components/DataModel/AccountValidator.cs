using ValiCraft;
using ValiCraft.Attributes;

namespace Nivaes.App;

[GenerateValidator]
public partial class AccountValidator
    : Validator<AccountDataModel>
{
    protected override void DefineRules(IValidationRuleBuilder<AccountDataModel> builder)
    {
        builder.Ensure(x => x.TaxVat)
            .IsNotNullOrWhiteSpace()
            .WithMessage("Se requiere identificación fiscal");

        builder.Ensure(x => x.GivenName)
            .IsNotNullOrWhiteSpace()
            .WithMessage("El nombre es requerido");

        builder.Ensure(x => x.FamilyName)
            .IsNotNullOrWhiteSpace()
            .WithMessage("Los apellidos son requeridos");

        builder.Ensure(x => x.Email)
            .IsNotNullOrWhiteSpace()
            .WithMessage("El email es requido");

        builder.Ensure(x => x.Email)
            .IsEmailAddress()
            .WithMessage("No es un email valido");

        builder.Ensure(x => x.PhoneNumber)
            .IsNotNullOrWhiteSpace()
            .WithMessage("El teléfono es requerido");

        builder.Ensure(x => x.PhoneNumber)
            .HasLengthBetween(9, 12)
            .WithMessage("No es un teléfono valido");
    }

}
