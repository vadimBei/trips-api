#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Trips/Trips.Api/Trips.Api.csproj", "src/Services/Trips/Trips.Api/"]
COPY ["src/Services/Trips/Trips.Core/Trips.Core.csproj", "src/Services/Trips/Trips.Core/"]
RUN dotnet restore "src/Services/Trips/Trips.Api/Trips.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Trips/Trips.Api"
RUN dotnet build "Trips.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trips.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trips.Api.dll"]