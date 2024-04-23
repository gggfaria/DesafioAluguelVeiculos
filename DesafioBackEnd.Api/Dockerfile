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


## Run migrations
#FROM build as migrations
#WORKDIR "/src/"
#RUN dotnet tool install --version 6.0.29 --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
#ENTRYPOINT dotnet-ef database update --project ./DesafioBackEnd.Infra/DesafioBackEnd.Infra.csproj --startup-project ./DesafioBackEnd.Api/DesafioBackEnd.Api.csproj
#






#ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:6.0
#ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:6.0
#
#FROM ${DOTNET_RUNTIME} AS base
#ENV ASPNETCORE_URLS=http://
#WORKDIR /home/app
#EXPOSE 80
#
## Base for build
#FROM ${DOTNET_SDK} AS buildbase
#WORKDIR /source
#
#COPY ["DesafioBackEnd.sln", "./"]
#COPY ["DesafioBackEnd.Api/DesafioBackEnd.Api.csproj", "DesafioBackEnd.Api/"]
#COPY ["DesafioBackEnd.Service/DesafioBackEnd.Service.csproj", "DesafioBackEnd.Service/"]
#COPY ["DesafioBackEnd.Domain/DesafioBackEnd.Domain.csproj", "DesafioBackEnd.Domain/"]
#COPY ["DesafioBackEnd.Infra/DesafioBackEnd.Infra.csproj", "DesafioBackEnd.Infra/"]
#
#COPY ["DesafioBackEnd.Test/DesafioBackEnd.Test.csproj", "DesafioBackEnd.Test/"]
#
#RUN dotnet restore DesafioBackEnd.sln
#
### Run migrations
#FROM buildbase as migrations
#RUN dotnet tool install --version 6.0.9 --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
#ENTRYPOINT dotnet-ef database update --project ./DesafioBackEnd.Infra/DesafioBackEnd.Infra.csproj --startup-project ./DesafioBackEnd.Api/DesafioBackEnd.Api.csproj