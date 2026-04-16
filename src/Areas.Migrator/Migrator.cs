using Areas.Tools.Utils;
using Microsoft.Extensions.Hosting;

namespace Areas.Migrator;

public class Migrator : IHostedService
{
    private string _upPath {get; } = Path.Combine(AppContext.BaseDirectory, "Migrations/up");
    private string _downPath {get; } = Path.Combine(AppContext.BaseDirectory, "Migrations/down");
    // private string _upPath { get; } = "./Migrations/up";
    // private string _downPath { get; } = "./Migrations/down";

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        string[] files = Directory.GetFiles(_upPath, "*.sql").OrderBy(f => f).ToArray();

        foreach (string file in files)
        {
            var sqlString = await File.ReadAllTextAsync(file);
            DatabaseUtils.Execute(sqlString, p => { });
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        string[] files = Directory.GetFiles(_downPath, "*.sql").OrderByDescending(f => f).ToArray();

        foreach (string file in files)
        {
            var sqlString = await File.ReadAllTextAsync(file);
            DatabaseUtils.Execute(sqlString, p => { });
        }
    }
}
