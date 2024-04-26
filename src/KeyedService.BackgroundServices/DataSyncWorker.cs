using KeyedService.Application.Features.DataSync;
using System.Text.Json;

namespace KeyedService.BackgroundServices;

public class DataSyncWorker(ILogger<DataSyncWorker> logger, IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly ILogger<DataSyncWorker> _logger = logger;
    private List<DataChangedEventDto> dataChangedEvents = [];

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        dataChangedEvents = [
            new() {
                EventName = "Student",
                RecordId = Guid.NewGuid(),
                Content = JsonSerializer.Serialize(new StudentDataSyncDto { Name = "John", StudentNumber = 1})
            },
            new() {
                EventName = "Teacher",
                RecordId = Guid.NewGuid(),
                Content = JsonSerializer.Serialize(new TeacherDataSyncDto { Name = "John", RegistrationNumber = 2, Division = "Science"})
            }
       ];

        _logger.LogInformation("{serviceName} service started to work...", nameof(DataSyncWorker));
        return base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = serviceScopeFactory.CreateScope();

            foreach (var eventDto in dataChangedEvents)
            {
                var dataSyncProcessor = scope.ServiceProvider.GetRequiredKeyedService<IDataSyncProcessor>(eventDto.EventName);

                await dataSyncProcessor.RunAsync(eventDto, stoppingToken);
            }

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(4000, stoppingToken); // wait 4 seconds to re-work
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{serviceName} service stopped to work...", nameof(DataSyncWorker));
        return base.StopAsync(cancellationToken);
    }
}
