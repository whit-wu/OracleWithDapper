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
        public void TestGetAllGames()
        {
            // Arrange
            IGameCatalogRepository repo = CreateRepository();

            // Act 
            var games = repo.GetGameCatalog();

            // Assert
            games.Should().NotBeNull();
        }

        [TestMethod]
        public void TestAddGame()
        {
            // Arrange
            IGameCatalogRepository repo = CreateRepository();

            // Act
            int rowsAffected = repo.AddGame("Contra", "Shooter", "Everyone");

            // Assert
            Assert.IsTrue(rowsAffected == 1);

        }

        [TestMethod]
        public void TestRemoveGame()
        {
            // Arrange
            IGameCatalogRepository repo = CreateRepository();

            // Act
            int rowsAffected = repo.RemoveGame(11);

            // Assert
            Assert.IsTrue(rowsAffected == 1);

        }

        [TestMethod]
        public void TestUpdateGameName()
        {
            // Arrange
            IGameCatalogRepository repo = CreateRepository();

            // Act 
            int rowsAffected = repo.UpdateGameName(3, "God of War (2016)");

        }


        private IGameCatalogRepository CreateRepository()
        {
            IDbConnection db = new SqlConnection("Data Source=DEREK-PC;Initial Catalog=AtlantisGames;Integrated Security=True");
            return new GameCatalogRepository(db);
        }
    }
}
