FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ENV TZ="Asia/Shanghai"
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "DedsiStack.AuthorizationCenter.dll"]