using System;

namespace LearningUtility.Dto;

public sealed class TempAverageDto
{
    public AreasItemDto[] Areas { get; set; } = Array.Empty<AreasItemDto>();
}