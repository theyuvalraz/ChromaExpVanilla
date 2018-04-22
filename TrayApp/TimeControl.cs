using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayApp
{
    public class TimeControl
    {
        public int CalculateTimerInterval(int minute)
        {
            if (minute <= 0)
                minute = 60;
            DateTime now = DateTime.Now;

            DateTime future = now.AddMinutes((minute - (now.Minute % minute))).AddSeconds(now.Second * -1)
                .AddMilliseconds(now.Millisecond * -1);

            TimeSpan interval = future - now;

            return (int) interval.TotalMilliseconds;
        }
    }
}