using GameLoanManagerAPI.Business.Interfaces;
using GameLoanManagerCore.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Api On-line";
        }

        #region AddDB

        /// <summary>
        /// add games in data base.
        /// </summary>
        /// <param name="game">data game" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("game")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<GameDTO>> addGames(
            [FromServices] IOnboarding Onboarding,
            [FromBody] GameDTO game,
            [FromRoute] string versao = "V0")
        {
            if (
                //game.id == 0 ||
                string.IsNullOrEmpty(game.name )||
                string.IsNullOrEmpty(game.description)
                )
            {
                return BadRequest(new { objectData = game, message = "game is not IsNullOrEmpty" });
            }

            var data = await Onboarding.AddGameAsync(game);
            return data;
        }

        /// <summary>
        /// add individual in data base.
        /// </summary>
        /// <param name="individual">data individual" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("individuo")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<IndividualDTO>> addIndividuo(
            [FromServices] IOnboarding Onboarding,
            IndividualDTO individual, 
            [FromRoute] string versao = "V0")
        {
            if (
                //individual.id == 0 ||
                string.IsNullOrEmpty(individual.name) ||
                string.IsNullOrEmpty(individual.cpf)
                )
            {
                return BadRequest(new { objectData = individual, message = "individual is not IsNullOrEmpty" });
            }

            var data = await Onboarding.AddIndividualAsync(individual);
            if (data.id == 0)
            {
                return Conflict(new { dataObject = data, message = "no accept id profile or incorrect data" });
                //return BadRequest(new { dataObject = data, message = "no accept id profile or incorrect data" });
            }
            return data;
        }

        /// <summary>
        /// add profile in data base.
        /// </summary>
        /// <param name="profile">data profile" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("profile")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<ProfileDTO>> addProfile(
            [FromServices] IOnboarding Onboarding,
            ProfileDTO profile,
            [FromRoute] string versao = "V0")
        {
            if (
                //profile.id == 0 ||
                string.IsNullOrEmpty(profile.name) ||
                string.IsNullOrEmpty(profile.description)
                )
            {
                return BadRequest(new { objectData = profile, message = "profile is not IsNullOrEmpty" });
            }

            var data = await Onboarding.AddProfileAsync(profile);
            return data;
        }

        /// <summary>
        /// add Game Loan in data base.
        /// </summary>
        /// <param name="gameloan">data gameloan" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("gameloan")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<GameLoanDTO>> addGameLoan(
            [FromServices] IOnboarding Onboarding,
            GameLoanDTO gameloan,
            [FromRoute] string versao = "V0")
        {
            if (
               //gameloan.id == 0 ||
               gameloan.id_individual==0 ||
               gameloan.id_game == 0 ||
               string.IsNullOrEmpty(gameloan.description)
               )
            {
                return BadRequest(new { objectData = gameloan, message = "gameloan is not IsNullOrEmpty" });
            }
            var data = await Onboarding.AddGameLoanAsync(gameloan);
            return data;
        }

        #endregion

        #region GetDB

        /// <summary>
        /// get games in data base.
        /// </summary>
        /// <param name="idGame">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("game")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<RespGameDTO>> GetGames(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int idGame,
            [FromRoute] string versao = "V0")
        {
            if (idGame == 0)
            {
                return BadRequest(new { objectData = idGame, message = "idGame is not 0" });
            }

            var data = await Onboarding.GetGameAsync(idGame);
            return data;
        }

        /// <summary>
        /// get to all games in data base.
        /// </summary>
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("gameall")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<RespGameDTO>>> GetGames(
            [FromServices] IOnboarding Onboarding,
            [FromRoute] string versao = "V0")
        {
            var data = await Onboarding.GetGameAsync();
            return data;
        }

        /// <summary>
        /// get profile in data base.
        /// </summary>
        /// <param name="id_profile">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("profile")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfile(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int id_profile,
            [FromRoute] string versao = "V0")
        {
            if (id_profile == 0)
            {
                return BadRequest(new { objectData = id_profile, message = "idGame is not 0" });
            }

            var data = await Onboarding.GetProfileAsync(id_profile);
            return data;
        }

        /// <summary>
        /// get all profile in data base.
        /// </summary>
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("profileall")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<ProfileDTO>>> GetProfile(
            [FromServices] IOnboarding Onboarding,
            [FromRoute] string versao = "V0")
        {
            var data = await Onboarding.GetProfileAsync();
            return data;
        }



        /// <summary>
        /// get individual in data base.
        /// </summary>
        /// <param name="idGame">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("individuo")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<RespIndividualDTO>> GetIndividuo(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int idIndividuo,
            [FromRoute] string versao = "V0")
        {
            if (idIndividuo == 0)
            {
                return BadRequest(new { objectData = idIndividuo, message = "idGame is not 0" });
            }

            var data = await Onboarding.GetIndividualAsync(idIndividuo);
            return data;
        }

        /// <summary>
        /// get all individual in data base.
        /// </summary>
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("individuoall")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<RespIndividualDTO>>> GetIndividuo(
            [FromServices] IOnboarding Onboarding,
            [FromRoute] string versao = "V0")
        {
            var data = await Onboarding.GetIndividualAsync();
            return data;
        }

        /// <summary>
        /// get game loan in data base.
        /// </summary>
        /// <param name="idGame">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("gameloan")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<GameLoanDTO>> GetGameLoan(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int id_game_loan,
            [FromRoute] string versao = "V0")
        {
            if (id_game_loan == 0)
            {
                return BadRequest(new { objectData = id_game_loan, message = "idGame is not 0" });
            }

            var data = await Onboarding.GetGameLoanAsync(id_game_loan);
            return data;
        }

        /// <summary>
        /// get game loan in data base.
        /// </summary>
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("gameloanall")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<GameLoanDTO>>> GetGameLoan(
            [FromServices] IOnboarding Onboarding,
            [FromRoute] string versao = "V0")
        {
            var data = await Onboarding.GetGameLoanAsync();
            return data;
        }


        #endregion

        #region DeleteDB
        /// <summary>
        /// delete games in data base.
        /// </summary>
        /// <param name="idGame">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("game")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteGame(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int idGame,
            [FromRoute] string versao = "V0")
        {
            if (idGame == 0)
            {
                return BadRequest(new { objectData = idGame, message = "idGame is not 0" });
            }

            var data = await Onboarding.DeleteGameAsync(idGame);
            return data;
        }

        /// <summary>
        /// delete profile in data base.
        /// </summary>
        /// <param name="id_profile">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("profile")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteProfile(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int id_profile,
            [FromRoute] string versao = "V0")
        {
            if (id_profile == 0)
            {
                return BadRequest(new { objectData = id_profile, message = "idGame is not 0" });
            }
            var data = await Onboarding.DeleteProfileAsync(id_profile);
            return data;
        }

        /// <summary>
        /// delete individuo in data base.
        /// </summary>
        /// <param name="idIndividuo">idGame" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("individuo")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteIndividual(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int idIndividuo,
            [FromRoute] string versao = "V0")
        {
            if (idIndividuo == 0)
            {
                return BadRequest(new { objectData = idIndividuo, message = "idGame is not 0" });
            }
            var data = await Onboarding.DeleteIndividualAsync(idIndividuo);
            return data;
        }

        /// <summary>
        /// delete game loan in data base.
        /// </summary>
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("gameloan")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteGameLoan(
            [FromServices] IOnboarding Onboarding,
            [FromQuery] int id_game_loan,
            [FromRoute] string versao = "V0")
        {
            if (id_game_loan == 0)
            {
                return BadRequest(new { objectData = id_game_loan, message = "idGame is not 0" });
            }
            var data = await Onboarding.DeleteGameLoanAsync(id_game_loan);
            return data;
        }
        #endregion

        #region PutDB

        /// <summary>
        /// update games in data base.
        /// </summary>
        /// <param name="game">data game" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>        
        [Route("game")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<GameDTO>> PutGames(
            [FromServices] IOnboarding Onboarding,
            [FromBody] GameDTO game,
            [FromRoute] string versao = "V0")
        {
            if (
                game.id == 0 ||
                string.IsNullOrEmpty(game.name) ||
                string.IsNullOrEmpty(game.description)
                )
            {
                return BadRequest(new { objectData = game, message = "game is not IsNullOrEmpty" });
            }
            var data = await Onboarding.PutGameAsync(game);
            return data;
        }

        /// <summary>
        /// update individuo in data base.
        /// </summary>
        /// <param name="individual">data individual" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("individuo")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<IndividualDTO>> PutIndividuo(
            [FromServices] IOnboarding Onboarding,
            IndividualDTO individual,
            [FromRoute] string versao = "V0")
        {
            if (
                individual.id == 0 ||
                string.IsNullOrEmpty(individual.name) ||
                string.IsNullOrEmpty(individual.cpf)
                )
            {
                return BadRequest(new { objectData = individual, message = "individual is not IsNullOrEmpty" });
            }

            var data = await Onboarding.PutIndividualAsync(individual);
            if (data.id == 0)
            {
                return Conflict(new { dataObject = data, message = "no accept id profile or incorrect data" });
                //return BadRequest(new { dataObject = data, message = "no accept id profile or incorrect data" });
            }
            return data;
        }

        /// <summary>
        /// update profile in data base.
        /// </summary>
        /// <param name="profile">data profile" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("profile")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<ProfileDTO>> PutProfile(
            [FromServices] IOnboarding Onboarding,
            ProfileDTO profile,
            [FromRoute] string versao = "V0")
        {
            if (
               profile.id == 0 ||
               string.IsNullOrEmpty(profile.name) ||
               string.IsNullOrEmpty(profile.description)
               )
            {
                return BadRequest(new { objectData = profile, message = "profile is not IsNullOrEmpty" });
            }
            var data = await Onboarding.PutProfileAsync(profile);
            return data;
        }

        /// <summary>
        /// update game loan in data base.
        /// </summary>
        /// <param name="gameloan">data gameloan" .</param> 
        /// <param name="versao">version application </param>         
        /// <remarks>  
        [Route("gameloan")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<GameLoanDTO>> PutGameLoan(
            [FromServices] IOnboarding Onboarding,
            GameLoanDTO gameloan,
            [FromRoute] string versao = "V0")
        {
            if (
               gameloan.id == 0 ||
               gameloan.id_individual == 0 ||
               gameloan.id_game == 0 ||
               string.IsNullOrEmpty(gameloan.description)
               )
            {
                return BadRequest(new { objectData = gameloan, message = "gameloan is not IsNullOrEmpty" });
            }

            var data = await Onboarding.PutGameLoanAsync(gameloan);
            return data;
        }

        #endregion

    }
}
