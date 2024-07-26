FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY publish/ .
EXPOSE 80
#ENV TZ=Asia/Shanghai
ENTRYPOINT ["dotnet", "AbpZero.HttpApi.Host.dll"]
