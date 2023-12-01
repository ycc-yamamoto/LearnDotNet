using System;

namespace LearningUtility.Dto;

public sealed class PrecipAverageDto
{
    public AreasItemDto[] Areas { get; set; } = Array.Empty<AreasItemDto>();
}