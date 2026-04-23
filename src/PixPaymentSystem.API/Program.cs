namespace PixPaymentSystem.API
{
    using System.Globalization;
    using Elastic.Ingest.Elasticsearch;
    using Elastic.Ingest.Elasticsearch.DataStreams;
    using Elastic.Serilog.Sinks;
    using PixPaymentSystem.API.Middleware;
    using PixPaymentSystem.Application.DependencyInjection;
    using Serilog;

    /// <summary>
    /// Classe de entrada da aplicação ASP.NET Core para o sistema de pagamento Pix.
    /// </summary>
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var elasticsearchUrl = builder.Configuration
                .GetSection("Elasticsearch:Url")
                .Get<string>();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "PixPaymentSystem")
                .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
                .WriteTo.Elasticsearch(
                    [new Uri(elasticsearchUrl!)],
                    opts =>
                    {
                        opts.DataStream = new DataStreamName("logs", "pix", "api");
                        opts.BootstrapMethod = BootstrapMethod.Silent;
                    })
                .CreateLogger();


            builder.Host.UseSerilog();

            builder.Services.AddApplication();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<CorrelationIdMiddleware>();
            app.MapControllers();

            await app.RunAsync();
        }
    }
}