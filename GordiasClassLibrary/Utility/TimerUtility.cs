using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GordiasClassLibrary.Utility
{
    public class TimerUtility
    {
        public static void DelayAction(long delay, Action action)
        {
            Timer timer = null;

            TimerCallback timerDelegate = new TimerCallback(
                delegate {
                    if (timer != null)
                    {
                        timer.Dispose();
                        timer = null;
                        action();
                    }
                }
            );
            timer = new Timer(timerDelegate, null, 0, delay);
        }

        public static void IntervalAction(long interval, Func<bool> action)
        {
            Timer timer = null;

            TimerCallback timerDelegate = new TimerCallback(
                delegate
                {
                    bool result = action();

                    if (!result)
                    {
                        if (timer != null)
                        {
                            timer.Dispose();
                            timer = null;
                        }
                    }
                }
            );
            timer = new Timer(timerDelegate, null, 0, interval);
        }
    }
}
