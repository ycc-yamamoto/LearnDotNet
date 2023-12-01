using System;

namespace LearningUtility.Dto;

public sealed class WeatherDto
{
    public string PublishingOffice { get; set; } = string.Empty;
    
    public DateTimeOffset ReportDatetime { get; set; }
    
    public TimeSeriesItemDto[] TimeSeries { get; set; } = Array.Empty<TimeSeriesItemDto>();
    
    public TempAverageDto? TempAverage { get; set; }
    
    public PrecipAverageDto? PrecipAverage { get; set; }
}