using KeyedService.BackgroundServices;
using KeyedService.Application;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDataSyncProcessors();
builder.Services.AddHostedService<DataSyncWorker>();

var host = builder.Build();
host.Run();
