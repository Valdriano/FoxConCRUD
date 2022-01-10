using FoxConCRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoxConCRUD.ViewModels
{
    public class DepartamentoViewModel : Base
    {
        public DepartamentoViewModel()
        {
            Funcionarios = new List<Funcionario>();
        }

        [Display( Name = "Descrição" )]
        [MaxLength( 54 )]
        [Required( ErrorMessage = "Esse campo e obrigatório" )]
        [MinLength( 2 )]
        public string name { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}