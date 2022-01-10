using FoxConCRUD.DataContext;
using FoxConCRUD.Models;
using FoxConCRUD.Repository;
using FoxConCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using System.Linq;

namespace FoxConCRUD.Controllers
{
    public class DepartamentoController : Controller
    {
        private FoxDbContext dbContext;
        private IRepository<Departamento> repository;

        public DepartamentoController()
        {
            dbContext = new FoxDbContext();
            repository = new Repository<Departamento>( dbContext );
        }

        public ActionResult Buscar( string filtros )
        {
            IList<DepartamentoViewModel> departamentos = AutoMapper.Mapper.Map<IList<DepartamentoViewModel>>( repository.GetList().Where( x => x.name.Contains( filtros ) ) );

            return View( "Index", departamentos.ToPagedList( 1, 10 ) );
        }

        public ActionResult Index( int? pagina )
        {
            IList<DepartamentoViewModel> departamentos = AutoMapper.Mapper.Map<IList<DepartamentoViewModel>>( repository.GetList() );

            int paginaTamanho = 10;
            int paginaNumero = ( pagina ?? 1 );

            return View( departamentos.ToPagedList( paginaNumero, paginaTamanho ) );
        }

        public ActionResult Create()
        {
            return View( new DepartamentoViewModel { created_at = DateTime.Now } );
        }

        [HttpPost]
        public ActionResult Create( DepartamentoViewModel viewModel, FormCollection collection )
        {
            try
            {
                viewModel.active = collection[ "cbAtivo" ] == "on" ? "A" : "I";
                viewModel.created_at = DateTime.Now;

                if( ModelState.IsValid )
                {
                    var model = AutoMapper.Mapper.Map<Departamento>( viewModel );

                    repository.Insert( model );

                    return RedirectToAction( "Index" );
                }

                return View( viewModel );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit( int id )
        {
            var viewModel = AutoMapper.Mapper.Map<DepartamentoViewModel>( repository.Get( id ) );

            return View( viewModel );
        }

        [HttpPost]
        public ActionResult Edit( DepartamentoViewModel viewModel, FormCollection collection )
        {
            try
            {
                viewModel.active = collection[ "cbAtivo" ] == "on" ? "A" : "I";
                viewModel.modifield_at = DateTime.Now;

                if( ModelState.IsValid )
                {
                    var model = AutoMapper.Mapper.Map<Departamento>( viewModel );

                    var entity = repository.Get( model.id );

                    model.created_at = entity.created_at;

                    repository.Update( model );

                    return RedirectToAction( "Index" );
                }

                return View( viewModel );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete( int id )
        {
            var viewModel = AutoMapper.Mapper.Map<DepartamentoViewModel>( repository.Get( id ) );

            return View( viewModel );
        }

        [HttpPost]
        public ActionResult Delete( DepartamentoViewModel viewModel )
        {
            try
            {
                repository.Delete( AutoMapper.Mapper.Map<Departamento>( viewModel ) );

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }
    }
}
