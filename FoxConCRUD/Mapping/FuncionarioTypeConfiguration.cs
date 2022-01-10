using FoxConCRUD.Models;

namespace FoxConCRUD.Mapping
{
    public class FuncionarioTypeConfiguration : TypeConfiguration<Funcionario>
    {
        public override void ColumnName()
        {
            Property( x => x.id ).HasDatabaseGeneratedOption( System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity );
            Property( x => x.id_departamento ).IsRequired();
            Property( x => x.name ).HasMaxLength( 104 ).IsRequired();
            Property( x => x.active ).HasMaxLength( 1 ).IsRequired();
            Property( x => x.salary ).HasPrecision( 10, 2 ).IsRequired();
            Property( x => x.gender ).HasMaxLength( 1 ).IsRequired();
            Property( x => x.created_at ).IsRequired();
            Property( x => x.modifield_at ).IsOptional();
        }

        public override void ForeignKey()
        {
            HasRequired( x => x.Departamento ).WithMany( x => x.Funcionarios ).HasForeignKey( x => x.id_departamento ).WillCascadeOnDelete( false );
        }

        public override void PrimaryKey()
        {
            HasKey( x => x.id );
        }

        public override void TableName()
        {
            ToTable( "FUNCIONARIOS", "SYSTEM" );
        }
    }
}