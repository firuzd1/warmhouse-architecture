FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TemperatureApi.csproj", "."]
RUN dotnet restore "TemperatureApi.csproj"
COPY . .
RUN dotnet build "TemperatureApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemperatureApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemperatureApi.dll"]