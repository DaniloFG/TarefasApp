using TarefasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TarefasApp.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(t => t.DataHora).HasColumnName("DATAHORA").IsRequired();
            builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
            builder.Property(t => t.Prioridade).HasColumnName("PRIORIDADE").IsRequired();
        }
    }
}