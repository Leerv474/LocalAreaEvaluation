using System.IO.Compression;
using Areas.Services;
using Areas.Tools.Utils.Json;
using Microsoft.AspNetCore.ResponseCompression;
// using Areas.Migrator;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// builder.Services.AddHostedService<Migrator>(); 

builder.Host.ConfigureServices(
	(context, serviceCollection) =>
	{
		serviceCollection
			.AddServices()
			.AddControllersWithViews()
			.AddJsonOptions(options => TextJsonSerializer.Configure(options.JsonSerializerOptions));

		serviceCollection.AddSingleton<IJsonSerializer>(new TextJsonSerializer());

		serviceCollection.Configure<GzipCompressionProviderOptions>(options =>
		{
			options.Level = CompressionLevel.Optimal;
		});

		serviceCollection.AddResponseCompression(options =>
		{
			options.EnableForHttps = true;
			options.Providers.Add<BrotliCompressionProvider>();
			options.Providers.Add<GzipCompressionProvider>();
		});
	}
);

WebApplication app = builder.Build();

app.UseResponseCompression()
	.UseHttpsRedirection()
	.UseStaticFiles()
	.UseRouting()
	.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();

