
namespace GordiasClassLibrary.Executor
{
    using System;
    using GordiasClassLibrary.Events;

    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    /// <author>Takanori Shibuya</author>
    public class CommandExecutor : INotifyComplete, ICommandExecutor
    {
        /// <summary>
        /// 処理
        /// </summary>
        private Action<ICommandExecutor> action;

        /// <summary>
        /// オプションデータ
        /// </summary>
        private object data = null;

        /// <summary>
        /// 更新イベントハンドラ
        /// </summary>
        public event CompleteEventHandler Complete;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="action">処理</param>
        /// <author>Takanori Shibuya.</author>
        public CommandExecutor(Action<ICommandExecutor> action)
        {
            this.EntryAction(action);
        }

        /// <summary>
        /// 処理登録
        /// </summary>
        /// <param name="action">処理</param>
        /// <author>Takanori Shibuya.</author>
        public void EntryAction(Action<ICommandExecutor> action)
        {
            this.action = action;
        }

        /// <summary>
        /// アボート発火
        /// </summary>
        /// <author>Takanori Shibuya.</author>
        public void DoAbort()
        {
            this.OnComplete(true);
        }

        /// <summary>
        /// 完了イベント発火
        /// </summary>
        /// <author>Takanori Shibuya.</author>
        public void DoComplete()
        {
            this.OnComplete();
        }

        /// <summary>
        /// 完了イベント発火
        /// </summary>
        /// <param name="isAbort">trueならアボート</param>
        /// <author>Takanori Shibuya.</author>
        private void OnComplete(bool isAbort = false)
        {
            CompleteEventArgs ea = new CompleteEventArgs();

            ea.IsAbort = isAbort;

            if (this.Complete != null)
            {
                this.Complete(this, ea);
            }
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <author>Takanori Shibuya.</author>
        public void Execution()
        {
            this.action(this);
        }

        /// <summary>
        /// オプションデータ設定
        /// </summary>
        /// <param name="data">データ</param>
        /// <returns>メソッドチェーン</returns>
        /// <author>Takanori Shibuya.</author>
        public CommandExecutor SetData(object data)
        {
            this.data = data;
            return this;
        }

        /// <summary>
        /// オプションデータ取得
        /// </summary>
        /// <returns>データ</returns>
        public object GetData()
        {
            return this.data;
        }
    }
}
