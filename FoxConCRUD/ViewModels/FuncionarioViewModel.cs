using FoxConCRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace FoxConCRUD.ViewModels
{
    public class FuncionarioViewModel : Base
    {
        [Display( Name = "Código Departamento" )]
        [Required]
        public int id_departamento { get; set; }

        [Display( Name = "Nome" )]
        [MaxLength( 104 )]
        [Required( ErrorMessage = "Esse campo e obrigatório" )]
        [MinLength( 3 )]
        public string name { get; set; }

        [Required]
        [Range( 1000.00, 99999.99, ErrorMessage = "O salário dever ter valores de 1000,00 a 99999,99" )]
        public decimal salary { get; set; }

        [Required]
        [MinLength( 1 )]
        [MaxLength( 1 )]
        public string gender { get; set; }

        public Departamento Departamento { get; set; }
    }
}