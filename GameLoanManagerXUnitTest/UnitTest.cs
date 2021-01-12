using GameLoanManagerAPI.Business.Interfaces;
using GameLoanManagerAPI.Controllers;
using GameLoanManagerCore.DTOS;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GameLoanManagerXUnitTest
{
    public class UnitTest
    {
        
        [Fact]
        public void ValidateStartUnitTest()
        {
            string ret = "NoAccept";
            if (true)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        OnboardingController controller = new OnboardingController();

        //GetGames
        [Fact]
        public async Task GetGamesWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetGames(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task GetGamesWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetGames(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //DeleteGame
        [Fact]
        public async Task DeleteGameWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteGame(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task DeleteGameWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteGame(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //addGames
        [Fact]
        public async Task addGamesWhithIdTests_1()
        {
            string ret = "NoAccept";
            GameDTO gameDTO = new GameDTO();
            gameDTO.id = 0; gameDTO.name = ""; gameDTO.description = "";

            var retApi = await controller.addGames(null, gameDTO, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task addGamesWhithIdTests_2()
        {
            string ret = "NoAccept";
            GameDTO gameDTO = new GameDTO();
            gameDTO.id = 0; gameDTO.name = null; gameDTO.description = null;

            var retApi = await controller.addGames(null, gameDTO, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //PutGames
        [Fact]
        public async Task PutGamesWhithIdTests_1()
        {
            string ret = "NoAccept";
            GameDTO gameDTO = new GameDTO();
            gameDTO.id = 0; gameDTO.name = ""; gameDTO.description = "";

            var retApi = await controller.PutGames(null, gameDTO, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task PutGamesWhithIdTests_2()
        {
            string ret = "NoAccept";
            GameDTO gameDTO = new GameDTO();
            gameDTO.id = 0; gameDTO.name = null; gameDTO.description = null;

            var retApi = await controller.PutGames(null, gameDTO, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //GetProfile
        [Fact]
        public async Task GetProfileWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetProfile(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task GetProfileWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetProfile(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //DeleteProfile
        [Fact]
        public async Task DeleteProfileWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteProfile(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task DeleteProfileWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteProfile(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //addProfile
        [Fact]
        public async Task addProfileWhithIdTests_1()
        {
            string ret = "NoAccept";
            ProfileDTO dto = new ProfileDTO();
            dto.id = 0; dto.name = ""; dto.description = "";

            var retApi = await controller.addProfile(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task addProfileWhithIdTests_2()
        {
            string ret = "NoAccept";
            ProfileDTO dto = new ProfileDTO();
            dto.id = 0; dto.name = null; dto.description = null;

            var retApi = await controller.addProfile(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //PutProfile
        public async Task PutProfileWhithIdTests_1()
        {
            string ret = "NoAccept";
            ProfileDTO dto = new ProfileDTO();
            dto.id = 0; dto.name = ""; dto.description = "";

            var retApi = await controller.PutProfile(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task PutProfileWhithIdTests_2()
        {
            string ret = "NoAccept";
            ProfileDTO dto = new ProfileDTO();
            dto.id = 0; dto.name = null; dto.description = null;

            var retApi = await controller.PutProfile(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //GetIndividuo
        [Fact]
        public async Task GetIndividuoWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetIndividuo(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task GetIndividuoWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetIndividuo(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //DeleteIndividual
        [Fact]
        public async Task DeleteIndividualWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteIndividual(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task DeleteIndividualWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteIndividual(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //addIndividuo
        [Fact]
        public async Task addIndividuoWhithIdTests_1()
        {
            string ret = "NoAccept";
            IndividualDTO dto = new IndividualDTO();
            dto.id = 0; dto.name = null; dto.cpf = null;

            var retApi = await controller.addIndividuo(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task addIndividuoWhithIdTests_2()
        {
            string ret = "NoAccept";
            IndividualDTO dto = new IndividualDTO();
            dto.id = 0; dto.name = null; dto.cpf = null;

            var retApi = await controller.addIndividuo(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //PutIndividuo
        [Fact]
        public async Task PutIndividuoWhithIdTests_1()
        {
            string ret = "NoAccept";
            IndividualDTO dto = new IndividualDTO();
            dto.id = 0; dto.name = null; dto.cpf = null;

            var retApi = await controller.PutIndividuo(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task PutIndividuoWhithIdTests_2()
        {
            string ret = "NoAccept";
            IndividualDTO dto = new IndividualDTO();
            dto.id = 0; dto.name = null; dto.cpf = null;

            var retApi = await controller.PutIndividuo(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //GetGameLoan
        [Fact]
        public async Task GetGameLoanWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetGameLoan(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task GetGameLoanWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.GetGameLoan(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //DeleteGameLoan
        [Fact]
        public async Task DeleteGameLoanWhithIdTests_1()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteGameLoan(null, 0, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task DeleteGameLoanWhithIdTests_2()
        {
            string ret = "NoAccept";
            var retApi = await controller.DeleteGameLoan(null, 0);
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }

        //AddGameLoanAsync
        [Fact]
        public async Task AddGameLoanAsyncWhithIdTests_1()
        {
            string ret = "NoAccept";
            GameLoanDTO dto = new GameLoanDTO();
            dto.id = 0; dto.id_individual = 0; dto.id_game = 0 ; dto.description = "";

            var retApi = await controller.addGameLoan(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task AddGameLoanAsyncWhithIdTests_2()
        {
            string ret = "NoAccept";
            GameLoanDTO dto = new GameLoanDTO();
            dto.id = 0; dto.id_individual = 0; dto.id_game = 0; dto.description = null;

            var retApi = await controller.addGameLoan(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        //PutGameLoan
        [Fact]
        public async Task PutGameLoanWhithIdTests_1()
        {
            string ret = "NoAccept";
            GameLoanDTO dto = new GameLoanDTO();
            dto.id = 0; dto.id_individual = 0; dto.id_game = 0; dto.description = "";

            var retApi = await controller.PutGameLoan(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
        [Fact]
        public async Task PutGameLoanWhithIdTests_2()
        {
            string ret = "NoAccept";
            GameLoanDTO dto = new GameLoanDTO();
            dto.id = 0; dto.id_individual = 0; dto.id_game = 0; dto.description = null;

            var retApi = await controller.PutGameLoan(null, dto, "v0");
            if (((Microsoft.AspNetCore.Mvc.ObjectResult)retApi.Result).StatusCode == 400)
            {
                ret = "Accept";
            }
            Equals("Accept", ret);
        }
    }
}
