using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;
using OracleWithDapper.Interface;
using OracleWithDapper.Models;
using Microsoft.Extensions.Configuration;
using Dapper.Oracle;

namespace OracleWithDapper.Repositories
{
    public class GameCatalogRepository : IGameCatalogRepository
    {

        private readonly IDbConnection _dbConnection;

        public GameCatalogRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int AddGame(string in_name, string in_genre, string in_esrb_rating)
        {
            DynamicParameters dynamicParameters = new DynamicParameters(new {
                Name = in_name,
                Genre = in_genre,
                ESRB_Rating = in_esrb_rating
            });

            string sql = "INSERT INTO atlantisgames.GAMECATALOG(Name, Genre, ESRB_RATING) Values(:Name, :Genre, :ESRB_Rating)";

            int rowsAffected = this._dbConnection.Execute(sql, dynamicParameters);

            return rowsAffected;
        }

        public List<GameCatalog> GetGameCatalog()
        {
            List<GameCatalog> games;

            OracleDynamicParameters dynamicParameters = new OracleDynamicParameters();

            dynamicParameters.Add(name: ":Games", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            games = this._dbConnection.Query<GameCatalog>("atlantisgames.getallgames", param: dynamicParameters, commandType: CommandType.StoredProcedure).ToList();


            //games = this._dbConnection.Query<GameCatalog>(sql: "atlantisgames.GetAllGames", commandType: CommandType.StoredProcedure).ToList();


            return games;
        }

        public int RemoveGame(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(":ID", id, DbType.Int32, ParameterDirection.Input);

            string sql = "delete from atlantisgames.gamecatalog where id = :ID";

            int rowsAffected = this._dbConnection.Execute(sql, dynamicParameters);

            return rowsAffected;
        }

        public int UpdateGameName(int id, string new_name)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(":ID", id, DbType.Int32, ParameterDirection.Input);

            dynamicParameters.Add(":NEW_NAME", new_name, DbType.String, ParameterDirection.Input);

            string sql = "update atlantisgames.gamecatalog set Name = :NEW_NAME where id = :ID";

            int rowsAffected = this._dbConnection.Execute(sql, dynamicParameters);

            return rowsAffected;
        }

    }
}
