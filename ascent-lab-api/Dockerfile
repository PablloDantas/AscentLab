FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#ARG APP_UID=1000
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ascent-lab-api/ascent-lab-api.csproj", "ascent-lab-api/"]
RUN dotnet restore "ascent-lab-api/ascent-lab-api.csproj"
COPY . .
RUN dotnet build "ascent-lab-api/ascent-lab-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ascent-lab-api/ascent-lab-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "ascent-lab-api.dll"]