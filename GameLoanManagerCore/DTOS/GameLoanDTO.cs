using System;
using System.Collections.Generic;
using System.Text;

namespace GameLoanManagerCore.DTOS
{
    public class GameLoanDTO
    {
        public int id { get; set; }
        public int id_game { get; set; }
        public int id_individual { get; set; }
        public string description { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
    }
}
