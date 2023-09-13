using app.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace app.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private readonly string _connectionString="Server=mssql,1433;Database=TempApp;User=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;";
    [HttpGet]
    public IList<FootballPlayer> Get(){
        using var connection = new SqlConnection(_connectionString);
        var lista = connection.Query<FootballPlayer>("SELECT * FROM [FootballPlayer];");
        return lista.ToList();

    }
}
