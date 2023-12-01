using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LearningUtility;

// 日付を入力すると、その日付の曜日を出力するプログラム
Console.WriteLine("Runtime Version: " + RuntimeInformation.FrameworkDescription);
Console.CancelKeyPress += (_, _) =>
{
    Console.WriteLine("キャンセルされました。");
    Environment.Exit(1);
};

string? input;
DateTime date;

do
{
    Console.Write("日付を入力してください: ");
    input = Console.ReadLine();
} while (!DateTime.TryParse(input, out date));

Console.WriteLine($"{date:yyyy年MM月dd日}は{date:dddd}です。(今年は残り{(new DateTime(date.Year, 12, 31) - date).TotalDays}日間)");

// 残り時間
var remainingHours = (DateTime.Today.AddDays(1) - DateTime.Now).TotalSeconds / 60 / 60;

Console.WriteLine($"今日は残り{remainingHours.Round(2, RoundMode.Floor)}時間です。{Environment.NewLine}");

if (date.Date == DateTime.Today)
{
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
}
