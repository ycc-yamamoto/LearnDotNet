using System;

namespace LearningUtility.Dto;

public sealed class TimeSeriesItemDto
{
    public DateTimeOffset[] TimeDefines { get; set; } = Array.Empty<DateTimeOffset>();
    
    public AreasItemDto[] Areas { get; set; } = Array.Empty<AreasItemDto>();
}