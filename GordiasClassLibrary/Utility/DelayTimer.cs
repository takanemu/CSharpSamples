
namespace GordiasClassLibrary.Utility
{
    using System;
    using System.Threading;

    /// <summary>
    /// 処理遅延実行タイマークラス
    /// </summary>
    /// <author>Takanori Shibuya</author>
    public class DelayTimer
    {
        /// <summary>
        /// タイマー
        /// </summary>
        private Timer timer;

        /// <summary>
        /// 遅延時間(ms)
        /// </summary>
        private long delay;

        /// <summary>
        /// 処理
        /// </summary>
        private Action action;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <author>Takanori Shibuya.</author>
        public DelayTimer()
        {
        }

        /// <summary>
        /// 処理と遅延時間の登録
        /// </summary>
        /// <param name="delay">遅延時間</param>
        /// <param name="action">処理</param>
        /// <author>Takanori Shibuya</author>
        public void EntryWork(long delay, Action action)
        {
            this.delay = delay;
            this.action = action;
        }

        /// <summary>
        /// 処理延滞
        /// </summary>
        /// <author>Takanori Shibuya</author>
        public void Delayed()
        {
            this.Dispose();

            TimerCallback timerDelegate = new TimerCallback(CallbackHandle);
            this.timer = new Timer(timerDelegate, null, 0, this.delay);
        }

        /// <summary>
        /// 遅延された処理の実行
        /// </summary>
        /// <param name="state">パラメーター</param>
        /// <author>Takanori Shibuya</author>
        private void CallbackHandle(object state)
        {
            this.Dispose();
            this.action();
        }

        /// <summary>
        /// 廃棄処理
        /// </summary>
        /// <author>Takanori Shibuya</author>
        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
                this.timer = null;
            }
        }
    }
}
