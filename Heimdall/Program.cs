using System.Configuration;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Heimdall.Infrastracture.Database;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure.Interception;
using System.Reflection.Metadata;
using Heimdall.Application;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using ILogger = Serilog.ILogger;
using System.Collections.ObjectModel;
using System.Data;
using Heimdall.Application.Mappings;
using Heimdall.Infrastracture.Database.Dispatchers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

Serilog.Debugging.SelfLog.Enable(msg=> Console.WriteLine(msg));

var sinkOpts = new MSSqlServerSinkOptions { TableName = "Exceptions", SchemaName = "dbo", AutoCreateSqlTable = true };

var columnOptions = new ColumnOptions
{
    Id = { ColumnName = "Id", AllowNull = false},
    TimeStamp = { ColumnName = "DateThrown", ConvertToUtc = true, DataType = SqlDbType.DateTime, AllowNull = false},
    Exception = {ColumnName = "Error", DataType = SqlDbType.NVarChar, DataLength = 200, AllowNull = true},
    AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn
            {ColumnName = "Application", PropertyName = "Application", DataType = SqlDbType.NVarChar, DataLength = 200, AllowNull = true}
    },
    MessageTemplate = {ColumnName = "MessageTemplate"}
};

columnOptions.Store.Remove(StandardColumn.Message);
columnOptions.Store.Remove(StandardColumn.Level);
columnOptions.Store.Remove(StandardColumn.Properties);

var SolutionFullPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
var tempStrings = SolutionFullPath.Split('\\');

var solutionName = tempStrings[tempStrings.Length - 1]; ;

Log.Logger = new LoggerConfiguration()
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("SerilogConnection"),
        sinkOptions:sinkOpts,
        columnOptions:columnOptions
        )
    .MinimumLevel.Warning()
    .Enrich.WithProperty("Application", solutionName)
    .CreateLogger();

builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog(Log.Logger);
// Add services to the container.

builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("HeimdallConnection")));
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(UserMappings)));

builder.Services.Scan(selector =>
{
    selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
        .AddClasses(filter =>
        {
            filter.AssignableTo(typeof(IQueryHandler<,>));
        })
        .AsImplementedInterfaces()
        .WithScopedLifetime();
});


builder.Services.Scan(selector =>
{
    selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
        .AddClasses(filter =>
        {
            filter.AssignableTo(typeof(Heimdall.Application.ICommandHandler<,>));
        })
        .AsImplementedInterfaces()
        .WithScopedLifetime();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
