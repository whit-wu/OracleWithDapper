using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleWithDapper.Interface;
using OracleWithDapper.Repositories;
using System.Data;
using System.Data.SqlClient;
using FluentAssertions;

namespace OracleWithDapperTests
{
    [TestClass]
    public class GamesTests
    {
        [TestMethod]
        public void GetAllGames()
        {
            IGameCatalogRepository repo = CreateRepository();

            var games = repo.GetGameCatalog();

            games.Should().NotBeNull();
        }


        private IGameCatalogRepository CreateRepository()
        {
            IDbConnection db = new SqlConnection("Data Source=DEREK-PC;Initial Catalog=AtlantisGames;Integrated Security=True");
            return new GameCatalogRepository(db);
        }
    }
}
