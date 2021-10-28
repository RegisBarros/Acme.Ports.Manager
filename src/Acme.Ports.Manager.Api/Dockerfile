FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Acme.Ports.Manager.Api/Acme.Ports.Manager.Api.csproj", "Acme.Ports.Manager.Api/"]
RUN dotnet restore "src/Acme.Ports.Manager.Api/Acme.Ports.Manager.Api.csproj"
COPY . .
WORKDIR "/src/Acme.Ports.Manager.Api"
RUN dotnet build "Acme.Ports.Manager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acme.Ports.Manager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.Ports.Manager.Api.dll"]
