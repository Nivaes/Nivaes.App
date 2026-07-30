using System.ComponentModel.DataAnnotations;

namespace Nivaes.App;

public sealed class AccountDataModel
    : DataModel
{
    public Guid IdAccount { get; set; }


    [StringLength(20)]
    [ConcurrencyCheck]
    [Required]
    public string? TaxVat
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    [StringLength(10)]
    public string? HonorificNamePrefix
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }


    [StringLength(10)]
    public string? HonorificNameSuffix
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    [StringLength(500)]
    [Required]
    public string? GivenName
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    [StringLength(500)]
    [Required]
    public string? FamilyName
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    public string FullName => string.Join(" ", new string[] { HonorificNamePrefix ?? string.Empty, GivenName ?? string.Empty, FamilyName ?? string.Empty, HonorificNameSuffix ?? string.Empty }.Where(s => !string.IsNullOrEmpty(s)));

    public string Initials => GivenName?.Substring(0, 1) + FamilyName?.Substring(0, 1);

    public string? Email
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    [Required(ErrorMessage = "Ha de especificar un teléfono.")]
    public string? PhoneNumber
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    public string? ProfileAvatar
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }
}
