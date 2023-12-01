using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LearningUtility;

Console.WriteLine("Runtime Version: " + RuntimeInformation.FrameworkDescription);
Console.CancelKeyPress += (_, _) =>
{
    Console.WriteLine("キャンセルされました。");
    Environment.Exit(1);
};

using var weatherClient = new WeatherForecast();
var weathers = await weatherClient.GetWeatherAsync(default).ConfigureAwait(false);

if (weathers is not null && weathers.Length > 0)
{
    var weather = weathers.First();
    var dict = new Dictionary<DateTimeOffset, string>();

    if (weather.TimeSeries.Length > 0)
    {
        var timeSeries = weather.TimeSeries.First();

        for (var index = 0; index < timeSeries.TimeDefines.Length; index++)
        {
            var stringBuilder = new StringBuilder();
            var timeDefine = timeSeries.TimeDefines[index];

            foreach (var area in timeSeries.Areas)
            {
                var areaName = area.Area.Name;
                var weatherName = area.Weathers?[index];

                stringBuilder.AppendLine($"場所：{areaName}");
                stringBuilder.AppendLine($"天気：{weatherName}");
            }
                
            dict[timeDefine] = stringBuilder.ToString();
        }

        foreach (var pair in dict)
        {
            Console.WriteLine(pair.Key.ToLocalTime());
            Console.WriteLine(pair.Value);
        }
    }
}


