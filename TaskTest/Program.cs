using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.SyncTaskEnd();

            program.WaitResult();

            program.CancellationToken();

            program.ChildTask1();

            program.ChildTask2();

            Console.ReadKey();
        }

        /// <summary>
        /// ContinueWith メソッドを使って、タスク完了時にその先続けて行いたい処理を渡す。
        /// </summary>
        public void SyncTaskEnd()
        {
            var t = Task.Factory.StartNew(() =>
            {
                // 何か重たい計算をして、その計算結果を返す。
                return HeavyWork();
            });

            // 計算が完了したら、そのあと続けたい処理を呼び出してもらう。
            t.ContinueWith(x => Console.WriteLine("A:" + x.Result));
        }

        /// <summary>
        /// タスクの完了を同期的に（完了するまで処理を止めて）待つ。
        /// Result プロパティを読もうとしたとき、タスクがまだ完了していない場合、 完了するまで待つことになる。
        /// </summary>
        public void WaitResult()
        {
            var t = Task.Factory.StartNew(() =>
            {
                // 何か重たい計算をして、その計算結果を返す。
                return HeavyWork();
            });

            // 同期的に完了を待つ。
            Console.WriteLine("B:" + t.Result);
        }

        /// <summary>
        /// 非同期実行中のタスクを途中でキャンセルするための仕組みとして、 CancellationToken 構造体というものが標準で用意されている。
        /// </summary>
        public void CancellationToken()
        {
            var cts = new CancellationTokenSource();

            var t = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("done");
            }, cts.Token);

            // t をキャンセル
            cts.Cancel();
        }

        /// <summary>
        /// タスクの中で別の新しいタスクを作りたい場合があります。 オプションなしの場合、それぞれのタスクは無関係に動くことになります。
        /// </summary>
        public void ChildTask1()
        {
            var t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("タスク1開始");
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("タスク2開始");
                });
            });

            t.Wait(); // 今のままだと、タスク2の完了は待たない
            Console.WriteLine("完了");
        }

        /// <summary>
        /// オプションを指定することで、タスクに親子関係を作ることができます。 Task.Wait による完了待ちは、子タスクの完了まで含めて待ちます。
        /// </summary>
        public void ChildTask2()
        {
            var t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("タスク1開始");
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("タスク2開始");
                }, TaskCreationOptions.AttachedToParent); // 子タスク化
            });

            t.Wait(); // 子タスクの完了まで待つ
            Console.WriteLine("完了");
        }

        private string HeavyWork()
        {
            Thread.Sleep(1000);
            return "success";
        }
    }
}
