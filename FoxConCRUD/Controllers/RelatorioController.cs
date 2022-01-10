using FoxConCRUD.DataContext;
using FoxConCRUD.Models;
using FoxConCRUD.Repository;
using FoxConCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoxConCRUD.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult TotalSalario()
        {
            FoxDbContext foxDbContext = new FoxDbContext();

            IRepository<Funcionario> repositoryFuncionario = new Repository<Funcionario>( foxDbContext );
            IRepository<Departamento> repositoryDepartamento = new Repository<Departamento>( foxDbContext );

            List<RelatorioViewModel> LIST = new List<RelatorioViewModel>();

            var temp = (
            from d in repositoryDepartamento.GetList()
            select new
            {
                NOMEDEPARTAMENTO = d.name,
                salary = repositoryFuncionario.GetList().Where( x => x.id_departamento == d.id ).Sum( s => s.salary )
            } ).ToList();

            foreach( var item in temp )
                LIST.Add( new RelatorioViewModel { NOMEDEPARTAMENTO = item.NOMEDEPARTAMENTO, salary = item.salary } );

            return View( LIST );
        }
    }
}