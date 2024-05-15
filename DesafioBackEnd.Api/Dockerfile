FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DesafioBackEnd.Api/DesafioBackEnd.Api.csproj", "DesafioBackEnd.Api/"]
COPY ["DesafioBackEnd.Service/DesafioBackEnd.Service.csproj", "DesafioBackEnd.Service/"]
COPY ["DesafioBackEnd.Domain/DesafioBackEnd.Domain.csproj", "DesafioBackEnd.Domain/"]
COPY ["DesafioBackEnd.Infra/DesafioBackEnd.Infra.csproj", "DesafioBackEnd.Infra/"]
RUN dotnet restore "DesafioBackEnd.Api/DesafioBackEnd.Api.csproj"
COPY . .
WORKDIR "/src/DesafioBackEnd.Api"
RUN dotnet build "DesafioBackEnd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
RUN dotnet publish "DesafioBackEnd.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioBackEnd.Api.dll"]