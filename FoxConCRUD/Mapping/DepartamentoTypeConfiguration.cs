using FoxConCRUD.Models;

namespace FoxConCRUD.Mapping
{
    public class DepartamentoTypeConfiguration : TypeConfiguration<Departamento>
    {
        public override void ColumnName()
        {
            Property( x => x.id ).HasDatabaseGeneratedOption( System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity );
            Property( x => x.name ).HasMaxLength( 54 ).IsRequired();
            Property( x => x.active ).HasMaxLength( 1 ).IsRequired();
            Property( x => x.created_at ).IsRequired();
            Property( x => x.modifield_at ).IsOptional();
        }

        public override void ForeignKey()
        {
            //throw new NotImplementedException();
        }

        public override void PrimaryKey()
        {
            HasKey( x => x.id );
        }

        public override void TableName()
        {
            ToTable( "DEPARTAMENTOS", "SYSTEM" );
        }
    }
}