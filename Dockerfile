FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildstage
WORKDIR /aspnet
COPY ["HypSuite.Client/HypSuite.Client.csproj", "HypSuite.Client/"]
RUN dotnet restore HypSuite.Client/HypSuite.Client.csproj
COPY . .
WORKDIR /aspnet/HypSuite.Client
RUN dotnet build HypSuite.Client.csproj

FROM buildstage AS publishstage
RUN dotnet publish HypSuite.Client.csproj --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /deploy
COPY --from=publishstage /app .
CMD ["dotnet", "HypSuite.Client.dll"]