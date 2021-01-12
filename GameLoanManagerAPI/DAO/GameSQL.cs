using GameLoanManagerCore.Connections;
using GameLoanManagerCore.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Net;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace GameLoanManagerAPI.Business.DAO
{

    public class GameSQL
    {
        //readonly ConnectionStringSettings _settings;

        //public GameSQL(ConnectionStringSettings settings)
        //{
        //    _settings = settings; ;
        //}
        public string ConnectionString = $@"Data Source=.\localhost,1401;Initial Catalog=GameLoanManagerDB;Persist Security Info=True;User ID=sa;Password=Castelo307#";

        #region AddDB

        public async Task<GameDTO> AddGame(GameDTO game)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(select id_game_int from  game where name_str = @name_str)
                        select id_game_int from  game where name_str = @name_str;
                   ELSE
                   INSERT INTO [dbo].[game]
                           ([name_str]
                           ,[description_str]
                           ,[status_bool]
                           ,[create_at])
                     VALUES
                           (@name_str
                           ,@description_str
                           ,cast(0 as bit)
                           ,@create_at);
                    SELECT SCOPE_IDENTITY()";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    name_str = game.name,
                    description_str = game.name,
                    create_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    game.id = ret;
                }
                return game;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<ProfileDTO> AddProfile(ProfileDTO profile)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(select id_profile_int from  profile where name_str = @name_str)
                        select id_profile_int from  profile where name_str = @name_str;
                   ELSE
                   INSERT INTO [dbo].[profile]
                           ([name_str]
                           ,[description_str])
                   VALUES
                           (@name_str
                           ,@description_str);
                   SELECT SCOPE_IDENTITY()";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    name_str = profile.name,
                    description_str = profile.name
                });
                if (ret > 0)
                {
                    profile.id = ret;
                }
                return profile;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<IndividualDTO> AddIndividual(IndividualDTO individual)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var valdarProfile = await connection.QueryFirstOrDefaultAsync<int>(
                    "select count(id_profile_int) from  profile where id_profile_int = @id_profile_int",
                    new { id_profile_int = individual.id_profile });

                if (valdarProfile == 0)
                {
                    return individual;
                }

                var insertSql = @"
                   IF EXISTS(select id_individual_int from  individual where cpf_str = @cpf_str)
                        select id_individual_int from  individual where cpf_str = @cpf_str;
                   ELSE
                    INSERT INTO [dbo].[individual]
                               ([id_profile_int]
                               ,[name_str]
                               ,[cpf_str]
                               ,[create_at])
                         VALUES
                               (@id_profile_int
                               ,@name_str
                               ,@cpf_str                               
                               ,@create_at);
                    SELECT SCOPE_IDENTITY()";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    id_profile_int = individual.id_profile,
                    name_str = individual.name,
                    cpf_str = individual.cpf,
                    create_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    individual.id = ret;
                    string sqlguid = "select guid_uid from individual where id_profile_int = @id_profile_int";
                    var guid = await connection.QueryFirstOrDefaultAsync<Guid>(sqlguid, new { id_profile_int = ret });
                    individual.guid = guid.ToString();
                }
                return individual;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<GameLoanDTO> AddGameloan(GameLoanDTO gameloan)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(SELECT id_game_loan_int FROM  game_loan where id_individual_int = @id_individual_int and id_game_int = @id_game_int)
                      SELECT [id_game_loan_int] FROM  [game_loan] where id_individual_int =@id_individual_int and id_game_int = @id_game_int;
                   ELSE
                    INSERT INTO [dbo].[game_loan]
                           ([id_individual_int]
                           ,[id_game_int]
                           ,[description_str]
                           ,[create_at])
                     VALUES
                           (@id_individual_int
                           ,@id_game_int
                           ,@description_str
                           ,@create_at);
                    SELECT SCOPE_IDENTITY()";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    id_individual_int = gameloan.id_individual,
                    id_game_int = gameloan.id_game,
                    description_str = gameloan.description,
                    create_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    gameloan.id = ret;
                    string sqlguid =
                        "SELECT [create_at] FROM  [game_loan]" +
                        "where id_game_loan_int =@id_game_loan_int";
                    var create_at = await connection.QueryFirstOrDefaultAsync<DateTime>(sqlguid,
                        new { id_game_loan_int = ret });
                    gameloan.create_at = create_at;
                }
                return gameloan;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        #endregion

        #region GetDB

        public async Task<RespGameDTO> GetGame(int idGame)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT [id_game_int] as id
                              ,[name_str] as name
                              ,[description_str] as description
                              ,[status_bool] as status
                              ,[create_at]
                              ,[update_at]
                          FROM [GameLoanManagerDB].[dbo].[game]
                          where id_game_int = @id_game_int;";

                var ret = await connection.QueryFirstOrDefaultAsync<RespGameDTO>(sSql, new
                {
                    id_game_int = idGame
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<List<RespGameDTO>> GetGame()
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT [id_game_int] as id
                              ,[name_str] as name
                              ,[description_str] as description
                              ,[status_bool] as status
                              ,[create_at]
                              ,[update_at]
                          FROM [GameLoanManagerDB].[dbo].[game];";

                var ret = await connection.QueryAsync<RespGameDTO>(sSql);
                return ret.ToList();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public async Task<ProfileDTO> GetProfile(int id_profile)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT[id_profile_int] as id
                              ,[name_str] as name
                              ,[description_str] as description
                FROM[dbo].[profile]
                          where id_profile_int = @id_profile_int;";

                var ret = await connection.QueryFirstOrDefaultAsync<ProfileDTO>(sSql, new
                {
                    id_profile_int = id_profile
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<List<ProfileDTO>> GetProfile()
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                          SELECT[id_profile_int] as id
                              ,[name_str] as name
                              ,[description_str] as description
                          FROM [dbo].[profile]";

                var ret = await connection.QueryAsync<ProfileDTO>(sSql);
                return ret.ToList();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public async Task<RespIndividualDTO> GetIndividual(int idIndividuo)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT [id_individual_int] as id
                              ,[id_profile_int] as id_profile
                              ,[name_str] as name
                              ,[cpf_str] as cpf
                              ,convert(nvarchar(36), [guid_uid])  as guid
                              ,[password_str] as password
                              ,[status_bool] as status
                              ,[create_at]
                              ,[update_at]
                          FROM [dbo].[individual]
                          where id_individual_int = @id_individual_int;";

                var ret = await connection.QueryFirstOrDefaultAsync<RespIndividualDTO>(sSql, new
                {
                    id_individual_int = idIndividuo
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<List<RespIndividualDTO>> GetIndividual()
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT [id_individual_int] as id
                              ,[id_profile_int] as id_profile
                              ,[name_str] as name
                              ,[cpf_str] as cpf
                              ,convert(nvarchar(36), [guid_uid])  as guid
                              ,[password_str] as password
                              ,[status_bool] as status
                              ,[create_at]
                              ,[update_at]
                          FROM [dbo].[individual]";

                var ret = await connection.QueryAsync<RespIndividualDTO>(sSql);
                return ret.ToList();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public async Task<GameLoanDTO> GetGameLoan(int id_game_loan)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                        SELECT  [id_game_loan_int] as id
		                        ,[id_individual_int] as id_individual
		                        ,[id_game_int] as id_game
		                        ,[description_str] as description
		                        ,[create_at]
		                        ,[update_at]
                          FROM [dbo].[game_loan]
                          where id_game_loan_int = @id_game_loan_int;";

                var ret = await connection.QueryFirstOrDefaultAsync<GameLoanDTO>(sSql, new
                {
                    id_game_loan_int = id_game_loan
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<List<GameLoanDTO>> GetGameLoan()
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"
                      SELECT  [id_game_loan_int] as id
		                        ,[id_individual_int] as id_individual
		                        ,[id_game_int] as id_game
		                        ,[description_str] as description
		                        ,[create_at]
		                        ,[update_at]
                          FROM [dbo].[game_loan]";

                var ret = await connection.QueryAsync<GameLoanDTO>(sSql);
                return ret.ToList();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        #endregion

        #region DeleteDB

        public async Task<int> DeleteGame(int idGame)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"DELETE FROM [GameLoanManagerDB].[dbo].[game]
                          where id_game_int = @id_game_int;";

                var ret = await connection.ExecuteAsync(sSql, new
                {
                    id_game_int = idGame
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<int> DeleteProfile(int id_profile)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"DELETE FROM [dbo].[profile]
                          where id_profile_int = @id_profile_int;";

                var ret = await connection.ExecuteAsync(sSql, new
                {
                    id_profile_int = id_profile
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<int> DeleteIndividual(int idIndividuo)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"DELETE FROM [dbo].[individual]
                          where id_individual_int = @id_individual_int;";

                var ret = await connection.ExecuteAsync(sSql, new
                {
                    id_individual_int = idIndividuo
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<int> DeleteGameLoan(int id_game_loan)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var sSql = @"DELETE FROM [dbo].[game_loan]
                          where id_game_loan_int = @id_game_loan_int;";

                var ret = await connection.ExecuteAsync(sSql, new
                {
                    id_game_loan_int = id_game_loan
                });
                return ret;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        #endregion

        #region PutDB

        public async Task<GameDTO> PutGame(GameDTO game)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(select id_game_int from  game where id_game_int = @id_game_int)                       
                            UPDATE [dbo].[game]
                               SET [name_str] = @name_str
                                  ,[description_str] = @description_str
                                  ,[status_bool] = cast (1 as bit)
                                  ,[update_at] = @update_at
                             WHERE id_game_int = @id_game_int ";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    id_game_int = game.id,
                    name_str = game.name,
                    description_str = game.name,
                    update_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    game.id = ret;
                }
                return game;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<ProfileDTO> PutProfile(ProfileDTO profile)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(select id_profile_int from  profile where id_profile_int = @id_profile_int)
                        UPDATE [dbo].[profile]
                        SET [name_str] = @name_str
                            ,[description_str] = @description_str
                        WHERE id_profile_int = @id_profile_int";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    id_profile_int = profile.id,
                    name_str = profile.name,
                    description_str = profile.name
                });
                if (ret > 0)
                {
                    profile.id = ret;
                }
                return profile;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<IndividualDTO> PutIndividual(IndividualDTO individual)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var valdarProfile = await connection.QueryFirstOrDefaultAsync<int>(
                    "select count(id_profile_int) from  profile where id_profile_int = @id_profile_int",
                    new { id_profile_int = individual.id_profile });

                if (valdarProfile == 0)
                {
                    return individual;
                }

                var insertSql = @"
                   IF EXISTS(select id_individual_int from  individual where id_individual_int = @id_individual_int)
                       UPDATE [dbo].[individual]
                       SET [id_profile_int] = @id_profile_int
                          ,[name_str] = @name_str
                          ,[cpf_str] = @cpf_str";

                if (!string.IsNullOrEmpty(individual.password))
                    insertSql += ",[password_str] = @password_str";

                insertSql += @$",[status_bool] = cast(1 as bit)
                          ,[update_at] = @update_at
                     WHERE id_individual_int = @id_individual_int";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    password_str = individual.password,
                    id_individual_int = individual.id,
                    id_profile_int = individual.id_profile,
                    name_str = individual.name,
                    cpf_str = individual.cpf,
                    update_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    individual.id = ret;
                    string sqlguid = "select guid_uid from individual where id_profile_int = @id_profile_int";
                    var guid = await connection.QueryFirstOrDefaultAsync<Guid>(sqlguid, new { id_profile_int = ret });
                    individual.guid = guid.ToString();
                }
                return individual;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
        public async Task<GameLoanDTO> PutGameloan(GameLoanDTO gameloan)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                await connection.OpenAsync();

                var insertSql = @"
                   IF EXISTS(SELECT id_game_loan_int FROM  game_loan where id_game_loan_int = @id_game_loan_int)
                    UPDATE [dbo].[game_loan]
                    SET [id_individual_int] = @id_individual_int
                        ,[id_game_int] = @id_game_int
                        ,[description_str] = @description_str
                        ,[update_at] = @update_at
                    WHERE id_game_loan_int = @id_game_loan_int";

                var ret = await connection.QueryFirstOrDefaultAsync<int>(insertSql, new
                {
                    id_game_loan_int = gameloan.id,
                    id_individual_int = gameloan.id_individual,
                    id_game_int = gameloan.id_game,
                    description_str = gameloan.description,
                    update_at = DateTime.Now.ToString("yyyy-MM-dd")
                });
                if (ret > 0)
                {
                    gameloan.id = ret;
                    string sqlguid =
                        "SELECT [create_at] FROM  [game_loan]" +
                        "where id_game_loan_int =@id_game_loan_int";
                    var create_at = await connection.QueryFirstOrDefaultAsync<DateTime>(sqlguid,
                        new { id_game_loan_int = ret });
                    gameloan.create_at = create_at;
                }
                return gameloan;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        #endregion
    }
}
