using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch;
using Elastic.Serilog.Sinks;
using PixPaymentSystem.API.Middleware;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Application.Services;
using PixPaymentSystem.Domain.Interfaces;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("Application", "PixPaymentSystem")
    .WriteTo.Console()
    .WriteTo.Elasticsearch(
        [new Uri("http://elasticsearch:9200")],
        opts =>
        {
            opts.DataStream = new DataStreamName("logs", "pix", "api");
            opts.BootstrapMethod = BootstrapMethod.Silent;
        })
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddTransient<IPixFactory, PixImediatoFactory>();
builder.Services.AddTransient<IPixFactory, PixAgendadoFactory>();
builder.Services.AddTransient<IPixFactory, PixRecorrenteFactory>();

builder.Services.AddSingleton<IPixFactoryResolver, PixFactoryResolver>();
builder.Services.AddSingleton<IIdempotencyService, IdempotencyService>();

builder.Services.AddTransient<IPixService, PixService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
