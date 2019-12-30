FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
WORKDIR /src
COPY . .
RUN dotnet publish "./src/DinosaursPark.WebApplication/DinosaursPark.WebApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet"]
CMD ["DinosaursPark.WebApplication.dll"]
