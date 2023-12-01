using System;

namespace LearningUtility;

public static class DoubleExtension
{
    /// <summary>
    /// 小数点以下の桁数を指定して丸めます。
    /// </summary>
    /// <param name="self">対象の値</param>
    /// <param name="position">小数点以下の桁数</param>
    /// <param name="mode">丸めモード</param>
    /// <returns>丸めた値</returns>
    public static double Round(this double self, int position, RoundMode mode = RoundMode.Round)
    {
        if (position < 1)
        {
            throw new ArgumentException("丸める位置は小数点以下の桁数を指定してください。", nameof(position));
        }

        double result;

        switch (mode)
        {
            case RoundMode.Round:
                result = Math.Round(self, position);
                break;
            case RoundMode.Floor:
                result = Math.Floor(self * Math.Pow(10, position)) / Math.Pow(10, position);
                break;
            case RoundMode.Ceiling:
                result = Math.Ceiling(self * Math.Pow(10, position)) / Math.Pow(10, position);
                break;
            default:
                throw new ArgumentException("丸めモードが不正です。", nameof(mode));
        }

        return result;
    }
}