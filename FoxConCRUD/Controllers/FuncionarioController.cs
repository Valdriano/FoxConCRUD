using FoxConCRUD.DataContext;
using FoxConCRUD.Models;
using FoxConCRUD.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using FoxConCRUD.ViewModels;
using System.Linq;

namespace FoxConCRUD.Controllers
{
    public class FuncionarioController : Controller
    {
        private FoxDbContext dbContext;
        private IRepository<Funcionario> repository;
        private IRepository<Departamento> repositoryDepartamento;
        private IList<Sexo> Sexos;

        public FuncionarioController()
        {
            dbContext = new FoxDbContext();
            repository = new Repository<Funcionario>( dbContext );
            repositoryDepartamento = new Repository<Departamento>( dbContext );
            Sexos = new List<Sexo>();

            Sexos.Add( new Sexo { Codigo = "F", Descricao = "Feminino" } );
            Sexos.Add( new Sexo { Codigo = "M", Descricao = "Masculino" } );
        }

        public ActionResult Buscar( string filtros )
        {
            IList<FuncionarioViewModel> viewModel = AutoMapper.Mapper.Map<IList<FuncionarioViewModel>>( repository.GetList().Where( x => x.name.Contains( filtros ) ) );

            return View( "Index", viewModel.ToPagedList( 1, 10 ) );
        }

        public ActionResult Index( int? pagina )
        {
            IList<FuncionarioViewModel> viewModel = AutoMapper.Mapper.Map<IList<FuncionarioViewModel>>( repository.GetList() );

            int paginaTamanho = 10;
            int paginaNumero = ( pagina ?? 1 );

            return View( viewModel.ToPagedList( paginaNumero, paginaTamanho ) );
        }

        public ActionResult Create()
        {
            var viewModel = new FuncionarioViewModel();

            ViewBag.Departamentos = repositoryDepartamento.GetList();
            ViewBag.Sexos = Sexos;

            return View( viewModel );
        }

        [HttpPost]
        public ActionResult Create( FuncionarioViewModel viewModel )
        {
            try
            {
                viewModel.active = "A";
                viewModel.created_at = DateTime.Now;

                if( ModelState.IsValid )
                {
                    var model = AutoMapper.Mapper.Map<Funcionario>( viewModel );

                    repository.Insert( model );

                    return RedirectToAction( "Index" );
                }

                ViewBag.Departamentos = repositoryDepartamento.GetList();
                ViewBag.Sexos = Sexos;

                return View( viewModel );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit( int id )
        {
            ViewBag.Departamentos = repositoryDepartamento.GetList();
            ViewBag.Sexos = Sexos;

            return View( AutoMapper.Mapper.Map<FuncionarioViewModel>( repository.Get( id ) ) );
        }

        [HttpPost]
        public ActionResult Edit( FuncionarioViewModel viewModel )
        {
            try
            {
                viewModel.active = "A";
                viewModel.modifield_at = DateTime.Now;

                if( ModelState.IsValid )
                {
                    var model = AutoMapper.Mapper.Map<Funcionario>( viewModel );

                    repository.Update( model );

                    return RedirectToAction( "Index" );
                }

                ViewBag.Departamentos = repositoryDepartamento.GetList();
                ViewBag.Sexos = Sexos;

                return View( viewModel );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete( int id )
        {
            ViewBag.Departamentos = repositoryDepartamento.GetList();
            ViewBag.Sexos = Sexos;

            return View( AutoMapper.Mapper.Map<FuncionarioViewModel>( repository.Get( id ) ) );
        }

        [HttpPost]
        public ActionResult Delete( FuncionarioViewModel viewModel )
        {
            try
            {
                repository.Delete( AutoMapper.Mapper.Map<Funcionario>( viewModel ) );

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }
    }
}
