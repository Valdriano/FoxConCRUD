using System.Data.Entity.ModelConfiguration;
using FoxConCRUD.Models;

namespace FoxConCRUD.Mapping
{
    public abstract class TypeConfiguration<T> : EntityTypeConfiguration<T> where T : Base
    {
        public TypeConfiguration()
        {
            TableName();
            PrimaryKey();
            ForeignKey();
            ColumnName();
        }

        public abstract void TableName();
        public abstract void PrimaryKey();
        public abstract void ForeignKey();
        public abstract void ColumnName();
    }
}