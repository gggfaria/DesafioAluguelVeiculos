FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DesafioBackEnd.Web/DesafioBackEnd.Web.csproj", "DesafioBackEnd.Web/"]
RUN dotnet restore "DesafioBackEnd.Web/DesafioBackEnd.Web.csproj"
COPY . .
WORKDIR "/src/DesafioBackEnd.Web"
RUN dotnet build "DesafioBackEnd.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DesafioBackEnd.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioBackEnd.Web.dll"]
