
namespace KeyedService.Application.Features.DataSync;

public interface IDataSyncProcessor
{
    Task<bool> RunAsync(DataChangedEventDto changedEventDto, CancellationToken cancellationToken);
}