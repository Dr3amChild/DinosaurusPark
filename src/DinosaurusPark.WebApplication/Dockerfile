#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /src
#COPY . .
#RUN dotnet publish ./src/DinosaurusPark.WebApplication/DinosaurusPark.WebApplication.csproj -c Release -o /app
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
#WORKDIR /app
#EXPOSE 80
#COPY --from=build /app .
#ENTRYPOINT ["dotnet"]
#CMD ["DinosaurusPark.WebApplication.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "./src/DinosaurusPark.WebApplication/DinosaurusPark.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet"]
CMD ["DinosaurusPark.WebApplication.dll"]
