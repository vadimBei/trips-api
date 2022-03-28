#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Algolia/Algolia.Api/Algolia.Api.csproj", "src/Services/Algolia/Algolia.Api/"]
COPY ["src/Services/Algolia/Algolia.Core/Algolia.Core.csproj", "src/Services/Algolia/Algolia.Core/"]
COPY ["src/Common/Common.Data/Common.Data.csproj", "src/Common/Common.Data/"]
COPY ["src/Common/Common.Kernel/Common.Kernel.csproj", "src/Common/Common.Kernel/"]
RUN dotnet restore "src/Services/Algolia/Algolia.Api/Algolia.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Algolia/Algolia.Api"
RUN dotnet build "Algolia.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Algolia.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Algolia.Api.dll"]