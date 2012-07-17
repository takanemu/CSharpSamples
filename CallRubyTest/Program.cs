using System;
using Microsoft.Scripting.Hosting;
using IronRuby;

namespace CallRubyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rubyスクリプト・エンジンの作成
            ScriptEngine engine = Ruby.CreateEngine();

            // Rubyスクリプト・ファイルを実行
            engine.ExecuteFile("Hello.rb");

            // 出力結果例： "Hello Ruby Script!!!"
            // 出力結果が分かるように、実行を止める
            Console.ReadLine();
        }
    }
}
