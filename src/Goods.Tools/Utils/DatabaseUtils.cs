using Goods.Tools.Types;
using Npgsql;

namespace Goods.Tools.Utils;

public static class DatabaseUtils
{
    private const String _connectionString =
        "Server=localhost;Port=5342;Username=postgres;Password:postgres;Database=local_area_db";

    public static Int32 Execute(String sql, Action<NpgsqlParameterCollection> getParameters) =>
        UseSqlCommand(sql, getParameters, (command) => command.ExecuteNonQuery());

    public static Page<T> GetPage<T>(
        String sql,
        Action<NpgsqlParameterCollection> parameterCollection,
        Func<NpgsqlDataReader, T> mapper
    )
    {
        return UseSqlCommand(
            sql,
            parameterCollection,
            (command) =>
            {
                using NpgsqlDataReader reader = command.ExecuteReader();
                List<T> values = [];
                Int32 totalRows = 0;

                while (reader.Read())
                {
                    totalRows = Convert.ToInt32(reader["count"]);
                    values.Add(mapper(reader));
                }
                return new Page<T>([.. values], totalRows);
            }
        );
    }

    public static T? Get<T>(
        String sql,
        Action<NpgsqlParameterCollection> parameterCollection,
        Func<NpgsqlDataReader, T> mapper
    )
    {
        return UseSqlCommand(
            sql,
            parameterCollection,
            (command) =>
            {
                using NpgsqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return default;
                }
                return mapper(reader);
            }
        );
    }

    private static T UseSqlCommand<T>(
        String sql,
        Action<NpgsqlParameterCollection> getParameters,
        Func<NpgsqlCommand, T> getCommand
    )
    {
        using NpgsqlConnection connection = new(_connectionString);
        connection.Open();

        using NpgsqlCommand command = new();

        command.Connection = connection;
        command.CommandText = sql;
        getParameters(command.Parameters);
        return getCommand(command);
    }
}
