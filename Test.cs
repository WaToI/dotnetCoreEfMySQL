namespace efMysql
{
    using System;
    using System.Linq;
    using efMysql.Models;
    using Microsoft.EntityFrameworkCore;
    public class DBTest
    {
        public DBTest()
        {
            TestEfSelectLinq();
            TestEfSelectSql();
            TestExecuteSql();
        }
        public void TestEfSelectLinq()
        {
            Console.WriteLine(">>>TestEfSelectLinq");
            using (var db = new Context())
            {
                var users = db.User.Where(w => w.User1 == "root");
                foreach (var i in users)
                {
                    Console.WriteLine($"{i.Host} {i.User1}");
                }
            }
        }
        public void TestEfSelectSql()
        {
            Console.WriteLine(">>>TestEfSelectSql");
            using (var db = new Context())
            {
                var sql = "select * from user where user = {0}";
                var users = db.User.FromSqlRaw(sql, "root");
                foreach (var i in users)
                {
                    Console.WriteLine($"{i.Host} {i.User1}");
                }
            }
        }
        public void TestExecuteSql()
        {
            Console.WriteLine(">>>TestExecuteSql");
            using (var db = new Context())
            {
                using (var tr = db.Database.BeginTransaction())
                {
                    var sql = @"UPDATE user SET user={1} WHERE user={0}";
                    var par = new[] { "test", "tester" };
                    db.Database.ExecuteSqlRaw(sql, par[0], par[1]);

                    var users = db.User.Where(w => w.User1 == par[1]);
                    foreach (var i in users)
                    {
                        Console.WriteLine($"{i.Host} {i.User1}");
                    }
                    tr.Rollback();
                }
            }

        }
    }
}