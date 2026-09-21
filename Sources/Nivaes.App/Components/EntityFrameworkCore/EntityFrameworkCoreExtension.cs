using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nivaes.App.EntityFrameworkCore;

public static class EntityFrameworkCoreExtension
{
    public static EntityTypeBuilder<TEntity> ConfigDataModel<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>(
        this EntityTypeBuilder<TEntity> entity)
        where TEntity : DataModel
    {
        entity.Ignore(e => e.DateTimeStamp);

        entity.Property(e => e.DateTimeStampTicks)
            .IsRequired();

        entity.Ignore(e => e.DeleteDataTimeStamp);

        entity.Property(e => e.DeleteDateTimeStampTicks)
           .IsRequired(false);

        return entity;
    }
}
