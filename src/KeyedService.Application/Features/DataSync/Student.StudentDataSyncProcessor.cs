

using Microsoft.Extensions.Logging;

namespace KeyedService.Application.Features.DataSync;


public class StudentDataSyncProcessor(ILogger<StudentDataSyncProcessor> logger)
    : IDataSyncProcessor
{    
    public Task<bool> RunAsync(DataChangedEventDto changedEventDto, CancellationToken cancellationToken)
    {
        logger.LogInformation("{processorName} is processing {dtoName}", nameof(StudentDataSyncProcessor), nameof(StudentDataSyncDto));

        return Task.FromResult(true);
    }
}