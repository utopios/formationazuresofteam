FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS directory
WORKDIR /app
EXPOSE 2000
EXPOSE 2001
ENV ASPNETCORE_URLS="http://localhost:2000;https://localhost:2001"
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["producer-api/producer-api.csproj", "producer-api/"]
RUN dotnet restore "producer-api/producer-api.csproj"
COPY . .
WORKDIR "/src/producer-api"
RUN dotnet build "producer-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "producer-api.csproj" -c Release -o /app/publish

FROM directory AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "producer-api.dll"]


