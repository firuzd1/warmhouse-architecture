FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TelemetryService.csproj", "."]
RUN dotnet restore "TelemetryService.csproj"
COPY . .
RUN dotnet build "TelemetryService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelemetryService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelemetryService.dll"]