
using System;

public static class RetryDelayCalculator
{
    public static TimeSpan GetDelay(int attempt)
    {
        if (attempt < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(attempt));
        }

        int delaySeconds = 1;

        for (int i = 1; i < attempt && delaySeconds < 8; i++)
        {
            delaySeconds *= 2;
        }

        return TimeSpan.FromSeconds(Math.Min(delaySeconds, 8));
    }
}
