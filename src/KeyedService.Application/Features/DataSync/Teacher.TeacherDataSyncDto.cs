namespace KeyedService.Application.Features.DataSync;

public class TeacherDataSyncDto
{
    public required string Name { get; set; }

    public string? Division { get; set; }

    public int RegistrationNumber { get; set; }
}
