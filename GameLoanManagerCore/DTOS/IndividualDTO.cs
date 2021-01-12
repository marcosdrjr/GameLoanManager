using System;
using System.Collections.Generic;
using System.Text;

namespace GameLoanManagerCore.DTOS
{
    public class IndividualDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public string guid { get; set; }
        public string password { get; set; }
        public int id_profile { get; set; }
    }
}
