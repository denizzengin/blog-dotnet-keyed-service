namespace KeyedService.Application.Features.DataSync;


/// <summary>
/// General data changed event both Student and Teacher
/// </summary>
public class DataChangedEventDto
{
    // This field will used as keyed service key.
    public required string EventName { get; set; }

    // We can check already processed or not.
    public Guid RecordId { get; set; }

    /// <summary>
    /// Json format of Student or Teacher
    /// </summary>
    public string? Content { get; set; }
}
