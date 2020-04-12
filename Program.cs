namespace efMysql
{
    using System;
    using System.Linq;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using efMysql.Models;

    class Program
    {
        static IConfiguration GetConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            // 設定ファイルのベースパスをカレントディレクトリ( 実行ファイルと同じディレクトリ )にします。
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            // Json ファイルへのパスを設定します。SetBasePath() で設定したパスからの相対パスになります。
            configBuilder.AddJsonFile(@"appsettings.json");
            return configBuilder.Build();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start");
            
            using(var db = new Context()){
                var users = db.User.Where(w=>w.User1=="root");
                foreach(var i in users){
                    Console.WriteLine($"{i.Host} {i.User1}");
                }
            }
        }
    }
}
