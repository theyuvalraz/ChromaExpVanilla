using System;

namespace TrayApp
{
    public class TimeControl
    {
        public int CalculateTimerInterval(int minute)
        {
            if (minute <= 0)
                minute = 60;
            var now = DateTime.Now;

            var future = now.AddMinutes((minute - (now.Minute % minute))).AddSeconds(now.Second * -1)
                .AddMilliseconds(now.Millisecond * -1);

            var interval = future - now;

            return (int) interval.TotalMilliseconds;
        }
    }
}