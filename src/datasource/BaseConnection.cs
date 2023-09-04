using Microsoft.Extensions.Options;
using Npgsql;

public class BaseConnection<T> where T : BaseConnectionSettings
{
    private readonly NpgsqlConnection _connection;

    public BaseConnection(IOptions<T> connectionSettings)
    {
        var connection = new NpgsqlConnection(connectionSettings.Value.ConnectionString);
        connection.OpenAsync();
        _connection = connection;
    }

    public NpgsqlConnection GetConnection() =>
        _connection;
}