FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["demo-api-asb-queue/demo-api-asb-queue.csproj", "demo-api-asb-queue/"]
RUN dotnet restore "demo-api-asb-queue/demo-api-asb-queue.csproj"
COPY . .
WORKDIR "/src/demo-api-asb-queue"
RUN dotnet build "demo-api-asb-queue.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo-api-asb-queue.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demo-api-asb-queue.dll"]
