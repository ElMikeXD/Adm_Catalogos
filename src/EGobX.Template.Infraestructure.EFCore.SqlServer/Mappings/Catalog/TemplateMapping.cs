using EGobX.NTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGobX.NTemplate.Infraestructure.EFCore.Mappings
{
    internal class TemplateMapping : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Template", Schemas.Catalog);
            builder.HasKey(x => x.Id).HasName("PK_Template_TemplateId");
            builder.Property(x => x.Id).HasColumnName("TemplateId");
            builder.Property(p => p.Folio).UseSqlServerIdentityColumn();
            builder.Property(p => p.Folio).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.AddedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).HasColumnName("Active").IsRequired();
        }
    }
}
