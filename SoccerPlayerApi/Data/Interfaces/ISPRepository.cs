namespace SoccerPlayerApi.Data.Interfaces
{
    public interface ISPRepository
    {   
        //as 5 store procedures
        //cada método é uma store procedure
        Task<Player> GetPlayer(string name, int jerseyNumber);
        Task<List<Player>> GetPlayersList();
        Task<dynamic> GetJoinedPlayerList();
        Task<int> UpdatePlayer(int teamId, int playerId);
        Task<int> CreatePlayer(int jerseyNumber, string name, int teamId);
    }
}