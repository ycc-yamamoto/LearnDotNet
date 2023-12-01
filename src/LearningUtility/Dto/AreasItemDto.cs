using System;

namespace LearningUtility.Dto;

public sealed class AreasItemDto
{
    public AreaDto Area { get; set; } = default!;
    
    public string[]? WeatherCodes { get; set; }
    
    public string[]? Weathers { get; set; }
    
    public string[]? Winds { get; set; }
    
    public string[]? Waves { get; set; }
    
    public string[]? TempsMin { get; set; }
    
    public string[]? TempsMinUpper { get; set; }
    
    public string[]? TempsMinLower { get; set; }
    
    public string[]? TempsMax { get; set; }
    
    public string[]? TempsMaxUpper { get; set; }
    
    public string[]? TempsMaxLower { get; set; }
    
    public string? Min { get; set; }
    
    public string? Max { get; set; }
}