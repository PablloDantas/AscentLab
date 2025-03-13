FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ascent-lab-web/ascent-lab-web.csproj", "src/ascent-lab-web/"]
RUN dotnet restore "src/ascent-lab-web/ascent-lab-web.csproj"
COPY . .
RUN dotnet build "src/ascent-lab-web/ascent-lab-web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/ascent-lab-web/ascent-lab-web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ascent-lab-web.dll"]