#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/BattleControl.WebAPI/BattleControl.WebAPI.csproj", "src/BattleControl.WebAPI/"]
COPY ["src/BattleControl.Core/BattleControl.Core.csproj", "src/BattleControl.Core/"]
RUN dotnet restore "src/BattleControl.WebAPI/BattleControl.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/BattleControl.WebAPI"
RUN dotnet build "BattleControl.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BattleControl.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BattleControl.WebAPI.dll"]