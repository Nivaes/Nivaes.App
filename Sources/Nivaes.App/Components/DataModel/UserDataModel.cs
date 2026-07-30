using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nivaes.App;

public abstract class UserDataModel
    : DataModel, IDataModel, INotifyPropertyChanged
{
    [Key]
    public Guid IdUser { get; set; }

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
    public string? GivenName
    {
        get => field;
        set
        {
            if (base.SetProperty(ref field, value))
            {
                base.RaisePropertyChanged(nameof(FullName));
            }
        }
    }

    [StringLength(500)]
    public string? FamilyName
    {
        get => field;
        set
        {
            if (base.SetProperty(ref field, value))
            {
                base.RaisePropertyChanged(nameof(FullName));
            }
        }
    }

    public string FullName => string.Join(" ", new string[] { HonorificNamePrefix ?? string.Empty, GivenName ?? string.Empty, FamilyName ?? string.Empty, HonorificNameSuffix ?? string.Empty }.Where(s => !string.IsNullOrEmpty(s)));

    public string Initials => GivenName?.Substring(0, 1) + FamilyName?.Substring(0, 1);


    [StringLength(30)]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber
    {
        get => field;
        set => base.SetProperty(ref field, value);
    }

    [StringLength(1024)]
    [DataType(DataType.EmailAddress)]
    public string? Email
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
