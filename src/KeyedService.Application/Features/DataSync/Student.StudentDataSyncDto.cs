
namespace KeyedService.Application.Features.DataSync;

public class StudentDataSyncDto
{
    // required and cannot be null name of student
    public required string Name { get; set; } 

    public uint StudentNumber { get; set; }

    public string UrgencyParentPhoneCall { get; set; } = string.Empty;
}
