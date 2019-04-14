using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleWithDapper.Interface;
using OracleWithDapper.Repositories;
using System.Data;
using System.Data.SqlClient;
using FluentAssertions;
using Oracle.ManagedDataAccess.Client;

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
            int rowsAffected = repo.RemoveGame(44);

            // Assert
            Assert.IsTrue(rowsAffected == 1);

        }

        [TestMethod]
        public void TestUpdateGameName()
        {
            // Arrange
            IGameCatalogRepository repo = CreateRepository();

            // Act 
            int rowsAffected = repo.UpdateGameName(3, "God of War");

        }


        private IGameCatalogRepository CreateRepository()
        {
            IDbConnection db = new OracleConnection("Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = DEREK-PC)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE))); USER ID = WHITWU; Password = whitwu;");
            return new GameCatalogRepository(db);
        }
    }
}
