using Dapper;
using Npgsql;

public class BaseRepository<T, C> where C : BaseConnectionSettings
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository(BaseConnection<C> connection)
    {
        _connection = connection.GetConnection();
    }

    protected BaseRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<T>> QueryMany(string sql, Object? obj) =>
        (obj != null ? await _connection.QueryAsync<T>(sql, obj) : await _connection.QueryAsync<T>(sql)).ToList();

    public async Task<T?> QueryOne(string sql, Object? obj)
    {
        try
        {
            return obj != null ? await _connection.QuerySingleAsync<T>(sql, obj) : await _connection.QuerySingleAsync<T>(sql);
        }
        catch (InvalidOperationException)
        {
            return default(T);
        }
    }

    public async Task<int> Execute(string sql, Object? obj) =>
        obj != null ? await _connection.ExecuteAsync(sql, obj) : await _connection.ExecuteAsync(sql);
}