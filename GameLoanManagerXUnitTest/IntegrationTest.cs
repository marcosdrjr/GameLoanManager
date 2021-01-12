using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System;
using GameLoanManagerAPI.Business.DAO;
using System.Linq;

namespace GameLoanManagerXUnitTest
{
    public class IntegrationTest
    {
        [Fact]
        public void ValidateStartIntegrationTest()
        {
            string ret = "NoAccept";
            if (true)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task IntegrationDataBaseTest()
        {
            GameSQL _sqlgame = new GameSQL();
            string ret = "NoAccept";
            var retApi = await _sqlgame.GetGame();

            if (retApi.Any())
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
    }
}
