using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GordiasClassLibrary.Executor
{
    public interface ICommandExecutor
    {
        /// <summary>
        /// アボート発火
        /// </summary>
        void DoAbort();

        /// <summary>
        /// 完了イベント発火
        /// </summary>
        void DoComplete();

        /// <summary>
        /// オプションデータ取得
        /// </summary>
        /// <returns>データ</returns>
        object GetData();
    }
}
