using System;
using System.Collections.Generic;
using System.Text;

namespace GameLoanManagerCore.DTOS
{
    public class RespGameDTO : GameDTO
    {
        public bool status { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
    }
}
