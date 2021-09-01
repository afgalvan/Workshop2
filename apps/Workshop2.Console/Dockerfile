FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Workshop2/Workshop2.csproj", "Workshop2/"]
RUN dotnet restore "Workshop2/Workshop2.csproj"
COPY /src .
WORKDIR "/src/Workshop2"
RUN dotnet build "Workshop2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workshop2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workshop2.dll"]
