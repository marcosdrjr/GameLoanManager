using GameLoanManagerCore.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanManagerAPI.Business.Interfaces
{
    public interface IOnboarding
    {
        #region AddDB
        Task<GameDTO> AddGameAsync(GameDTO game);
        Task<IndividualDTO> AddIndividualAsync(IndividualDTO individual);
        Task<ProfileDTO> AddProfileAsync(ProfileDTO profile);
        Task<GameLoanDTO> AddGameLoanAsync(GameLoanDTO gameloan);
        #endregion
        #region GetDB
        Task<RespGameDTO> GetGameAsync(int idGame);
        Task<List<RespGameDTO>> GetGameAsync();
        Task<RespIndividualDTO> GetIndividualAsync(int idIndividuo);
        Task<List<RespIndividualDTO>> GetIndividualAsync();
        Task<ProfileDTO> GetProfileAsync(int id_profile);
        Task<List<ProfileDTO>> GetProfileAsync();
        Task<GameLoanDTO> GetGameLoanAsync(int id_game_loan);
        Task<List<GameLoanDTO>> GetGameLoanAsync();
        #endregion
        #region DeleteDB
        Task<int> DeleteGameAsync(int idGame);
        Task<int> DeleteIndividualAsync(int idIndividuo);
        Task<int> DeleteProfileAsync(int id_profile); 
        Task<int> DeleteGameLoanAsync(int id_game_loan);
        #endregion
        #region PutDB
        Task<GameDTO> PutGameAsync(GameDTO game);
        Task<IndividualDTO> PutIndividualAsync(IndividualDTO individual);
        Task<ProfileDTO> PutProfileAsync(ProfileDTO profile);
        Task<GameLoanDTO> PutGameLoanAsync(GameLoanDTO gameloan);
        #endregion
    }
}