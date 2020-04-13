dotnet restore
dotnet ef dbcontext scaffold "Server=localhost; Port=3306; Database=mysql; Uid=root; Pwd=root;" Pomelo.EntityFrameworkCore.MySql -o Models --context Context -v \
 > _scaffold.result.txt
