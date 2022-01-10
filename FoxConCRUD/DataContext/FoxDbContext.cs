using FoxConCRUD.Mapping;
using FoxConCRUD.Models;
using System.Data.Entity;

namespace FoxConCRUD.DataContext
{
    public class FoxDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public FoxDbContext() : base( nameOrConnectionString: "OracleCon" )
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Configurations.Add( new DepartamentoTypeConfiguration() );
            modelBuilder.Configurations.Add( new FuncionarioTypeConfiguration() );

            base.OnModelCreating( modelBuilder );
        }
    }
}