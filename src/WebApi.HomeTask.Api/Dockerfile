FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApi.HomeTask.Api/WebApi.HomeTask.Api.csproj", "WebApi.HomeTask.Api/"]
RUN dotnet restore "WebApi.HomeTask.Api/WebApi.HomeTask.Api.csproj"
COPY . .
WORKDIR "/src/WebApi.HomeTask.Api"
RUN dotnet build "WebApi.HomeTask.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.HomeTask.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.HomeTask.Api.dll"]
