namespace FoxConCRUD.Models
{
    public class Funcionario : Base
    {
        public int id_departamento { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }

        public Departamento Departamento { get; set; }
    }
}