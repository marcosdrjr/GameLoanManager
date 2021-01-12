using GameLoanManagerAPI.Business.DAO;
using GameLoanManagerAPI.Business.Interfaces;
using GameLoanManagerCore.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanManagerAPI.Business.Implementations
{

    public class Onboarding : IOnboarding
    {
       readonly GameSQL _sqlgame;

        public Onboarding(GameSQL sqlgame)
        {
            _sqlgame = sqlgame;
        }

        #region AddDB

        public async Task<GameDTO> AddGameAsync(GameDTO game)
        {
            var retDB = await _sqlgame.AddGame(game);
            return retDB;
        }

        public async Task<ProfileDTO> AddProfileAsync(ProfileDTO profile)
        {
            var retDB = await _sqlgame.AddProfile(profile);
            return retDB;
        }

        public async Task<IndividualDTO> AddIndividualAsync(IndividualDTO individual)
        {
            var retDB = await _sqlgame.AddIndividual(individual);
            return retDB;
        }

        public async Task<GameLoanDTO> AddGameLoanAsync(GameLoanDTO gameloan)
        {
            // validates
            var retDB = await _sqlgame.AddGameloan(gameloan);
            return retDB;
        }

        #endregion

        #region GetDB

        public async Task<RespGameDTO> GetGameAsync(int idGame)
        {
            var retDB = await _sqlgame.GetGame(idGame);
            return retDB;
        }
        public async Task<List<RespGameDTO>> GetGameAsync()
        {
            var retDB = await _sqlgame.GetGame();
            return retDB;
        }

        public async Task<RespIndividualDTO> GetIndividualAsync(int idIndividuo)
        {
            var retDB = await _sqlgame.GetIndividual(idIndividuo);
            return retDB;
        }
        public async Task<List<RespIndividualDTO>> GetIndividualAsync()
        {
            var retDB = await _sqlgame.GetIndividual();
            return retDB;
        }

        public async Task<ProfileDTO> GetProfileAsync(int id_profile)
        {
            var retDB = await _sqlgame.GetProfile(id_profile);
            return retDB;
        }
        public async Task<List<ProfileDTO>> GetProfileAsync()
        {
            var retDB = await _sqlgame.GetProfile();
            return retDB;
        }
        public async Task<GameLoanDTO> GetGameLoanAsync(int id_game_loan)
        {
            var retDB = await _sqlgame.GetGameLoan(id_game_loan);
            return retDB;
        }
        public async Task<List<GameLoanDTO>> GetGameLoanAsync()
        {
            var retDB = await _sqlgame.GetGameLoan();
            return retDB;
        }
        #endregion

        #region DeleteDB
        public async Task<int> DeleteGameAsync(int id)
        {
            var retDB = await _sqlgame.DeleteGame(id);
            return retDB;
        }
        public async Task<int> DeleteProfileAsync(int id)
        {
            var retDB = await _sqlgame.DeleteProfile(id);
            return retDB;
        }
        public async Task<int> DeleteIndividualAsync(int id)
        {
            var retDB = await _sqlgame.DeleteIndividual(id);
            return retDB;
        }
        public async Task<int> DeleteGameLoanAsync(int id)
        {
            var retDB = await _sqlgame.DeleteGameLoan(id);
            return retDB;
        }

        #endregion

        #region PutDB
        public async Task<GameDTO> PutGameAsync(GameDTO game)
        {
            var retDB = await _sqlgame.PutGame(game);
            return retDB;
        }

        public async Task<ProfileDTO> PutProfileAsync(ProfileDTO profile)
        {
            var retDB = await _sqlgame.PutProfile(profile);
            return retDB;
        }

        public async Task<IndividualDTO> PutIndividualAsync(IndividualDTO individual)
        {
            var retDB = await _sqlgame.PutIndividual(individual);
            return retDB;
        }

        public async Task<GameLoanDTO> PutGameLoanAsync(GameLoanDTO gameloan)
        {
            // validates
            var retDB = await _sqlgame.PutGameloan(gameloan);
            return retDB;
        }
        #endregion

    }
}
