FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["demo-message-queue/demo-message-queue.csproj", "demo-message-queue/"]
RUN dotnet restore "demo-message-queue/demo-message-queue.csproj"
COPY . .
WORKDIR "/src/demo-message-queue"
RUN dotnet build "demo-message-queue.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo-message-queue.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demo-message-queue.dll"]
