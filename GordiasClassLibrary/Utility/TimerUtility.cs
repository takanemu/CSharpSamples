using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GordiasClassLibrary.Utility
{
    public class TimerUtility
    {
        public static Action DelayAction(long delay, Action action)
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

            Action canceler = () =>
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            };
            return canceler;
        }

        public static Action IntervalAction(long interval, Func<bool> action)
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

            Action canceler = () =>
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            };
            return canceler;
        }

        public static Action IntervalLoopAction<T>(long interval, IEnumerator<T> iterator, Func<T, bool> action, Action<bool> ender = null)
        {
            Timer timer = null;

            TimerCallback timerDelegate = new TimerCallback(
                delegate
                {
                    if (iterator.MoveNext())
                    {
                        bool result = action(iterator.Current);

                        if (!result)
                        {
                            if (timer != null)
                            {
                                // ループ途中でキャンセル
                                timer.Dispose();
                                timer = null;
                            }
                            if (ender != null)
                            {
                                ender(false);
                            }
                        }
                    }
                    else
                    {
                        // ループ終了
                        if (timer != null)
                        {
                            timer.Dispose();
                            timer = null;
                        }
                        if (ender != null)
                        {
                            ender(true);
                        }
                    }
                }
            );
            timer = new Timer(timerDelegate, null, 0, interval);
            
            Action canceler = () =>
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
            };
            return canceler;
        }
    }
}
