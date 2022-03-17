FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["read-from-asb/read-from-asb.csproj", "read-from-asb/"]
RUN dotnet restore "read-from-asb/read-from-asb.csproj"
COPY . .
WORKDIR "/src/read-from-asb"
RUN dotnet build "read-from-asb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "read-from-asb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "read-from-asb.dll"]
