using OracleWithDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleWithDapper.Interface
{
    public interface IGameCatalogRepository
    {
        List<GameCatalog> GetGameCatalog();
        int AddGame(string in_name, string in_genre, string in_esrb_rating);
        int RemoveGame(int id);
        int UpdateGameName(int id, string new_name);
    }
}
