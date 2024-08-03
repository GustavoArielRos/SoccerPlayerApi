using SoccerPlayerApi.Data.Interfaces;

namespace SoccerPlayerApi.Data.Repositories
{
    public class SPRepository : ISPRepository
    {
        public readonly SampleDatabaseContext _databaseContext;

        public SPRepository(SampleDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> CreatePlayer(int jerseyNumber, string name, int teamId)
        {
            // Executa o procedimento armazenado 'CreatePlayer' no banco de dados com os parâmetros fornecidos.
            // A consulta SQL interpolada substitui @jerseyNumber, @name e @teamId pelos valores de jerseyNumber, name e teamId, respectivamente.
            //_databaseContext.Database: Usado para executar comandos SQL brutos, especialmente quando o comando não retorna uma entidade específica
            //ou quando se deseja realizar operações que afetam múltiplas tabelas 
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec CreatePlayer @jerseyNumber={jerseyNumber}, @name={name},@teamId={teamId}");

            return affectedRows;
        }

        public Task<dynamic> GetJoinedPlayerList()
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayer(string name, int jerseyNumber)
        {
            // Executa um procedimento armazenado 'GetPlayer' no banco de dados com os parâmetros fornecidos.
            // A consulta SQL interpolada substitui @jerseyNumber e @name pelos valores de jerseyNumber e name
            var playerspobjObj = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayer @jerseyNumber={jerseyNumber}, @name={name}").ToListAsync();

            // Retorna o primeiro jogador encontrado na lista ou 'null' se a lista estiver vazia.
            return playerspobjObj.FirstOrDefault();
        }

        public async Task<List<Player>> GetPlayersList()
        {
            var listplayer = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayersList").ToListAsync();

            return listplayer;
        }

        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            // Executa o procedimento armazenado 'UpdatePlayer' no banco de dados com os parâmetros fornecidos.
            // A consulta SQL interpolada substitui @teamId e @playerId pelos valores de teamId e playerId, respectivamente.
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec UpdatePlayer @teamId={teamId}, @playerId={playerId}");

            return affectedRows;
        }
    }
}