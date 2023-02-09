FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GEMEscolar/GEMEscolar.csproj", "GEMEscolar/"]
COPY ["Infra/GEMChuch.Infra/GEMEscolar.Infra.csproj", "Infra/GEMChuch.Infra/"]
COPY ["Infra/GEMChurch.Core/GEMEscolar.Core.csproj", "Infra/GEMChurch.Core/"]
RUN dotnet restore "GEMEscolar/GEMEscolar.csproj"
COPY . .
WORKDIR "/src/GEMEscolar"
RUN dotnet build "GEMEscolar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GEMEscolar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GEMEscolar.dll"]