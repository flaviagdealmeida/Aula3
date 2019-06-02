using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto1.Entity
{
    public class Dependentes
    {
        public int IdDependentes { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Funcionario Funcionario { get; set; }
    }


}
