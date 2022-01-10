using AutoMapper;
using FoxConCRUD.Models;
using FoxConCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoxConCRUD.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Departamento, DepartamentoViewModel>();
            CreateMap<DepartamentoViewModel, Departamento>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<FuncionarioViewModel, Funcionario>();
        }
    }
}