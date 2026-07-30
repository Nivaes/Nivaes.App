using ValiCraft;
using ValiCraft.Attributes;

namespace Nivaes.App;

[GenerateValidator]
public partial class NewAccountValidator
    : Validator<NewAccountModel>
{

    protected override void DefineRules(IValidationRuleBuilder<NewAccountModel> builder)
    {
        builder.Ensure(x => x.Account)
            .IsNotNull()!
            .ValidateWith(new AccountValidator());

        builder.Ensure(x => x.Password)
            .IsNotNullOrWhiteSpace()
            .WithMessage("La contraseña es requerida");

        builder.Ensure(x => x.Password)
            .IsNotNullOrWhiteSpace()
            .HasMinCount(7)
            .WithMessage("La contraseña ha de tener al menos 7 caracteres");
    }
}
