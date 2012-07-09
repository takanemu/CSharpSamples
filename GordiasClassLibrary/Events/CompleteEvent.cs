using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GordiasClassLibrary.Events
{
    /// <summary>
    /// 完了イベントデリゲート
    /// </summary>
    /// <param name="sender">イベント元</param>
    /// <param name="e">パラメーター</param>
    /// <author>Takanori Shibuya.</author>
    public delegate void CompleteEventHandler(object sender, CompleteEventArgs e);

    /// <summary>
    /// 完了イベント実装インターフェース
    /// </summary>
    /// <author>Takanori Shibuya.</author>
    public interface INotifyComplete
    {
        /// <summary>
        /// 完了イベント
        /// </summary>
        event CompleteEventHandler Complete;

        /// <summary>
        /// 処理実行
        /// </summary>
        void Execution();
    }

    /// <summary>
    /// 完了イベントパラメーター
    /// </summary>
    /// <author>Takanori Shibuya.</author>
    public class CompleteEventArgs : EventArgs
    {
        /// <summary>
        /// アボートフラグ
        /// </summary>
        public bool IsAbort { get; set; }
    }
}
