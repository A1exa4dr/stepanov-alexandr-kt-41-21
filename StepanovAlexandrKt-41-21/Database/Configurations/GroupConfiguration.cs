using StepanovAlexandrKt_41_21.Database.Helpers;
using StepanovAlexandrKt_41_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StepanovAlexandrKt_41_21.Database.Helpers;

namespace StepanovAlexandrKt_41_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.GroupId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название группы");

            builder.ToTable(TableName);
        }
    }
}
