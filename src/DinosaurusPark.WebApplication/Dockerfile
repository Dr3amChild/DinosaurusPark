FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .
RUN dotnet publish ./src/DinosaurusPark.WebApplication/DinosaurusPark.WebApplication.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT ["dotnet"]
CMD ["DinosaurusPark.WebApplication.dll"]