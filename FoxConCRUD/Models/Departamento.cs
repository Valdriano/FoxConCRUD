using System.Collections.Generic;

namespace FoxConCRUD.Models
{
    public class Departamento : Base
    {
        public Departamento()
        {
            Funcionarios = new List<Funcionario>();
        }

        public string name { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}