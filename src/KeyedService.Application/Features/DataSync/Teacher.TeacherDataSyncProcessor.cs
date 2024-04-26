using Microsoft.Extensions.Logging;

namespace KeyedService.Application.Features.DataSync;

public class TeacherDataSyncProcessor(ILogger<StudentDataSyncProcessor> logger) : IDataSyncProcessor
{
    public Task<bool> RunAsync(DataChangedEventDto changedEventDto, CancellationToken cancellationToken)
    {
        // Do Teacher entity specific creation and saving db via dbContext etc.
        logger.LogInformation("{processorName} is processing {dtoName}", nameof(TeacherDataSyncProcessor), nameof(TeacherDataSyncDto));

        return Task.FromResult(true);
    }
}