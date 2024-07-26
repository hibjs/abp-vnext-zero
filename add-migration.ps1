param($m)
cd ./src/AbpZero.EntityFrameworkCore
write-host "Migration Message: $m"
dotnet ef migrations add $m -s ../AbpZero.HttpApi.Host
cd ../../