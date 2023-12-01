using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LearningUtility.Dto;

namespace LearningUtility;

public sealed class WeatherForecast : IDisposable
{
    private const string Url = @"https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json";

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
    
    private readonly HttpClient httpClient;
    
    public WeatherForecast()
    {
        this.httpClient = new HttpClient();
    }
    
    ~WeatherForecast()
    {
        this.Dispose(false);
    }

    public bool IsDisposed
    {
        get;
        private set;
    }

    /// <summary>
    /// 天気予報の情報を取得します。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>天気予報の情報</returns>
    public async Task<WeatherDto[]?> GetWeatherAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var response = await this.httpClient.GetAsync(Url, cancellationToken).ConfigureAwait(false);
        
        // HTTPステータスが200系以外の場合は例外をスローする
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<WeatherDto[]>(json, JsonSerializerOptions);
        
        return result;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    private void Dispose(bool disposing)
    {
        if (this.IsDisposed)
        {
            return;
        }
        
        if (disposing)
        {
            this.httpClient.Dispose();
        }
        
        this.IsDisposed = true;
    }
}