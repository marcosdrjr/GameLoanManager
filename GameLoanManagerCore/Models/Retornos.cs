using System;
using System.Collections.Generic;
using System.Text;

namespace GameLoanManagerCore.Models
{
    public class Retornos
    {
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string mensagem { get; set; }
        public string excecao { get; set; }
        public string solucao { get; set; }
        public string codAplicacao { get; set; }
        public string observacao { get; set; }
        public Object data { get; set; }
    }
}